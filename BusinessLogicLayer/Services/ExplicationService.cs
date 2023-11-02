using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class ExplicationService : Iservice<ExplicationModel>
    {
        private readonly IRepository<ExplicationEntity> _repository;
        public ExplicationService(IRepository<ExplicationEntity> repository) 
        {
            _repository = repository;
        }
        public void Add(ExplicationModel model)
        {
            _repository.Add(model.BllToDal());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ExplicationModel Get(int id)
        {
            return _repository.Get(id).DalToBll();
        }

        public IEnumerable<ExplicationModel> GetAll()
        {
            return _repository.GetAll().Select(item => item.DalToBll());
        }

        public void Update(ExplicationModel model)
        {
            _repository.Update(model.BllToDal());
        }
    }
}
