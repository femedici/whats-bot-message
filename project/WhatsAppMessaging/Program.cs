using System;
using System.Threading.Tasks;
using WhatsAppMessaging.Services;
using WhatsAppMessaging.Models;
using DotNetEnv;

namespace WhatsAppMessaging
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new WhatsAppService();
            Env.Load();

            // Envio de texto
            var textMessage = new Message
            {
                To = Env.GetString("PHONE_NUMBER"),
                Body = Env.GetString("MESSAGE_TEXT")
            };

            var textResponse = await service.SendMessageAsync(textMessage);
            Console.WriteLine($"Resposta de texto: {textResponse}");

            // // Consultar grupos
            // Console.WriteLine("Consultando grupos...");
            // var groupsResponse = await service.GetGroupsAsync();
            // Console.WriteLine($"Grupos encontrados: {groupsResponse}");


            // Envio de mídia (exemplo: imagem)
            var mediaMessage = new Message
            {
                To = Env.GetString("PHONE_NUMBER"),
                MediaUrl = Env.GetString("IMG_URL"),
                Caption = Env.GetString("IMG_TEXT")
            };

            var mediaResponse = await service.SendMediaMessageAsync(mediaMessage, "image");
            Console.WriteLine($"Resposta de mídia: {mediaResponse}");

            var audioMessage = new Message
            {
                To = Env.GetString("PHONE_NUMBER"),
                AudioUrl = "https://file-example.s3-accelerate.amazonaws.com/voice/oog_example.ogg"
            };

            var audioResponse = await service.SendAudioAsync(audioMessage, "audio");
            Console.WriteLine($"Resposta do envio de áudio: {audioResponse}");
        }
    }
}
