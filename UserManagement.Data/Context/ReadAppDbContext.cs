using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Context;

namespace UserManagement.Infrastructure.Context
{
    public class ReadAppDbContext : AppDBContext
    {
        
        public ReadAppDbContext(DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
