using HospitalUtilites;
using HospitalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices
{
    public interface IDoctorService
    {
        PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<TimingViewModel> GetAll();
        TimingViewModel GetTimingById(int TimingId);
        void UpdateTiming(TimingViewModel Timing);
        void AddTiming(TimingViewModel timing);
        void DeleteTiming(int TimingId);


    }
}
