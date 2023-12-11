namespace chatroom
{
    partial class ChatRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbxChatbox = new System.Windows.Forms.ListBox();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbxChatbox
            // 
            this.lbxChatbox.FormattingEnabled = true;
            this.lbxChatbox.ItemHeight = 16;
            this.lbxChatbox.Location = new System.Drawing.Point(12, 12);
            this.lbxChatbox.Name = "lbxChatbox";
            this.lbxChatbox.Size = new System.Drawing.Size(774, 468);
            this.lbxChatbox.TabIndex = 0;
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(12, 495);
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(774, 22);
            this.tbxMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(792, 495);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(115, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(792, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(115, 23);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "User Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ChatRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 529);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.lbxChatbox);
            this.Name = "ChatRoomForm";
            this.Text = "Chatroom";
            this.Load += new System.EventHandler(this.ChatRoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxChatbox;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer timer1;
    }
}

