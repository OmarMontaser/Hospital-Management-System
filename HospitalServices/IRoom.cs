using HospitalUtilites;
using HospitalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices
{
    public interface IRoom
    {
        PagedResult<RoomViewModel> GetAll(int PageNumber, int PageSize);
        RoomViewModel GetRoomById(int RoomId);
        void UpdateRoom(RoomViewModel Room);
        void InsertRoom(RoomViewModel Room);
        void DeleteRoom(int id);
    }
}
