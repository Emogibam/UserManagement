using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Context;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.DBConnections.Interfaces;

namespace UserManagement.Infrastructure.DBConnections.Implementations;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _context;

    public IRepository<User> Users { get; }
    public IRepository<UserRole> UserRoles { get; }
    public IRepository<UserPermission> UserPermissions { get; }
    public IRepository<UserPasswordHistory> UserPasswordHistories { get; }

    public UnitOfWork(AppDBContext context)
    {
        _context = context;
        Users = new Repository<User>(_context);
        UserRoles = new Repository<UserRole>(_context);
        UserPermissions = new Repository<UserPermission>(_context);
        UserPasswordHistories = new Repository<UserPasswordHistory>(_context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
