using HospitalModels;
using HospitalRepositories.Interfaces;
using HospitalUtilites;
using HospitalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices
{
    public class ContactService : IContactService
    {
        private  IUnitOfWork _unitofwork;

        public ContactService(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void DeleteContact(int id)
        {
            var model = _unitofwork.GenericRepository<Contact>().GetById(id);
            _unitofwork.GenericRepository<Contact>().Delete(model);
            _unitofwork.Save();
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            List<ContactViewModel> vmList = new List<ContactViewModel>();
            try
            {
                int excludeRecord = (pageNumber * pageSize) - pageSize;
                var modelList = _unitofwork.GenericRepository<Contact>().GetAll(includeProperties:"Hospital")
                                .Skip(excludeRecord).Take(pageSize).ToList();

                totalCount = _unitofwork.GenericRepository<Contact>().GetAll().ToList().Count;

                vmList = ConvertModeltoViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ContactViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result; 
        }

        public ContactViewModel GetContactById(int ContactId)
        {
            var model = _unitofwork.GenericRepository<Contact>().GetById(ContactId);
            var vm = new ContactViewModel(model);
            return vm; 
        }

        public void InsertContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);
            _unitofwork.GenericRepository<Contact>().Add(model);
            _unitofwork.Save();
        }

        public void UpdateContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);
            var modelById = _unitofwork.GenericRepository<Contact>().GetById(model.Id);
            modelById.Phone = contact.Phone;
            modelById.Email = contact.Email;
            modelById.HospialId = contact.HospitalInfoId;
        }

        private List<ContactViewModel> ConvertModeltoViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }

    }
}
