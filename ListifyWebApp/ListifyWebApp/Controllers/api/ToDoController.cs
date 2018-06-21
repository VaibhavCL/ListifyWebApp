using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ListifyWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ListifyWebApp.Controllers.api
{  
    /// <summary>
    /// This is the ToDo Controller for the user's ToDo list that extends from the Api Controller 
    /// </summary>
    public class ToDoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// This GetToDoes is used to get all the list of an user
        /// </summary>
        /// <returns></returns>
        // GET: api/ToDoes
        [Route("api/ToDo")]
        public List<ToDoModel> GetToDoes()
        {
            var userId = User.Identity.GetUserId();

            List<ToDoModel> _toDoList = new List<ToDoModel>();
            var toDoList = from mapping in db.ToDoMappings
                        join toDoEntity in db.ToDoes.Where(x=>x.IsActive) on mapping.TodoId equals toDoEntity.Id
                        where mapping.UserId == userId
                           select toDoEntity;

            foreach (var item in toDoList)
            {
                _toDoList.Add(new ToDoModel() { UserId = userId, Id = item.Id, Title = item.Title, Description = item.Description, date = item.Date.ToString("MMM dd yyyy,hh:mm tt") }); 
            }
            //ToDo toDo = db.ToDoes.Where(a => a.Id == ID).FirstOrDefault();
            return _toDoList;
        }

        /// <summary>
        /// This GetToDo is used to retrieve the user's data by passing their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ToDo/5
        [ResponseType(typeof(ToDo))]
        public IHttpActionResult GetToDo(int id)
        {
            var userId = User.Identity.GetUserId();
            ToDoModel toDoModel = new ToDoModel();
            var toDoList = from mapping in db.ToDoMappings
                           join toDoEntity in db.ToDoes.Where(x => x.IsActive) on mapping.TodoId equals toDoEntity.Id
                           where mapping.UserId == userId
                           select toDoEntity;
            ToDo toDo = db.ToDoes.Where(x=>x.Id == id).FirstOrDefault();
            if (toDo == null)
            {
                return NotFound();
            }
            else
            {
                toDoModel.Id = toDo.Id;
                toDoModel.Title = toDo.Title;
                toDoModel.Description = toDo.Description;
                toDoModel.date = toDo.Date.ToString();

            }
            return Ok(toDoModel);
        }

        // PUT: api/ToDo/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutToDo(int id, ToDo toDo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != toDo.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(toDo).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ToDoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/ToDo
        //[ResponseType(typeof(string))]

            /// <summary>
            /// This PostToDo is used to Create and Edit the list
            /// </summary>
            /// <param name="toDo"></param>
            /// <returns></returns>
        [Route("api/ToDo")]
        public HttpResponseMessage PostToDo(ToDoModel toDo)
        {
            ToDo toDoEntity = new ToDo();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (toDo.Id == 0 || toDo.Id == null)
                {
                    toDoEntity.Title = toDo.Title;
                    toDoEntity.Description = toDo.Description;
                    toDoEntity.Date = Convert.ToDateTime(toDo.date);
                    toDoEntity.IsActive = true;
                    db.ToDoes.Add(toDoEntity);
                    db.SaveChanges();
                    ToDoMapping toDoMappingEntity = new ToDoMapping();
                    toDoMappingEntity.TodoId = toDoEntity.Id;
                    //Need to modify this line after token generation 
                    toDoMappingEntity.UserId = toDo.UserId;
                    //toDoMappingEntity.UserId = 10;
                    db.ToDoMappings.Add(toDoMappingEntity);
                    db.SaveChanges();
                }
                else
                {
                    //ToDo to = new ToDo();
                    var toDoEnity =  db.ToDoes.Where(x=>x.Id == toDo.Id).FirstOrDefault();
                    toDoEnity.Title = toDo.Title;
                    toDoEnity.Description = toDo.Description;
                    toDoEnity.Date =Convert.ToDateTime(toDo.date);
                    db.SaveChanges();
                }
            }

            var resultResponse = new {  Id = toDoEntity.Id };
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, resultResponse);
            return response;
        }

        /// <summary>
        /// This DeleteToDo is used to delete by passing Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ToDo/5
        [ResponseType(typeof(ToDo))]
        public HttpResponseMessage DeleteToDo(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var toDoEntity = db.ToDoes.Where(x => x.Id == id).FirstOrDefault();
                toDoEntity.IsActive = false;
                db.SaveChanges();
            }
            var resultResponse = new { message = "Deleted Successfully" };
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, resultResponse);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoExists(int id)
        {
            return db.ToDoes.Count(e => e.Id == id) > 0;
        }
    }
}