using System;
using System.Threading.Tasks;
using WhatsAppMessaging.Services;
using WhatsAppMessaging.Models;
using DotNetEnv;

namespace WhatsAppMessaging.Controllers
{
    public class WhatsAppController
    {
        private readonly WhatsAppService _service;

        public WhatsAppController()
        {
            _service = new WhatsAppService();
            Env.Load(); // Carregar variáveis de ambiente
        }

        public async Task ExecuteMessagesAsync()
        {
            try
            {
                // Envio de texto
                var textMessage = new WhatsMessage
                {
                    To = Env.GetString("PHONE_NUMBER"),
                    Body = Env.GetString("MESSAGE_TEXT")
                };

                var textResponse = await _service.SendMessageAsync(textMessage);
                Console.WriteLine($"Resposta de texto: {textResponse}");

                // Envio de localização
                var locationMessage = new WhatsMessage
                {
                    To = Env.GetString("PHONE_NUMBER"),
                    Address = Env.GetString("ADDRESS"),
                    Lat = "25.197197",
                    Lng = "55.2721877"
                };

                var locationResponse = await _service.SendLocationAsync(locationMessage);
                Console.WriteLine($"Resposta de localização: {locationResponse}");

                // Consultar grupos
                Console.WriteLine("Consultando grupos...");
                var groupsResponse = await _service.GetGroupsAsync();
                Console.WriteLine($"Grupos encontrados: {groupsResponse}");

                // Envio de mídia (imagem)
                var mediaMessage = new WhatsMessage
                {
                    To = Env.GetString("PHONE_NUMBER"),
                    MediaUrl = Env.GetString("IMG_URL"),
                    Caption = Env.GetString("IMG_TEXT")
                };

                var mediaResponse = await _service.SendMediaMessageAsync(mediaMessage, "image");
                Console.WriteLine($"Resposta de mídia: {mediaResponse}");

                // Envio de áudio
                var audioMessage = new WhatsMessage
                {
                    To = Env.GetString("PHONE_NUMBER"),
                    AudioUrl = "https://file-example.s3-accelerate.amazonaws.com/voice/oog_example.ogg"
                };

                var audioResponse = await _service.SendAudioAsync(audioMessage, "audio");
                Console.WriteLine($"Resposta do envio de áudio: {audioResponse}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
