﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;

namespace VisitOnline.Services
{
    public interface IAdmin
    {
        List<SickviewModels> GetListSick();
        List<DoctorViewModel> GetDoctorsList();
        void ActiveAccDoc(int id);
        void InsertTiket(TiketModel model);

        List<Tiket> ListTike(string username);
        List<Tiket> AllListTikets();
        //#region For Permission

        //void InsertPermission(Permission permission);

        //void UpdatePermission(int id, string name);

        //void DeletePermission(int id);

        //List<Permission> GetPermissions();

        //Permission GetPermission(int id);

        //#endregion
    }
}
