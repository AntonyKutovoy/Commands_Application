using Commands.Interfaces;
using Commands.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Services
{
    public class CommandsService : ICommandsService
    {
        private readonly string _authorizationToken;
        private readonly string _baseUrl;
        private readonly string _getAllCommandsUrlPart;
        private readonly string _getAllTerminalsUrlPart;
        private HttpClient Client { get; set; }

        public CommandsService(IConfiguration configuration, HttpClient client)
        {
            _authorizationToken = configuration["ServiceApiKeys:AuthorizationToken"];
            _baseUrl = configuration["ApiBaseUrls:BaseUrl"];
            _getAllCommandsUrlPart = configuration["ApiBaseUrls:GetAllCommandsUrlPart"];
            _getAllTerminalsUrlPart = configuration["ApiBaseUrls:GetAllTerminalsUrlPart"];
            client.BaseAddress = new Uri(_baseUrl);
            Client = client;
        }

        public async Task<ViewPage> GetViewPage()
        {
            var viewPage = new ViewPage();
            viewPage.Commands = await GetAllCommand();
            viewPage.SentCommands = await GetAllSentCommand();
            return viewPage;
        }

        public async Task SendCommand(ViewPage viewPage)
        {
            var data = new StringContent(JsonConvert.SerializeObject(viewPage.UserInput.SendingCommand, Formatting.Indented).ToLower(),
                Encoding.UTF8, "application/json");
            var url = $"terminals/{viewPage.UserInput.TerminalId}/commands?token={_authorizationToken}";
            await Client.PostAsync(url, data);
        }

        private async Task<List<Command>> GetAllCommand()
        {
            var commands = JsonConvert.DeserializeObject<Page<Command>>
                (await GetResponseString(_getAllCommandsUrlPart)).Items;
            foreach(var command in commands)
            {
                command.Parameters_Count = GetParametersCount(command);
            }
            return commands;
        }

        private async Task<List<SentCommand>> GetAllSentCommand()
        {
            var sentCommandList = new List<SentCommand>();
            foreach (var id in await GetTerminalIdList())
            {
                sentCommandList.AddRange(JsonConvert.DeserializeObject<Page<SentCommand>>
                    (await GetResponseString($"terminals/{id}/commands?token=")).Items);
            }
            var allCommands = await GetAllCommand();
            foreach (var sentCommand in sentCommandList)
            {
                foreach (var command in allCommands)
                {
                    if (sentCommand.Command_Id == command.Id)
                    {
                        sentCommand.Name = command.Name;
                    }
                }
            }
            return sentCommandList.OrderBy(q => q.Id).ToList();
        }

        private async Task<List<int>> GetTerminalIdList()
        {
            return JsonConvert.DeserializeObject<Page<Terminal>>
                (await GetResponseString(_getAllTerminalsUrlPart)).Items.Select(item => item.Id).ToList();
        }

        private async Task<string> GetResponseString(string urlPart)
        {
            var urlParameters = $"{urlPart}{_authorizationToken}";
            var response = await Client.GetAsync(urlParameters);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private int GetParametersCount (Command command)
        {
            var parametersCount = 0;
            if(command.Parameter_Name1 != null)
            {
                parametersCount++;
            }
            if(command.Parameter_Name2 != null)
            {
                parametersCount++;
            }
            if (command.Parameter_Name3 != null)
            {
                parametersCount++;
            }
            return parametersCount;
        }
    }
}
