using APIRHIU.Data.Context;
using APIRHIU.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace APIRHIU.Data.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApirhiuContext _context;

        public UnityOfWork(ApirhiuContext context)
        {
            _context = context;
        }

        async Task<bool> IUnityOfWork.Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
