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
                To = "554497192500",
                Body = "Mensagem totalmente epica da API do felipe M3D1C1!"
            };

            var textResponse = await service.SendMessageAsync(textMessage);
            Console.WriteLine($"Resposta de texto: {textResponse}");

            // Envio de mídia (exemplo: imagem)
            var mediaMessage = new Message
            {
                To = "554497192500",
                MediaUrl = "https://pbs.twimg.com/card_img/1857634781670027264/4uc2vk85?format=jpg&name=large",
                Caption = "Imagem do FELIPE MEDICI"
            };

            var mediaResponse = await service.SendMediaMessageAsync(mediaMessage, "image");
            Console.WriteLine($"Resposta de mídia: {mediaResponse}");
        }
    }
}
