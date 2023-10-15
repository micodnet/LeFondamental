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
    public class FormationService : Iservice<FormationModel>
    {
        private readonly IRepository<FormationEntity> _formationRepository;
        public FormationService(IRepository<FormationEntity> repository) 
        {
            _formationRepository = repository;
        }
        public void Add(FormationModel model)
        {
            _formationRepository.Add(model.BllToDal());
        }

        public void Delete(int id)
        {
            _formationRepository.Delete(id);
        }

        public FormationModel Get(int id)
        {
            return _formationRepository.Get(id).DalToBll();
        }

        public IEnumerable<FormationModel> GetAll()
        {
            return _formationRepository.GetAll().Select(item => new FormationModel());
        }

        public void Update(FormationModel model)
        {
            _formationRepository.Update(model.BllToDal());
        }
    }
}
