using UserManagement.Application.Logics.Interfaces;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Application.Logics.Implementations
{
    public class UserLogics : IUserLogics
    {
        private readonly WriteAppDbContext _writeContext;

        public UserLogics(WriteAppDbContext writeContext)
        {
            this._writeContext = writeContext;
        }


    }
}
