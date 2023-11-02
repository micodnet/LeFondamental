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
    public class RoleService : Iservice<RoleModel>
    {
        private readonly IRepository<RoleEntity> _roleRepository;
        public RoleService(IRepository<RoleEntity> repository) 
        {
            _roleRepository = repository;
        }
        public void Add(RoleModel model)
        {
            _roleRepository.Add(model.BllToDal());
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

        public RoleModel Get(int id)
        {
            return _roleRepository.Get(id).DalToBll();
        }

        public IEnumerable<RoleModel> GetAll()
        {
            return _roleRepository.GetAll().Select(item => item.DalToBll());
        }

        public void Update(RoleModel model)
        {
            _roleRepository.Update(model.BllToDal());
        }
    }
}
