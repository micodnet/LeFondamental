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
    public class StudentService: Iservice<StudentModel>
    {
        private readonly IRepository<StudentEntity> _repository;
        public StudentService(IRepository<StudentEntity> repository) 
        {
            _repository = repository;
        }

        public void Add(StudentModel model)
        {
            _repository.Add(model.BllToDal());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public StudentModel Get(int id)
        {
            return _repository.Get(id).DalToBll();
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return _repository.GetAll().Select(er => er.DalToBll());
        }

        public void Update(StudentModel model)
        {
            _repository.Update(model.BllToDal());
        }
    }
}
