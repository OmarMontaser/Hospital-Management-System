using HospitalRepositories.Interfaces;
using HospitalUtilites;
using HospitalViewModels;
using HospitalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices
{
    public class ApplictionUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplictionUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public PagedResult<ApplicationUserViewModel> GetAll(int pageSize, int pageNumber)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().Count();

                vmList = ConvertModelToViewModel(modelList);

            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
            };
            return result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageSize, int pageNumber)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true)
                                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).Count();

                vmList = ConvertModelToViewModel(modelList);

            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
            };
            return result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int pageSize, int pageNumber, string Spicility = null)
        {
            throw new NotImplementedException();
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModel(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();

        }

    }
}
