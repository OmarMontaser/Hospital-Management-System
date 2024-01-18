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
    public class RoomService : IRoom
    {
        private IUnitOfWork _unitOfWork ;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();
        }


        public PagedResult<RoomViewModel> GetAll(int PageNumber, int PageSize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmList = new List<RoomViewModel>();
            try
            {
                int excludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties:"Hospital")
                            .Skip(excludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Room>()
                       .GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<RoomViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize,
            };
            return result;
        }

        public RoomViewModel GetRoomById(int RoomId)
        {

            var model = _unitOfWork.GenericRepository<Room>().GetById(RoomId);
            var vm = new RoomViewModel(model);
            return vm;
        }

        public void InsertRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConvertViewModel(Room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save(); 
        }

        public void UpdateRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConvertViewModel(Room);
            var modelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
            modelById.Type = Room.Type;
            modelById.RoomNumber = Room.RoomNumber;
            modelById.Status = Room.Status;

            _unitOfWork.GenericRepository<Room>().update(modelById);
            _unitOfWork.Save();
        }


        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModel(x)).ToList();
        }

    }
}
