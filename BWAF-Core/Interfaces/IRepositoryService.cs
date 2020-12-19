namespace BWAF_Core.Interfaces
{
    using BWAF_DAL.Repositories.Interfaces;
    using System.Threading.Tasks;
    public interface IRepositoryService
    {
        Task<IRepository> GetRepositoryAsync();
    }
}
