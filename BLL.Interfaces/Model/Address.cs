using System.ComponentModel.DataAnnotations;
using RESTAPI.DAL.Interfaces.Models;

namespace RESTAPI.Services.Interfaces.Model
{
    public class Address
    {
        [StringLength(30)]
        public string AddressType { get; set; } = DAL.Interfaces.Models.AddressType.HomeAddress.ToString();

        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(30)]
        public string Street { get; set; }

        [Range(1, 1000)]
        public int Building { get; set; }

        [Range(1, 10000)]
        public int Room { get; set; }
    }
}