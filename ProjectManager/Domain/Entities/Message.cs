using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectManager
{
    public partial class Message
    {
   
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public Chat chat { get; set; }
        public string Text { get; set; }
        public DateTime? Datetime { get; set; }
    }
}
