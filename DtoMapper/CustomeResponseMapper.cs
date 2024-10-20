using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using practiceApi.Dtos;

namespace practiceApi.DtoMapper
{
    public static class CustomeResponseMapper
    {
        public static object ToCustomeResponse(string message, string status, int statusCode, object? dataModel = null) {
            return new {
                message = message,
                statusCode = statusCode,
                data = dataModel,
                status = status
            };
        }
    }
}