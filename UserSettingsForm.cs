using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace chatroom
{
    public partial class UserSettingsForm : Form
    {
        ChatRoomForm chatRoomFormRef;
        public UserSettingsForm(ChatRoomForm _chatRoomFormRef)
        {
            InitializeComponent();
            chatRoomFormRef = _chatRoomFormRef;
        }

        private void UserSettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Username.txt", tbxUsername.Text);
            chatRoomFormRef.SetUsername(tbxUsername.Text);
            Close();
        }
    }
}
