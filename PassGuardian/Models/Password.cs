using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PassGuardian.Models
{
    public class Password
    {
        public int PasswordID { get; set; }
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string ApplicationPassword { get; set; }
        public string KeyPassword { get; set; }
        [Required(ErrorMessage ="Application Name is required.")]
        public string ApplicationName { get; set; }
        public int AppIicationId { get; set; }
        public DateTime LastChange { get; set; } = DateTime.Now;
        public int UserID { get; set; }
    }
}
