using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ProjectManager
{
    public partial class Message
    {

        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey("Chat")]
        public virtual Guid Chatid { get; set; }
        public string Text { get; set; }
        public DateTime? Datetime { get; set; }
    }
}
