using ProjectManager.BusinessLayer;
using ProjectManager.Entities;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetAllProjects")]
        public IHttpActionResult GetAllProjects()
        {
            ProjectBL blProject = new ProjectBL();
            return Ok(blProject.GetAllProjects());
        }

        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetFilteredProjects")]
        public IHttpActionResult GetFilteredProjects(string searchBy)
        {
            ProjectBL blProject = new ProjectBL();
            return Ok(blProject.GetFilteredProjects(searchBy));
        }

        /// <summary>
        /// This is the Get method to get all tasks
        /// </summary>
        /// <returns>Returns list of tasks from database</returns>
        [HttpGet, Route("GetProject")]
        public IHttpActionResult GetProject(string searchBy)
        {
            ProjectBL blProject = new ProjectBL();
            return Ok(blProject.GetProject(searchBy));
        }

        /// <summary>
        /// This is the Post method to add the new task
        /// </summary>
        /// <param name="item">Task needs to be added</param>
        /// <returns></returns>
        [HttpPost, Route("AddProject")]
        public IHttpActionResult AddProject(Project item)
        {
            ProjectBL blProject = new ProjectBL();
            try
            {
                blProject.AddProject(item);
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
        [HttpPost, Route("UpdateProject")]
        public IHttpActionResult UpdateProject(Project item)
        {
            ProjectBL blProject = new ProjectBL();
            try
            {
                blProject.UpdateProject(item);
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
        [HttpGet, Route("DeleteProject")]
        public IHttpActionResult DeleteProject(int projectID)
        {
            ProjectBL blProject = new ProjectBL();
            try
            {
                blProject.DeleteProject(projectID);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(blProject.GetAllProjects());
        }
    }
}
