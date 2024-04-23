using System.Diagnostics;

namespace APIRHIU.Domain.Interfaces
{
    public interface IUnityOfWork 
    {
        Task<bool> Commit();
    }
}
