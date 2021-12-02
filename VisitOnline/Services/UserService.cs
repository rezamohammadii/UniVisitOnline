﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitOnline.Database;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;

namespace VisitOnline.Services
{
    public class UserService : IUser
    {
        private DatabaseContext context;
        private PersianCalendar pc = new PersianCalendar();
        public UserService(DatabaseContext _context)
        {
            context = _context;
        }

    

        public void AddRequsetVisit(RequestVisitModel request, string username)
        {
            Sick sick = GetSick(username);
            VisitRequest visit = new VisitRequest()
            {
                DoctorId = int.Parse(request.SelectDoctor),
                NumberNoskhe = int.Parse(request.NumberNoskhe),
                SickId = sick.SickId,
                Description = request.Description,
                Status = "waiting",
                Title = request.Title,
                Date = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") +
                             "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00")
            };
            context.VisitRequests.Add(visit);
            context.SaveChanges();
        }

        public Doctor GetDoctor(string username)
        {
            return context.Doctors.Include(x => x.User).FirstOrDefault(u => u.User.Mobile == username);
        }

        public List<DoctorViewModel> GetListDoctor(int Id)
        {
            List<DoctorViewModel> doctors = new List<DoctorViewModel>();
            string getTakhasos = GetTakhasos(Id);
            doctors = context.Doctors.Include(u=>u.User).Where(x => x.Takhasos == getTakhasos).Select(x=> new DoctorViewModel{AddressMatab = x.AddressMatab ,NameFamily = x.User.NameFamily , Takhasos = x.Takhasos , Rate = x.Rate , DoctorId = x.DoctorId , TelMatab = x.TelMatab}).ToList();
            return doctors;
        }

        public List<RequestVisitModel> GetListReViDoc(string username)
        {
            List<RequestVisitModel> requests = new List<RequestVisitModel>();
            int getDocId = context.Doctors.Include(x => x.User).FirstOrDefault(u => u.User.Mobile == username).DoctorId;
            
            requests = context.VisitRequests.Where(x => x.DoctorId == getDocId).Select(r => new RequestVisitModel { Description = r.Description, NumberNoskhe = r.NumberNoskhe.ToString(), Title = r.Title, MobileSick = r.SickId.ToString(), NameSick = r.SickId.ToString() , Status = r.Status , Date = r.Date}).ToList();
            foreach (var item in requests)
            {
                var getUsr = context.Sick.Include(x=>x.User).Where(u => u.SickId == int.Parse(item.MobileSick)).FirstOrDefault();
                item.MobileSick = getUsr.User.Mobile;
                item.NameSick = getUsr.User.NameFamily;
            }
            return requests;
        }

        public int GetMaxRole()
        {
            return context.Roles.Max(i => i.Id);
        }

        public Sick GetSick(string username)
        {
            return context.Sick.Include(x => x.User).FirstOrDefault(s => s.User.Mobile == username);
        }

        public string GetTakhasos(int id)
        {
            return context.Takhasos.FirstOrDefault(t => t.Id == id).Name;
        }

        public string GetUserNameFamily(string username)
        {
            return context.Users.FirstOrDefault(x=>x.Mobile == username).NameFamily;
        }

        public string GetUserStatus(string username)
        {
            return context.Users.FirstOrDefault(x => x.Mobile == username).Activate;
        }

        public List<VisitRequest> GetVisitList()
        {
            List<VisitRequest> requests = new List<VisitRequest>();

            requests = context.VisitRequests.ToList();
            return requests;
        }

        public void UpdateDoctor(DoctorViewModel models, string username)
        {

            Doctor doctor = GetDoctor(username);
            string getTakhasos = GetTakhasos(int.Parse(models.Takhasos));
            doctor.AddressMatab = models.AddressMatab;
            doctor.Description = models.Description;
            doctor.MeliCode = models.MeliCode;
            doctor.DoctorId = models.DoctorId;
            doctor.Rate = doctor.Rate;
            doctor.SNP = models.SNP;
            doctor.Takhasos = getTakhasos;
            doctor.TelMatab = models.TelMatab;
            doctor.User.NameFamily = models.NameFamily;
            doctor.User.Activate = "waiting";
            context.SaveChanges();
        }

        public void UpdateSick(SickviewModels models, string username)
        {
            Sick sick = GetSick(username);
            sick.Address = models.Address;
            sick.Age = models.Age;
            sick.City = models.City;
            sick.province = models.province;
            sick.Region = models.Region;
            sick.User.NameFamily = models.NameFamily;
           
            context.SaveChanges();
        }
    }
}
