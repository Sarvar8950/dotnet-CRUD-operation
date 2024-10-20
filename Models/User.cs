using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practiceApi.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}