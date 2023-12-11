using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatroom
{
    public partial class ChatRoomForm : Form
    {

        List<chatList> chatList = new List<chatList>();

        private string LoginData = "Server=192.168.156.7;Database=chatroom;User Id=igor;Password=Database123;";
     
        private string message;
        private string UserName = "Guest";
        private string result;

        public string NewTime;
        public string PreviousTime;

        public ChatRoomForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void ChatRoomForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            Query query = new Query(this);

            message = tbxMessage.Text;

            string messageQuery = "INSERT INTO `chat_data`(`Username`, `Message`) VALUES ('" + UserName + "','" + message + "')";
            result = query.InsertData(LoginData, messageQuery);

            lbxChatbox.Items.Add(UserName + ": " + message);
            //lbxChatbox.Items.Add(result);
            tbxMessage.Clear();
        }

        private void ChatRoomForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("Username.txt"))
            {
                UserName = File.ReadAllText("Username.txt");
            }

            UpdateChat();
        }

        public void DataToList(string username, string message, DateTime datetime)
        {
            chatList.Add(new chatList(username, message, datetime));
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            UserSettingsForm form = new UserSettingsForm(this);
            form.ShowDialog();
        }
        public void SetUsername(string username)
        {
            UserName = username;
        }

        public void UpdateChat()
        {
            lbxChatbox.Items.Clear();

            Query q = new Query(this);

            //get length of table
            string queryrequest = "SELECT count(id) FROM `chat_data`;";
            string result;
            result = q.SendQuery(LoginData, queryrequest);
            int length = Convert.ToInt32(result);

            //copy table to chatlist class
            queryrequest = "SELECT `Username`, `Message`, `DateAndTime` FROM `chat_data`;";
            q.GetChatHistory(LoginData, queryrequest, length);

            //put messages in listbox
            foreach (chatList Message in chatList)
            {
                lbxChatbox.Items.Insert(0, Message.Username.ToString() + ": " + Message.Message.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string Curry = "SELECT `last_update` FROM `innodb_table_stats` WHERE table_name = \"chat_data\";";
            Query q = new Query(this);
            string result = q.SendQuery(LoginData, Curry);
            NewTime = result;

            if (PreviousTime != null & PreviousTime != NewTime)
            {
                UpdateChat();
                PreviousTime = NewTime;
            }
        }
    }
}
