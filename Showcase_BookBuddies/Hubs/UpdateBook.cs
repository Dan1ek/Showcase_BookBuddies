using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Showcase_BookBuddies.Business.Entities;
using Showcase_BookBuddies.Migrations;

namespace Showcase_BookBuddies.Hubs
{
    public class UpdateBook : Hub
    {
        public async Task SendUpdate(Book book)
        {
            await Clients.All.SendAsync("ReceiveUpdate", book);
        }

    }
}
