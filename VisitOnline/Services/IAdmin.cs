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
        //#region For Permission

        //void InsertPermission(Permission permission);

        //void UpdatePermission(int id, string name);

        //void DeletePermission(int id);

        //List<Permission> GetPermissions();

        //Permission GetPermission(int id);

        //#endregion
    }
}
