﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sport.Models.Entities;

namespace Sport.Models.DTOModels.Users
{
    public class GetAllUsersDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserRoles UserRole { get; set; }
    }
}
