namespace WhatsAppMessaging.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxMessageType;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSend;

        private void InitializeComponent()
        {
            this.comboBoxMessageType = new System.Windows.Forms.ComboBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ComboBox
            this.comboBoxMessageType.FormattingEnabled = true;
            this.comboBoxMessageType.Items.AddRange(new object[] {
                "Texto",
                "Imagem",
                "Áudio",
                "Documento"});
            this.comboBoxMessageType.Location = new System.Drawing.Point(12, 12);
            this.comboBoxMessageType.Name = "comboBoxMessageType";
            this.comboBoxMessageType.Size = new System.Drawing.Size(260, 23);
            this.comboBoxMessageType.TabIndex = 0;

            // TextBox
            this.textBoxMessage.Location = new System.Drawing.Point(12, 50);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(260, 23);
            this.textBoxMessage.TabIndex = 1;

            // Button
            this.buttonSend.Location = new System.Drawing.Point(12, 90);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(260, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Enviar";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.comboBoxMessageType);
            this.Name = "MainForm";
            this.Text = "WhatsApp Messaging";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
