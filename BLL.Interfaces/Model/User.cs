using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Services.Interfaces.Model
{
    public class User
    {
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Key]
        [StringLength(30)]
        public string Login { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }
    }
}