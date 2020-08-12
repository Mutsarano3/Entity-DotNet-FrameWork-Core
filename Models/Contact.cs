using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet5_application.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Place { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool isDeleted { get; set; } = false;
    }
}
