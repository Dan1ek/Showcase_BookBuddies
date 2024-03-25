using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Showcase_BookBuddies.Business.Entities;

namespace Showcase_BookBuddies.Hubs
{
    public class UpdateList : Hub
    {
        public async Task SendUpdate()
        {
            // Verzend de bijgewerkte booklist naar alle clients
            //await Clients.All.SendAsync("ReceiveUpdate", bookList);
            await Clients.All.SendAsync("ReceiveUpdate");

        }

    }
}
