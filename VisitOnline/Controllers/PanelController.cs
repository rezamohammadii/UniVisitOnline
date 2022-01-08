using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitOnline.Database.Tabels;
using VisitOnline.Models;
using VisitOnline.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;
using System.Drawing.Imaging;

namespace VisitOnline.Controllers
{
    public class PanelController : Controller
    {
        private IUser user;
        
        public PanelController(IUser _user )
        {
            user = _user;
            
        }

        public IActionResult DocDashboard()
        {
            string currentuser = User.Identity.Name;
            string status = user.GetUserStatus(currentuser);

            switch (status)
            {
                case "disable":
                    
                    ViewBag.Status = "disable";
                    break;
                case "enable":
                    ViewBag.Status = "enable";
                    break;
                case "waiting":
                    ViewBag.Status = "waiting";
                    break;
            }
          
            
            
            Doctor users = user.GetDoctor(currentuser);
            DoctorViewModel doctor = new DoctorViewModel()
            {
                Mobile = users.User.Mobile,
                AddressMatab = users.AddressMatab,
                Description = users.Description,
                MeliCode = users.MeliCode,
                NameFamily = users.User.NameFamily,
                DoctorId = users.DoctorId,
                Rate = users.Rate,
                SNP = users.SNP,
                Takhasos = users.Takhasos,
                TelMatab = users.TelMatab
            };

            
            return View(doctor);
        }

        public IActionResult CompleteInformation()
        {
            
            string currentuser = User.Identity.Name;
            Doctor users = user.GetDoctor(currentuser);

            DoctorViewModel doctor = new DoctorViewModel()
            {
               
                AddressMatab = users.AddressMatab,
                Description = users.Description,
                MeliCode = users.MeliCode,
                NameFamily = users.User.NameFamily,
                DoctorId = users.DoctorId,
                Rate = users.Rate,
                SNP = users.SNP,
                Takhasos = users.Takhasos,
                TelMatab = users.TelMatab
            };
            return View(doctor);
        }
        [HttpPost]

        public IActionResult CompleteInformation(DoctorViewModel models)
        {
            if (ModelState.IsValid)
            {
                string currentuser = User.Identity.Name;
                user.UpdateDoctor(models , currentuser);

                string convert = models.Certificate.Replace("data:image/png;base64,", String.Empty).Replace("data:image/jpeg;base64," , String.Empty).Replace("data:image/jpg;base64," , String.Empty);
                string getFormat = models.Certificate.Split("/")[1].Split(";")[0];

                byte[] imageBytes = Convert.FromBase64String(convert);
               
                Image image;
                using (MemoryStream ms= new MemoryStream(imageBytes))
                {
                    image = Image.FromStream(ms);
                }
                switch (getFormat)
                {
                    case"png":
                        image.Save("wwwroot/img/server/" + models.SNP +".png", ImageFormat.Png);
                        break;
                    case "jpeg":
                        string ipath = "wwwroot/img/server/" + models.SNP + ".jpeg";
                        var i = Image.FromFile(ipath);

                        var i2 = new Bitmap(i);
                        i2.Save(ipath , ImageFormat.Jpeg);
                        break;
                    case "jpg":
                        image.Save("wwwroot/img/server/" + $"{ models.SNP}.jpg", ImageFormat.Jpeg);
                        break;
                }
                

            }
            return View(models);
        }

        public IActionResult SickDashboard()
        {
            string currentuser = User.Identity.Name;
           

            Sick users = user.GetSick(currentuser);
            SickviewModels bimar = new SickviewModels()
            {
                Mobile = users.User.Mobile,
                NameFamily = users.User.NameFamily,
                province = users.province,
                Address = users.Address ,
                Age = users.Age ,
                City = users.City,
                Region = users.Region
            };


            return View(bimar);
        }

        public IActionResult SickInformation()
        {

            string currentuser = User.Identity.Name;
            Sick users = user.GetSick(currentuser);
            SickviewModels sick = new SickviewModels()
            {
                Mobile = users.User.Mobile,
                NameFamily = users.User.NameFamily,
                province = users.province,
                Address = users.Address,
                Region = users.Region ,
                City = users.City ,
                Age =users.Age ,
                
            };
            return View(sick);
        }
        [HttpPost]
        public IActionResult SickInformation(SickviewModels model)
        {
            if (ModelState.IsValid)
            {
                string currentuser = User.Identity.Name;
                user.UpdateSick(model , currentuser);

            }
            return View(model);
        }

        public IActionResult SeeVisit()
        {
            List<VisitRequest> ListVisit = user.GetVisitList();
            return View(ListVisit);
        }
        public RequestVisitModel VisitData(int id)
        {
            string cuser = User.Identity.Name;
            RequestVisitModel visitModel = user.GetRequsetDataSick(id, cuser);
           
            return visitModel;

        }

        public bool DelReqSic(int id)
        {

            return user.DeleteReqSic(id);
        }
        public RequestVisitModel VisitForDocData(int id)
        {
            string cuser = User.Identity.Name;
            RequestVisitModel visitModel = user.GetRequsetDataDoc(id, cuser);

            return visitModel;
        }


        public IActionResult RequestVisit()
        {

            return View();
        }

        [HttpPost]
        public IActionResult RequestVisit(RequestVisitModel model)
        {
           
            string cuser = User.Identity.Name;
            user.AddRequsetVisit(model, cuser);

            
            return View();
        }

        public List<DoctorViewModel> GetDoctor(int id)
        {

            return user.GetListDoctor(id); 
        }


        public IActionResult SeeReViDoc()
        {
            string cuser = User.Identity.Name;
           List<RequestVisitModel> visitModels = user.GetListReViDoc(cuser);
            return View(visitModels);
        }

      

        [HttpPost]
        public bool AnswerViDoc(RequestVisitModel model)
        {
            

            string cuser = User.Identity.Name;
            user.UpdateRequsetVisit(model, cuser);

            return true;
        }





    }
}
