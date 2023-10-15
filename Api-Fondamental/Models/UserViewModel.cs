﻿namespace Api_Fondamental.Models
{
    public class UserViewModel
    {
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}