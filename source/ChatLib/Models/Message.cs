using System;
using System.ComponentModel.DataAnnotations;

namespace ChatLib.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Sent { get; set; }
        public DateTime Edited { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
