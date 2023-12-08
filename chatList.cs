using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatroom
{
    internal class chatList
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

            public chatList(string _username, string _message, DateTime _dateTime)
        {
            Username = _username;
            Message = _message;
            DateTime = _dateTime;
        }
    }
}
