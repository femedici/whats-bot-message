using System;
using System.Threading.Tasks;
using WhatsAppMessaging.Services;
using WhatsAppMessaging.Models;
using DotNetEnv;
using System.Windows.Forms;
using WhatsAppMessaging.UI;
using WhatsAppMessaging.Controllers;

namespace WhatsAppMessaging
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            var controller = new WhatsAppController();
            await controller.ExecuteMessagesAsync();
        }
    }
}
