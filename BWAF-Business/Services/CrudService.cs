﻿namespace BWAF_Business.Services
{
    using AutoMapper;
    using BWAF_Core.Interfaces;
    using BWAF_Core.ViewModels;
    using BWAF_DAL.Models;
    using BWAF_DAL.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CrudService : ICrudServices
    {
        private IRepositoryService repositoryService;
        private IMapper mapper;
        public CrudService(IRepositoryService repositoryService, IMapper mapper)
        {
            this.repositoryService = repositoryService;
            this.mapper = mapper;
        }

        public async Task Create(EntityViewModel entityViewModel)
        {
            IRepository repository = await repositoryService.GetRepositoryAsync();

            Entity entity = mapper.Map<Entity>(entityViewModel);

            repository.Create<Entity>(entity);
            await repository.SaveAsync();
        }

        public async Task Delete(EntityViewModel entityViewModel)
        {
            IRepository repository = await repositoryService.GetRepositoryAsync();

            repository.Delete<Entity>(entityViewModel.Id);
            await repository.SaveAsync();
        }

        public async Task Update(EntityViewModel entityViewModel)
        {
            IRepository repository = await repositoryService.GetRepositoryAsync();

            Entity entity = mapper.Map<Entity>(entityViewModel);

            repository.Update<Entity>(entity);
            await repository.SaveAsync();
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            IRepository repository = await repositoryService.GetRepositoryAsync();

            return await repository.GetAllAsync<Entity>();
        }
    }
}
