using System;
using System.Threading.Tasks;
using WhatsAppMessaging.Services;
using WhatsAppMessaging.Models;

namespace WhatsAppMessaging
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new WhatsAppService();

            // Envio de texto
            var textMessage = new Message
            {
                To = "14155552671",
                Body = "Mensagem de teste via API WhatsApp"
            };

            var textResponse = await service.SendMessageAsync(textMessage);
            Console.WriteLine($"Resposta de texto: {textResponse}");

            // Envio de mídia (exemplo: imagem)
            var mediaMessage = new Message
            {
                To = "14155552671",
                MediaUrl = "https://file-example.s3-accelerate.amazonaws.com/images/test.jpg",
                Caption = "Imagem de teste"
            };

            var mediaResponse = await service.SendMediaMessageAsync(mediaMessage, "image");
            Console.WriteLine($"Resposta de mídia: {mediaResponse}");
        }
    }
}
