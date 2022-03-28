using backend_user_registration.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_user_registration.Data
{
    public class UserRegistrationContext : DbContext
    {

        public UserRegistrationContext(DbContextOptions<UserRegistrationContext> options) : base (options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=user_registration;user=root;password=123456";
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new System.Version(8, 0, 22)));
        }

    }
}
