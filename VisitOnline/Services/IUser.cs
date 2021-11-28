﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;

namespace VisitOnline.Services
{
    public interface IUser
    {
        
       // Sick GetSick(string username);

        int GetMaxRole();

        void UpdateDoctor(DoctorViewModel models  , string username);
        string GetUserRoleName(string username);
        Doctor GetDoctor(string username);
        string GetUserStatus(string username);

        Sick GetSick(string username);

        void UpdateSick(SickviewModels models, string username);


        List<VisitRequest> GetVisitList();

        void AddRequestVisit(RequestVisitModel model);

        List<Doctor> GetListDoctor(string category);

    }
}
