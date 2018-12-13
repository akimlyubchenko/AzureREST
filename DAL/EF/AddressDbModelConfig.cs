using System.Data.Entity.ModelConfiguration;
using RESTAPI.DAL.Interfaces.Models;

namespace RESTAPI.DAL.EF
{
    public class AddressDbModelConfig : EntityTypeConfiguration<AddressDBModel>
    {
        public AddressDbModelConfig()
        {
            //ToTable("AddressDBModels");
            //HasKey(address => address.AddressId);
            //Property(address => address.Country).HasMaxLength(35);
            //Property(address => address.City).HasMaxLength(35);
            //Property(address => address.Street).HasMaxLength(50);
            //HasRequired(address => address.UserDbModel).WithMany(user => user.Addresses)
            //    .HasForeignKey(address => address.UserDBModelId);
        }
    }
}