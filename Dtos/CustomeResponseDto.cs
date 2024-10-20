using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practiceApi.Dtos
{
    public class CustomeResponseDto
    {
        public string message { get; set; } = string.Empty;
        public string status  { get; set; } = string.Empty;
        public object? data { get; set; } = null;
        public int statusCode { get; set; }

    }
}