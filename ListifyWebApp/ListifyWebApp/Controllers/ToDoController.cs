using ListifyWebApp.Models;
using ListifyWebApp.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ListifyWebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ToDoController : Controller
    {

        private ApplicationDbContext _dbContext = null;
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// It is a default controller
        /// </summary>
        public ToDoController()
        {
            _dbContext = new ApplicationDbContext();
        }

        /// <summary>
        /// This ToDoList is used to get all the list of an user
        /// </summary>
        /// <returns></returns>
        // GET: ToDo
        public ActionResult ToDoList()
        {
            List<ToDoModel> modelList = new List<ToDoModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var _toDoEntityList = (from mapping in db.ToDoMappings
                                       join todo in db.ToDoes.Where(x=>x.IsActive)
                                       on mapping.TodoId equals todo.Id
                                       where mapping.UserId == userId
                                       select todo).ToList();                                      
                
                foreach (var item in _toDoEntityList)
                {
                    
                   modelList.Add(new ToDoModel() { Id = item.Id, Title = item.Title, Description = item.Description, date = item.Date.ToString("MMM dd,hh:mm tt") });
                }
            }
            return View(modelList);
        }



        /// <summary>
        /// This method is used to add title,description and date for ToDoList
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddToDo(string title, string description, DateTime date)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(title, "^[a-zA-Z]+$"))
            {
                var userId = User.Identity.GetUserId();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var entity = new ToDo();
                    entity.Title = title;
                    entity.Description = description;
                    entity.Date = date;
                    entity.IsActive = true;
                    db.ToDoes.Add(entity);
                    db.SaveChanges();

                    var todomapping = new ToDoMapping();
                    todomapping.UserId = userId;
                    todomapping.TodoId = entity.Id;
                    todomapping.Date = date;
                    db.ToDoMappings.Add(todomapping);
                    db.SaveChanges();
                    return RedirectToAction("ToDoList", "ToDo");
                }
            }
            else
            {
                //title = title.Remove(title.Length - 1);
                Console.WriteLine("Enter only alphabets");
                Console.ReadLine();
                ModelState.AddModelError("", "Enter only alphabets");
            }
            return RedirectToAction("ToDoList", "ToDo");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDoId"></param>
        /// <returns></returns>
        public ActionResult GetTodoById(int toDoId)
        {
            ToDoModel model = new ToDoModel();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var _toDoEntity = db.ToDoes.Where(x => x.Id == toDoId).FirstOrDefault();
                model.Title = _toDoEntity.Title;
                model.Description = _toDoEntity.Description;
                model.date = _toDoEntity.Date.ToString("dd/MM/yyyy hh:mm");
                return Json(new {  toDoModel = model },
                JsonRequestBehavior.AllowGet);
            }
          
        }

        /// <summary>
        /// This method is used to open the edit field
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //For Edit
        public ActionResult Edit(int? id)
        {
            return View();
        }

        /// <summary>
        /// This method is used to edit an list of user
        /// </summary>
        /// <param name="toDoEntity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(ToDoModel toDoEntity)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var _toDoEntity = db.ToDoes.Where(x => x.Id == toDoEntity.Id).FirstOrDefault();
                    _toDoEntity.Title = toDoEntity.Title;
                    _toDoEntity.Description = toDoEntity.Description;
                    _toDoEntity.Date = Convert.ToDateTime(toDoEntity.date);
                    db.SaveChanges();
                }
                return RedirectToAction("ToDoList", "ToDo");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// This method is used to open the delete field
        /// </summary>
        /// <returns></returns>
        //For Delete
        public ActionResult Delete()
        {
            return View();
        }

        /// <summary>
        /// This method is used to delete the list for the specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var _toDoEntity = db.ToDoes.Where(x => x.Id == id).FirstOrDefault();
                    _toDoEntity.IsActive = false;
                    db.SaveChanges();
                }
                return RedirectToAction("ToDoList", "ToDo");
            }
            catch
            {
                return View();
            }
        }
        
        /// <summary>
        /// This method is used to get details of the list by clicking on Title for specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Details
        public ActionResult Details(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ToDoMapping toDo = db.ToDoMappings.Single(x => x.TodoId == id);
            return View(toDo);
        }
    }

}