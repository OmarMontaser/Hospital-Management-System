using HospitalUtilites;
using HospitalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageSize, int pageNumber);
        PagedResult<ApplicationUserViewModel> GetAllPatient(int pageSize, int pageNumber);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int pageSize, int pageNumber, string Spicility=null);



    }
}
