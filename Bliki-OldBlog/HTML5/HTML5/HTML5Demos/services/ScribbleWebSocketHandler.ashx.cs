using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

public class ScribbleWebSocketHandler : IHttpHandler
{
    private const int _bufferSize = 64 * 1024;
    private static List<WebSocket> _sockets = new List<WebSocket>();

    public void ProcessRequest(HttpContext context)
    {
        if (context.IsWebSocketRequest)
        {
            try
            {
                context.AcceptWebSocketRequest(OnAcceptSocketRequest);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = ex.Message;
                context.Response.End();
            }
        }
        else // HTTP request
        {
            context.Response.Output.Write("Hello, WebSockets!");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private async Task OnAcceptSocketRequest(WebSocketContext context)
    {
        byte[] receiveBuffer = new byte[_bufferSize];
        ArraySegment<byte> buffer = new ArraySegment<byte>(receiveBuffer);
        WebSocket socket = context.WebSocket;
        _sockets.Add(socket);

        // Loop while websocket is open
        while (socket.State == WebSocketState.Open)
        {
            // Process an incoming message
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);

            // If it's a close message, close the WebSocket and remove it from
            // the list of connected clients
            if (result.MessageType == WebSocketMessageType.Close)
            {
                _sockets.Remove(socket);
                await socket.CloseAsync(result.CloseStatus.GetValueOrDefault(), result.CloseStatusDescription, CancellationToken.None);
                return;
            }

            // If it's an incomplete message, wait for the rest
            int offset = result.Count;

            while (result.EndOfMessage == false)
            {
                result = await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer, offset, _bufferSize - offset), CancellationToken.None);
                offset += result.Count;
            }

            // If it's a text message, broadcast it to all connected clients
            // except the one that sent the message
            if (result.MessageType == WebSocketMessageType.Text)
            {
                var input = Encoding.UTF8.GetString(receiveBuffer, 0, offset);

                foreach (var client in _sockets)
                {
                    if (client != socket)
                        await SendMessageAsync(client, input);
                }
            }
        }
    }

    private async Task SendMessageAsync(WebSocket socket, string message)
    {
        ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
        await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
    }
}
