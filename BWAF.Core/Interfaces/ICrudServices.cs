namespace BWAF.Core.Interfaces
{
    using BWAF.Core.ViewModels;
    using BWAF.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICrudServices
    {
        Task<IEnumerable<Entity>> GetAll();

        Task Delete(long id);

        Task Update(EntityViewModel entityViewModel);

        Task Create(EntityViewModel entityViewModel);
    }
}
