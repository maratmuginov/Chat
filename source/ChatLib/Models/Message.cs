using System;

namespace ChatLib.Models
{
    public class Message
    {
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime Sent { get; set; }
    }
}
