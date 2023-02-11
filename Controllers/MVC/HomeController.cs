using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

         private void AddNewView()
         {
            Viewer view = new Viewer();
            view.Date = DateTime.Now;
            db.Viewers.Add(view);
            db.SaveChanges();
         }
          
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Control()
        {
             int V = db.Viewers.ToList().Count();
             ViewData["TotalViewers"] = V;
           
            DateTime dateTime =  DateTime.Now.AddDays(-1);
             ViewData["New Users"] = db.Viewers.Where(e=>e.Date > dateTime).ToList().Count();

            List<DateTime> D= new List<DateTime>();
            foreach (var item in db.Viewers)
            {
                D.Add((DateTime)item.Date);
            }
            int T = DateTime.Now.Subtract(D.Min()).Days;
            ViewData["Range"] =V/ T;


            ViewData["Users"] = db.AspNetUsers.Count();

            return View();
        }
       // [AllowAnonymous]
        public ActionResult Profile()
        {
            //Headers
            ViewBag.Name = db.Headers.Where(e => e.HeaderCategory.HeaderName == "Name").Select(e=>e.Header1).SingleOrDefault();
            ViewBag.Title = db.Headers.Where(e => e.HeaderCategory.HeaderName == "Title").Select(e => e.Header1).SingleOrDefault();
            ViewBag.PDFCV = db.Headers.Where(e => e.HeaderCategory.HeaderName == "PDF-CV").Select(e => e.Header1).SingleOrDefault();
            //SocialLinks
            TempData["FaceBook"] = db.SocialLinks.Where(e => e.SocialCategory.SocialName == "FaceBook").Select(e => e.SocialLink1).SingleOrDefault();
          TempData["LinkedIn"] = db.SocialLinks.Where(e => e.SocialCategory.SocialName == "LinkedIn").Select(e => e.SocialLink1).SingleOrDefault();
          TempData["Github"] = db.SocialLinks.Where(e => e.SocialCategory.SocialName == "Github").Select(e => e.SocialLink1).SingleOrDefault();
          TempData["Twitter"] = db.SocialLinks.Where(e => e.SocialCategory.SocialName == "Twitter").Select(e => e.SocialLink1).SingleOrDefault();
          TempData["Instagram"] = db.SocialLinks.Where(e => e.SocialCategory.SocialName == "Instagram").Select(e => e.SocialLink1).SingleOrDefault();
          TempData["Wuzzuf"] = db.SocialLinks.Where(e => e.SocialCategory.SocialName == "Wuzzuf").Select(e => e.SocialLink1).SingleOrDefault();
            //Image
            var result = db.Images.Select(e => e.ImagePath).SingleOrDefault();
            ViewBag.ImageUrl = "/IMG/" + Url.Content(result);
            //About
            ViewBag.Title = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Title").Select(e=>e.TopicDescrption).SingleOrDefault();
            ViewBag.Brief = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Brief").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.Birthday = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Birthday").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.Age = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Age").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.Website = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Website").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.Degree = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Degree").Select(e => e.TopicDescrption).SingleOrDefault();
            TempData["Phone"]  = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Phone").Select(e => e.TopicDescrption).SingleOrDefault();
             TempData["Email"]  = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Email").Select(e => e.TopicDescrption).SingleOrDefault();
            TempData["City"]  = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "City").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.Freelance = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Freelance").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.ServiceBrief = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "ServiceBrief").Select(e=>e.TopicDescrption).SingleOrDefault();
            ViewBag.HappyClients = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Happy Clients").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.Projects = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Projects").Select(e => e.TopicDescrption).SingleOrDefault();
            ViewBag.HoursOfSupport = db.AboutTopics.Where(e => e.AboutCategory.AboutTopic == "Hours Of Support").Select(e => e.TopicDescrption).SingleOrDefault();
            //PROGRAMMING LANGUAGE
            Dictionary<string, int> P = new Dictionary<string, int>();
            foreach (var item in db.ProgrammingLanguages)
            {
                P.Add(item.ProgrammingLanguage1,(int)item.Pecentage);
            }
            ViewBag.ProgrammingLanguages = P;


            //Skills
            ViewBag.Skills = db.Skills.Select(e => e.SkillName).ToList();
            


            //Sumary
            ViewBag.FullName = db.SumaryTopics.Where(a => a.SumaryCategory.SumaryCategory1 == "FullName").Select(b=>b.SumaryTopicName).SingleOrDefault();
            ViewBag.Brief= db.SumaryTopics.Where(a => a.SumaryCategory.SumaryCategory1 == "Brief").Select(b => b.SumaryTopicName).SingleOrDefault();
            ViewBag.Address= db.SumaryTopics.Where(a => a.SumaryCategory.SumaryCategory1 == "Address").Select(b => b.SumaryTopicName).SingleOrDefault();
            ViewBag.Phone= db.SumaryTopics.Where(a => a.SumaryCategory.SumaryCategory1 == "Phone").Select(b => b.SumaryTopicName).SingleOrDefault();
            ViewBag.Email= db.SumaryTopics.Where(a => a.SumaryCategory.SumaryCategory1 == "Email").Select(b => b.SumaryTopicName).SingleOrDefault();

            //Education
            ViewBag.FACULTY = db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "FACULTY").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.StartDate= db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "StartDate").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.FinshDate= db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "FinshDate").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.Department= db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "Department").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.University= db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "University").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.Level= db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "Level").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.GPA= db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "GPA").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.Degree = db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "Degree").Select(b => b.EducationTopic1).SingleOrDefault();
            ViewBag.DegreeDescription = db.EducationTopics.Where(a => a.EducationCategory.EducationCategory1 == "DegreeDescription").Select(b => b.EducationTopic1).SingleOrDefault();

            //Certifcate
            Dictionary<string, string> D = new Dictionary<string ,string>();
            foreach (var item in db.Certifcates)
            {
                D.Add(item.CertifcateName, item.CertifcateLink);
            }
            ViewBag.Certifcate = D;

            //SERVICES
            Dictionary<string, string> S = new Dictionary<string, string>();
            foreach (var item in db.Services)
            {
                S.Add(item.ServiceName, item.ServiceDescription);
            }
            ViewBag.Services = S;


            //Func
            AddNewView();
            return View();
        }
   

    }
}