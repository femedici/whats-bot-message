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
            var client = new RestClient(url);
            var request = new RestRequest(Method.Post);
            
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", Config.Token);
            request.AddParameter("to", message.To);
            request.AddParameter("body", message.Body);

            var response = await client.ExecuteAsync(request);
            return response.Content;
        }

        public async Task<string> SendMediaMessageAsync(Message message, string mediaType)
        {
            var url = $"{Config.BaseUrl}{Config.InstanceId}/messages/{mediaType}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.Post);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", Config.Token);
            request.AddParameter("to", message.To);
            request.AddParameter("body", message.Body);

            if (!string.IsNullOrEmpty(message.MediaUrl))
                request.AddParameter(mediaType, message.MediaUrl);

            if (!string.IsNullOrEmpty(message.Caption))
                request.AddParameter("caption", message.Caption);

            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
