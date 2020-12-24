namespace BWAF_Core.Interfaces
{
    using BWAF_Core.ViewModels;
    using BWAF_DAL.Models;
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
