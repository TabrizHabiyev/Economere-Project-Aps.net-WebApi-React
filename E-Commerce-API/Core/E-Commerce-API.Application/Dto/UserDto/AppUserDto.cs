﻿
using E_Commerce_API.Application.Dto.Basket;

namespace E_Commerce_API.Application.Dto.UserDto
{
    public class AppUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public BasketDto Basket { get; set; }
    }
}
