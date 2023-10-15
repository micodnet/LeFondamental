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
    public class CourseService: Iservice<CourseModel>
    {
        private readonly IRepository<CourseEntity> _courseRepository;
        public CourseService(IRepository<CourseEntity> repository)
        {
            _courseRepository = repository;
        }

        public void Add(CourseModel model)
        {
            _courseRepository.Add(model.BllToDal());
        }

        public void Delete(int id)
        {
            _courseRepository.Delete(id);
        }

        public CourseModel Get(int id)
        {
            return _courseRepository.Get(id).DalToBll();
        }

        public IEnumerable<CourseModel> GetAll()
        {
            return _courseRepository.GetAll().Select(item => new CourseModel());
            

        }

        public void Update(CourseModel model)
        {
            _courseRepository.Update(model.BllToDal());
        }
    }
}
