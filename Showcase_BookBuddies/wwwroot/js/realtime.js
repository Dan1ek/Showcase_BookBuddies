$(document).ready(function () {
    // Verbinding maken met de SignalR Hub
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/updateList")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    // Event afhandelen voor het ontvangen van updates
    connection.on("SendUpdate", function () {
        // Herlaad de pagina
        location.reload();
        alert("pagina herladen");
    });

    // Start de verbinding
    connection.start().catch(function (err) {
        return console.error(err.toString());
    });
});