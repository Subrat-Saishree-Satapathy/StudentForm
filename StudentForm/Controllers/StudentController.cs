using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentForm.Models;

namespace StudentForm.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseContext databaseContext;
        public StudentController(DatabaseContext context)
        {
            databaseContext = context;
        }

        public ActionResult Index()
        {
            //List<Student> studentlist = databaseContext.Students.ToList();

            List<Viewmodel> viewmodellist = new List<Viewmodel>();
            //List<Viewmodel> addressvmlist = studentlist.Select(x => new Viewmodel {StudentName=x.StudentName,StudentID=x.StudentID,Addresslocation=x.}




            var studentlist = (from adrs in databaseContext.Addresses
                               join stud in databaseContext.Students
                               on adrs.StudentID equals stud.StudentID
                               select new
                               {
                                   adrs.StudentID,
                                   stud.StudentName,
                                   adrs.Pincode,
                                   adrs.Addresslocation
                               }).ToList();

            foreach (var data in studentlist)
            {
                Viewmodel vml = new Viewmodel();
                vml.StudentID = data.StudentID;
                vml.StudentName = data.StudentName;
                vml.Pincode = data.Pincode;
                vml.Addresslocation = data.Addresslocation;
                viewmodellist.Add(vml);
            }


            return View(viewmodellist);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Viewmodel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student
                {
                    //StudentID=viewmodel.StudentID,
                    StudentName = viewmodel.StudentName,
                };

                databaseContext.Students.Add(student);
                databaseContext.SaveChanges();
                var _Student = databaseContext.Students.Where(m => m.StudentName == viewmodel.StudentName).FirstOrDefault();
                Address address = new Address
                {
                    
                    StudentID = _Student.StudentID,
                    Addresslocation = viewmodel.Addresslocation,
                    Pincode = viewmodel.Pincode
                };

                databaseContext.Addresses.Add(address);
                databaseContext.SaveChanges();
                return RedirectToAction("Index");

            }   
            return View(viewmodel);

        }

        public ActionResult Edit(int id)
        {
            Viewmodel _obj = new Viewmodel();
            var _Viewmodel = from adrs in databaseContext.Addresses
                             join stud in databaseContext.Students
                             on adrs.StudentID equals stud.StudentID into adrsstud
                             from stud in adrsstud.DefaultIfEmpty()
                             where adrs.StudentID == id

                             select new Viewmodel
                             {
                                 StudentID = id,
                                 StudentName = stud.StudentName,
                                 Addresslocation = adrs.Addresslocation,
                                 Pincode = adrs.Pincode

                             };
            foreach (var items in _Viewmodel)
            {
                _obj.StudentID = items.StudentID;
                _obj.StudentName = items.StudentName;
                _obj.Addresslocation = items.Addresslocation;
                _obj.Pincode = items.Pincode;
            }
            return View(_obj);
        }


        [HttpPost]
        public ActionResult Edit(Viewmodel viewmodel)

        {
            var _Student = databaseContext.Students.Where(m => m.StudentID == viewmodel.StudentID).FirstOrDefault();

            _Student.StudentName = viewmodel.StudentName;
            databaseContext.Update(_Student);
            databaseContext.SaveChanges();

            var _StudentAddress = databaseContext.Addresses.Where(m => m.StudentID == _Student.StudentID).FirstOrDefault();
            _StudentAddress.Addresslocation = viewmodel.Addresslocation;
            _StudentAddress.Pincode = viewmodel.Pincode;
            databaseContext.Update(_StudentAddress);
            databaseContext.SaveChanges();

            return RedirectToAction("Index");
         

        }


        public ActionResult Delete(int id)
        {
            Viewmodel _obj = new Viewmodel();
            var _Viewmodel = from adrs in databaseContext.Addresses
                             join stud in databaseContext.Students
                             on adrs.StudentID equals stud.StudentID into adrsstud
                             from stud in adrsstud.DefaultIfEmpty()
                             where adrs.StudentID == id

                             select new Viewmodel
                             {
                                 StudentID = id,
                                 StudentName = stud.StudentName,
                                 Addresslocation = adrs.Addresslocation,
                                 Pincode = adrs.Pincode

                             };
            foreach (var items in _Viewmodel)
            {
                _obj.StudentID = items.StudentID;
                _obj.StudentName = items.StudentName;
                _obj.Addresslocation = items.Addresslocation;
                _obj.Pincode = items.Pincode;
            }
            return View(_obj);

        }

        [HttpPost]
        public ActionResult Delete(Viewmodel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student
                {

                    StudentID = viewmodel.StudentID,
                };
                
                databaseContext.Students.Remove(student);
                databaseContext.SaveChanges();
                
            };
            
            return RedirectToAction("Index");

        }


    }
}
        


                


           




            

          

          
            


        






    

    
