using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practiceApi.Dtos;
using practiceApi.Models;

namespace practiceApi.DtoMapper
{
    public static class UserMapper
    {
        public static User ToRegisterUser (this RegisterUserDto dataModal) {
            return new User {
                name = dataModal.name,
                email = dataModal.email,
                password = dataModal.password,
            };
        }

        public static User ToUserData (this User dataModal) {
            return new User {
                id = dataModal.id,
                name = dataModal.name,
                email = dataModal.email,
                createdAt = dataModal.createdAt,
            };
        }

        public static User ToLoginUser (this LoginUserDto dataModal) {
            return new User {
                email = dataModal.email,
                password = dataModal.password,
            };
        }
    }
}