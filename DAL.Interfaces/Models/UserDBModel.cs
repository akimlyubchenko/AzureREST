using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI.DAL.Interfaces.Models
{
    public class UserDBModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Key]
        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<AddressDBModel> Addresses { get; set; }
    }
}