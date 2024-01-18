using HospitalUtilites;
using HospitalViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices
{
    public interface IHospitalInfo
    {
        PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable GetAll();
        HospitalInfoViewModel GetHospitalById(int HospitalId);
        void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo);
        void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo);
        void DeleteHospitalInfo(int id);
    }
}
