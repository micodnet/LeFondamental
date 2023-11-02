using System.Text.RegularExpressions;
using Api_Fondamental.DTOs;
using Api_Fondamental.Models;
using Microsoft.AspNetCore.SignalR;

namespace Api_Fondamental.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }

        public async Task JoinGroup(string groupName, string userName)
        {
            GroupViewModel groupViewModel = new GroupViewModel();
            groupViewModel.GroupName = groupName;
            groupViewModel.UserName = userName;
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await SendToGroup(new Message
            {

                Author = userName,
                Content = "Un nouvel utilisateur s'est connecté : " + userName,
                UserIdEnvoi = 0,
                UserIdRecu = 0,
                DateEnvoi = DateTime.Now,

            }, groupName);
            await Groups.AddToGroupAsync($"{groupName}", groupName);
        }    

        public async Task SendToGroup(Message message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("messageFromGroup", message);
        }
    }
}
