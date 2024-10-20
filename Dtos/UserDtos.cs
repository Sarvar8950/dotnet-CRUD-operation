using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practiceApi.Dtos
{
    public class RegisterUserDto
    {
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

    }

    public class LoginUserDto
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

    }
}