using RestSharp;
using System.Threading.Tasks;
using WhatsAppMessaging.Utils;
using WhatsAppMessaging.Models;

namespace WhatsAppMessaging.Services
{
    public class WhatsAppService
    {
        public async Task<string> SendMessageAsync(Message message)
        {
            var url = $"{Config.BaseUrl}{Config.InstanceId}/messages/chat";
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post);

            // Configurar os headers e parâmetros
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("token", Config.Token, ParameterType.GetOrPost);
            request.AddParameter("to", message.To, ParameterType.GetOrPost);
            request.AddParameter("body", message.Body, ParameterType.GetOrPost);

            // Executar a requisição
            var response = await client.ExecuteAsync(request);
            return response.Content ?? string.Empty;
        }

        public async Task<string> SendMediaMessageAsync(Message message, string mediaType)
        {
            var url = $"{Config.BaseUrl}{Config.InstanceId}/messages/{mediaType}";
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post);

            // Configurar os headers e parâmetros
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("token", Config.Token, ParameterType.GetOrPost);
            request.AddParameter("to", message.To, ParameterType.GetOrPost);

            if (!string.IsNullOrEmpty(message.MediaUrl))
                request.AddParameter(mediaType, message.MediaUrl, ParameterType.GetOrPost);

            if (!string.IsNullOrEmpty(message.Caption))
                request.AddParameter("caption", message.Caption, ParameterType.GetOrPost);

            // Executar a requisição
            var response = await client.ExecuteAsync(request);
            return response.Content ?? string.Empty;
        }
    }
}
