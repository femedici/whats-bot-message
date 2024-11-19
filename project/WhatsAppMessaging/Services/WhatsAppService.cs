using RestSharp;
using System.Threading.Tasks;
using WhatsAppMessaging.Utils;
using WhatsAppMessaging.Models;

namespace WhatsAppMessaging.Services
{
    public class WhatsAppService
    {
        public async Task<string> SendMessageAsync(WhatsMessage message)
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

        public async Task<string> SendMediaMessageAsync(WhatsMessage message, string mediaType)
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

        public async Task<string> SendLocationAsync(WhatsMessage message)
        {
            var url = $"{Config.BaseUrl}{Config.InstanceId}/messages/location";
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post);

            // Configurar os headers e parâmetros
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("token", Config.Token, ParameterType.GetOrPost);
            request.AddParameter("to", message.To, ParameterType.GetOrPost);
            request.AddParameter("address", message.Address, ParameterType.GetOrPost);
            request.AddParameter("lat", message.Lat, ParameterType.GetOrPost);
            request.AddParameter("lng", message.Lng, ParameterType.GetOrPost);

            // Executar a requisição
            var response = await client.ExecuteAsync(request);
            return response.Content ?? string.Empty;
        }


        public async Task<string> SendAudioAsync(WhatsMessage message, string mediaType)
        {
            var url = $"{Config.BaseUrl}{Config.InstanceId}/messages/{mediaType}";
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post);

            // Configurar os headers e parâmetros
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("token", Config.Token, ParameterType.GetOrPost);
            request.AddParameter("to", message.To, ParameterType.GetOrPost);
            request.AddParameter(mediaType, message.AudioUrl, ParameterType.GetOrPost);

            // Executar a requisição
            var response = await client.ExecuteAsync(request);
            return response.Content ?? string.Empty;
        }


        public async Task<string> SendVideoAsync(WhatsMessage message, string mediaType)
        {
            var url = $"{Config.BaseUrl}{Config.InstanceId}/messages/{mediaType}";
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post);

            // Configurar os headers e parâmetros
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("token", Config.Token, ParameterType.GetOrPost);
            request.AddParameter("to", message.To, ParameterType.GetOrPost);
            request.AddParameter(mediaType, message.VideoUrl, ParameterType.GetOrPost);
			request.AddParameter("caption", message.Caption, ParameterType.GetOrPost);

            var response = await client.ExecuteAsync(request);
            return response.Content ?? string.Empty;
        }

        //Listar Grupos
        public async Task<string> GetGroupsAsync()
        {
            var url = $"{Config.BaseUrl}{Config.InstanceId}/groups";
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);

            request.AddParameter("token", Config.Token, ParameterType.QueryString);

            try
            {
                var response = await client.ExecuteAsync(request);
                if (response == null || response.Content == null)
                    throw new InvalidOperationException("A resposta da API foi nula.");

                return response.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar grupos: {ex.Message}");
                throw;
            }
        }
    }
}
