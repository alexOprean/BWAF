namespace BWAF.Core.Interfaces
{
    using BWAF.Data.Repositories.Interfaces;
    using System.Threading.Tasks;
    public interface IRepositoryService
    {
        Task<IRepository> GetRepositoryAsync();
    }
}
