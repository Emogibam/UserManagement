using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Data.Context
{
    public abstract class AppDBContext : DbContext
    {
        private readonly string connectionString;

        protected AppDBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserPasswordHistory> UserPasswordHistorys { get; set; }

    }
}
