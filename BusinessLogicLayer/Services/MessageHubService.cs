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
    public class MessageHubService : Iservice<MessageHubModel>
    {
        private readonly IRepository<MessageHubEntity> _repository;
        public MessageHubService(IRepository<MessageHubEntity> repository) 
        {
            _repository = repository;
        }
        public void Add(MessageHubModel model)
        {
            _repository.Add(model.BllToDal());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public MessageHubModel Get(int id)
        {
            return _repository.Get(id).DalToBll();
        }

        public IEnumerable<MessageHubModel> GetAll()
        {
            return _repository.GetAll().Select(item => new MessageHubModel());
        }

        public void Update(MessageHubModel model)
        {
            _repository.Update(model.BllToDal());
        }
    }
}
