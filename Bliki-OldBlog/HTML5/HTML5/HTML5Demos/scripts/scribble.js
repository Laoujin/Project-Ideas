var _ports = new Array();
addEventListener("connect", onConnect, false);

function onConnect(e) {
    // Add the new port to the _ports array and listen for messages from it
    var port = e.ports[0];
    _ports.push(port);
    port.addEventListener("message", onMessage, false);
    port.start();
}

function onMessage(e) {
    // Pass the data contained in this message to all connected threads
    for (var i = 0; i < _ports.length; i++) {
        _ports[i].postMessage(e.data);
    }
}