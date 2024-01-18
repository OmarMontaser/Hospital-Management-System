﻿using HospitalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalViewModels
{
    public class HospitalInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }


        public HospitalInfoViewModel()
        {
        }
        public HospitalInfoViewModel(Hospital model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;
        }
        public Hospital ConvertViewModel(HospitalInfoViewModel model)
        {
            return new Hospital
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country
            };
        }



    }
}
