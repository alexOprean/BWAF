namespace BWAF_Core.Services
{
    using BWAF_Core.Interfaces;
    using BWAF_DAL;
    using BWAF_DAL.Repositories.Interfaces;
    using System.Threading.Tasks;

    public class RepositoryService : IRepositoryService
    {
        private Context dBContext;

        public RepositoryService(Context dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IRepository> GetRepositoryAsync()
        {
            return await Task.FromResult(new ApplicationRepository(this.dBContext));
        }
    }
}
