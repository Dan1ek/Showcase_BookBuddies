
//////function updateBookList(bookList) {
//////    connection.invoke("SendUpdate", bookList)
//////        .catch(err => console.error(err));
//////}


////const connection = new signalR.HubConnectionBuilder()
////    .withUrl("/updateList")
////    .withUrl("/updateBook")
////    .build();

////connection.start().then(() => {
////    console.log("SignalR connected!");
////});

////connection.on("ReceiveUpdate", (bookList) => {
////    alert("update");
////    var li = document.createElement("li");
////    document.getElementById("bookList").appendChild(li);
////    li.textContent = ` Dit is boeklijst: ${bookList}`;
////});

//<script src="~/lib/@microsoft/signalr/dist/browser/signalr.min.js"></script>
//var connection = new signalR.HubConnectionBuilder().withUrl("/updateHub").build();

//connection.start().then(function () {
//    console.log("SignalR connected.");
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//connection.on("ReloadPage", function () {
//    location.reload();
//});

var connection = new signalR.HubConnectionBuilder().withUrl("/updateList").build();

connection.start().then(function () {
    console.log("SignalR connected.");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReloadPage", function () {
    location.reload();
});