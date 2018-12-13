using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.DAL.Interfaces.Models
{
    public class AddressDBModel
    {
        [Key]
        public int Id { get; set; }

        public string UserDbModelId { get; set; }

        public virtual UserDBModel UserDBModel { get; set; }

        public AddressType AddressType { get; set; } = AddressType.HomeAddress;

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int Building { get; set; }

        public int Room { get; set; }
    }
}