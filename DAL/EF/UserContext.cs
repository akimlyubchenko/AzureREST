using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using RESTAPI.DAL.Interfaces.Models;

namespace RESTAPI.DAL.EF
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Server=tcp:rest-server-db.database.windows.net,1433;Initial Catalog=RESTDB;Persist Security Info=False;User ID=Akim;Password=Lyubchenko1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<UserDBModel> Users { get; set; }
        public DbSet<AddressDBModel> Addresses { get; set; }
    }
}