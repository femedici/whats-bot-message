using System;
using System.Windows.Forms;

namespace WhatsAppMessaging.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            // Obter os valores selecionados/digitados
            string selectedType = comboBoxMessageType.SelectedItem?.ToString();
            string messageText = textBoxMessage.Text;

            // Exibir no console para testes
            Console.WriteLine($"Tipo selecionado: {selectedType}");
            Console.WriteLine($"Mensagem digitada: {messageText}");

            // Aqui você pode integrar com o serviço WhatsAppService
            MessageBox.Show($"Mensagem '{messageText}' do tipo '{selectedType}' capturada!");
        }
    }
}
