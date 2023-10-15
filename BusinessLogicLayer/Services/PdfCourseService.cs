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
    public class PdfCourseService : Iservice<PdfCourseModel>
    {
        private readonly IRepository<PdfCourseEntity> _repository;
        public PdfCourseService(IRepository<PdfCourseEntity> repository)
        {
            _repository = repository;
        }
        public void Add(PdfCourseModel model)
        {
            _repository.Add(model.BllToDal());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public PdfCourseModel Get(int id)
        {
            return _repository.Get(id).DalToBll();
        }

        public IEnumerable<PdfCourseModel> GetAll()
        {
            return _repository.GetAll().Select(item => new PdfCourseModel());
        }

        public void Update(PdfCourseModel model)
        {
            _repository.Update(model.BllToDal());
        }
    }
}
