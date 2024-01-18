using HospitalModels;
using HospitalRepositories.Interfaces;
using HospitalUtilites;
using HospitalViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices
{
    public class HospitalInfoService : IHospitalInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHospitalInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(id);
            _unitOfWork.GenericRepository<Hospital>().Delete(model);
            _unitOfWork.Save();
        }

        public IEnumerable GetAll()
        {
            return _unitOfWork.GenericRepository<Hospital>().GetAll().ToList(); 
        }


        public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            var va = new HospitalInfoViewModel();
            int totalCount;
            List<HospitalInfoViewModel> vmList = new List<HospitalInfoViewModel>();
            try
            {
                int ExcludeRecord = (pageNumber * pageSize) - pageSize;
                var modeList = _unitOfWork.GenericRepository<Hospital>().GetAll()
                        .Skip(ExcludeRecord).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Hospital>()
                            .GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modeList);


            }
            catch (Exception)
            {
                throw; 
            }
            var result = new PagedResult<HospitalInfoViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result; 
        }

        public HospitalInfoViewModel GetHospitalById(int HospitalId)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(HospitalId);
            var vm = new HospitalInfoViewModel(model);
            return vm;
        }

        public void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
            _unitOfWork.GenericRepository<Hospital>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
            var ModelById = _unitOfWork.GenericRepository<Hospital>().GetById(model.Id);

            ModelById.Name = hospitalInfo.Name;
            ModelById.PinCode = hospitalInfo.PinCode;
            ModelById.Country = hospitalInfo.Country;
            _unitOfWork.GenericRepository<Hospital>().update(ModelById);
            _unitOfWork.Save();
        }

        
        private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<Hospital> modeList)
        {
            return modeList.Select(x=> new HospitalInfoViewModel(x)).ToList();
        }
    }
}
