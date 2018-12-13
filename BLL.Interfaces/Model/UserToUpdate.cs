using System;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Services.Interfaces.Model
{
    public class UserToUpdate
    {
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}