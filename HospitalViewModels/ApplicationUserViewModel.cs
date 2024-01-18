﻿using HospitalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalViewModels
{
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Doctor { get; set; } = new List<ApplicationUser>();
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string Address { get; set; }
        public Gender Gender { get; set; }
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; }


        public ApplicationUserViewModel() { }

        public ApplicationUserViewModel(ApplicationUser user) 
        {
            Name = user.Name;
            Email = user.Email;
            UserName = user.UserName;
            Address = user.Address;
            Gender = user.Gender;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
        
        }

        public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Name = user.Name,
                Address = user.Address,
                Gender = user.Gender,
                IsDoctor = user.IsDoctor,
                Specialist = user.Specialist,
                Email = user.Email,
                UserName = user.UserName,
        };
        }

    }
}
