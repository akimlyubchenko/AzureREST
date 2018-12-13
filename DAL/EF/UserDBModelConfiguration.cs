using System.Data.Entity.ModelConfiguration;
using RESTAPI.DAL.Interfaces.Models;

namespace RESTAPI.DAL.EF
{
    public class UserDBModelConfiguration : EntityTypeConfiguration<UserDBModel>
    {
        public UserDBModelConfiguration()
        {
            //ToTable("UserDBModels");
            //HasKey(user => user.Login);
            //Property(user => user.FirstName).IsRequired().IsUnicode().HasMaxLength(15).IsVariableLength();
            //Property(user => user.FirstName).IsRequired().IsUnicode().HasMaxLength(20).IsVariableLength();
            //Property(user => user.DateOfBirth).IsRequired();
            //Property(user => user.Login).IsRequired();
            //Property(user => user.Password).IsRequired();
            //HasMany(user => user.Addresses).WithRequired(user => user.UserDbModel);
        }
    }
}