using System;
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
        string GetUserNameFamily(string username);
        Doctor GetDoctor(string username);
        string GetTakhasos(int id);
        string GetUserStatus(string username);

        Sick GetSick(string username);

        void UpdateSick(SickviewModels models, string username);


        List<VisitRequest> GetVisitList();

     

        List<DoctorViewModel> GetListDoctor(int category);

        void AddRequsetVisit(RequestVisitModel request , string username);

        List<RequestVisitModel> GetListReViDoc(string username);
        List<RequestVisitModel> GetListReViSick(string username);

        RequestVisitModel GetRequsetDataDoc(int NoskheId , string username);
        RequestVisitModel GetRequsetDataSick(int NoskheId , string username);

        void UpdateRequsetVisit(RequestVisitModel model, string username);

    }
}
