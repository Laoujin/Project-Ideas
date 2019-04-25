SignalR
=======

.NET Hub
--------
Install-Package Microsoft.AspNet.SignalR

OwinStartup:
app.Map("/signalr", map =>
{
  map.UseCors(CorsOptions.AllowAll);
  map.RunSignalR(new HubConfiguration() {EnableDetailedErrors = true, EnableJSONP = true});
});

public class MyHub : Hub
{
  public void Send(string name, string message)
  {
    Clients.All.broadcastMessage(name, message);
  }
}

JavaScript Client
-----------------
<script src="/bower_components/jquery/dist/jquery.min.js"></script>
<script src="/bower_components/signalr/jquery.signalR.min.js"></script>
<script src="/hub.js"></script>

<script>
  $(function () {
    var myHub = $.connection.myHub;
    myHub.client.broadcastMessage = function (name, message) {
      console.log('broadcastMessage', name, message);
    };

    $.connection.hub.logging = true;
    $.connection.hub.start().done(function () {
      myHub.server.send('name', 'message');
    });
  });
</script>

Generate hub.js
---------------
Install-Package Microsoft.AspNet.SignalR.Utils

In: packages\Microsoft.AspNet.SignalR.Utils.2.2.0\tools
Run: .\signalr.exe ghp /path:C:\path\to\SignalR.Project\bin\

Lifecycle Api
-------------
Server configuration:  
// Make long polling connections wait a maximum of 110 seconds for a
// response. When that time expires, trigger a timeout command and
// make the client reconnect.
GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);

// Wait a maximum of 30 seconds after a transport connection is lost
// before raising the Disconnected event to terminate the SignalR connection.
GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);

// For transports other than long polling, send a keepalive packet every
// 10 seconds. 
// This value must be no more than 1/3 of the DisconnectTimeout value.
GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);

Client:  
$.connection.hub.connectionSlow(function() { });
$.connection.hub.disconnected(function() {
	if ($.connection.hub.lastError) {
		alert("Disconnected. Reason: " +  $.connection.hub.lastError.message);
	}
});
$.connection.hub.reconnecting(function() { });
$.connection.hub.reconnected(function() { });

How to continuously reconnect:  
$.connection.hub.disconnected(function() {
  setTimeout(function() {
     $.connection.hub.start();
  }, 5000);
});