using ProjectManager.BusinessLayer;
using ProjectManager.Entities;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetAllTasks")]
        public IHttpActionResult GetAllTasks()
        {
            TaskBL blTask = new TaskBL();
            return Ok(blTask.GetAllTasks());
        }

        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetParentTasks")]
        public IHttpActionResult GetParentTasks()
        {
            TaskBL blTask = new TaskBL();
            return Ok(blTask.GetParentTasks());
        }

        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpPost, Route("AddParentTasks")]
        public IHttpActionResult AddParentTasks(ParentTask item)
        {
            TaskBL blTask = new TaskBL();
            try
            {
                blTask.AddParentTasks(item);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok();
        }

        /// <summary>
        /// This is the Get method  to get the selected  task
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <returns>Selected Task Details</returns>
        [HttpGet, Route("GetTaskByID")]
        public IHttpActionResult GetTaskByID(int taskId)
        {
            TaskBL blTask = new TaskBL();
            return Ok(blTask.GetTaskById(taskId));

        }

        /// <summary>
        /// This is the Get method  to get the selected  task
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <returns>Selected Task Details</returns>
        [HttpGet, Route("GetTask")]
        public IHttpActionResult GetTask(int taskId)
        {
            TaskBL blTask = new TaskBL();
            return Ok(blTask.GetTask(taskId));

        }

        /// <summary>
        /// This is the Post method to add the new task
        /// </summary>
        /// <param name="item">Task needs to be added</param>
        /// <returns></returns>
        [HttpPost, Route("AddTask")]
        public IHttpActionResult AddTask(Task item)
        {
            TaskBL blTask = new TaskBL();
            try
            {
                blTask.AddTask(item);
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
        [HttpPost, Route("UpdateTask")]
        public IHttpActionResult UpdateTask(Task item)
        {
            TaskBL blTask = new TaskBL();
            try
            {
                blTask.UpdateTask(item);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok();
        }

        /// <summary>
        /// This is the service method to end the task
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <returns>Returns list of tasks</returns>
        [HttpGet, Route("EndTask")]
        public IHttpActionResult EndTask(int taskId)
        {
            TaskBL blTask = new TaskBL();
            try
            {
                blTask.EndTask(taskId);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(blTask.GetAllTasks());
        }

        /// <summary>
        /// This is the service method to delete the task
        /// </summary>
        /// <param name="taskId">Task Id</param>
        /// <returns>Returns list of available tasks</returns>
        [HttpGet, Route("DeleteTask")]
        public IHttpActionResult DeleteTask(int taskId)
        {
            TaskBL blTask = new TaskBL();
            try
            {
                blTask.DeleteTask(taskId);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(blTask.GetAllTasks());
        }
    }
}
