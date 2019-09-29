using ProjectManager.BusinessLayer;
using ProjectManager.Entities;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            UserBL blUser = new UserBL();
            return Ok(blUser.GetAllUsers());
        }

        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetFilteredUsers")]
        public IHttpActionResult GetFilteredUsers(string searchBy)
        {
            UserBL blUser = new UserBL();
            return Ok(blUser.GetFilteredUsers(searchBy));
        }

        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetUser")]
        public IHttpActionResult GetUser(string searchBy)
        {
            UserBL blUser = new UserBL();
            return Ok(blUser.GetUser(searchBy));
        }

        /// <summary>
        /// This is the Post method to add the new task
        /// </summary>
        /// <param name="item">Task needs to be added</param>
        /// <returns></returns>
        [HttpPost, Route("AddUser")]
        public IHttpActionResult AddUser(User item)
        {
            UserBL blUser = new UserBL();
            try
            {
                blUser.AddUser(item);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok();
        }

        /// <summary>
        /// This is the Post method to update the existing task
        /// </summary>
        /// <param name="item">Task needs to be updated</param>
        /// <returns></returns>
        [HttpPost, Route("UpdateUser")]
        public IHttpActionResult UpdateUser(User item)
        {
            UserBL blUser = new UserBL();
            try
            {
                blUser.UpdateUser(item);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok();
        }

        /// <summary>
        /// This is the service method to delete the task
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <returns>Returns list of available tasks</returns>
        [HttpGet, Route("DeleteUser")]
        public IHttpActionResult DeleteUser(int userID)
        {
            UserBL blUser = new UserBL();
            try
            {
                blUser.DeleteUser(userID);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(blUser.GetAllUsers());
        }
    }
}
