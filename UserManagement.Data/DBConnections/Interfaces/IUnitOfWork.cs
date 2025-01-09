using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.DBConnections.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<UserPermission> UserPermissions { get; }
    IRepository<UserPasswordHistory> UserPasswordHistories { get; }
    Task<int> SaveChangesAsync();
}

