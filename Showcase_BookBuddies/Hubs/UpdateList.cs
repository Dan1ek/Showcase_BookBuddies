using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Showcase_BookBuddies.Business.Entities;

namespace Showcase_BookBuddies.Hubs
{
    public class UpdateList : Hub
    {
        public async Task SendUpdate()
        {
            await Clients.All.SendAsync("SendUpdate");

        }

    }
}
