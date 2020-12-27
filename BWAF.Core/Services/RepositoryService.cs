namespace BWAF.Core.Services
{
    using BWAF.Core.Interfaces;
    using BWAF.Data;
    using BWAF.Data.Repositories.Interfaces;
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
