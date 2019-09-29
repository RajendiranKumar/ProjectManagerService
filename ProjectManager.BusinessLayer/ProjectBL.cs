using ProjectManager.DataLayer;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectManager.BusinessLayer
{
    public class ProjectBL
    {
        /// <summary>
        /// Method  to get all user from the database
        /// </summary>
        /// <Return>users with details</return>
        public List<Project> GetAllProjects()
        {
            //from p in context.ParentTable
            //let cCount =
            //(
            //  from c in context.ChildTable
            //  where p.ParentId == c.ChildParentId
            //  select c
            //).Count()
            //select new { ParentId = p.Key, Count = cCount };
            List<Project> projects = new List<Project>();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                //projects = db.Project.ToList();
                //return projects;

                var data = from p in db.Project
                           let numberoftasks =
                           (from t in db.Task
                            where p.Project_ID == t.Project_ID
                            select t).Count()
                           let completed =
                           (from t in db.Task
                            where p.Project_ID == t.Project_ID && t.Status == true
                            select t).Count()
                           select new
                           {
                               p.Project_ID,
                               p.Project_Name,
                               NumberofTasks = numberoftasks,
                               Completed = completed,
                               p.Priority,
                               p.Start_Date,
                               p.End_Date
                           };

                if (data != null)
                {
                    foreach (var val in data)
                    {
                        Project pt = new Project();
                        pt.Project_ID = val.Project_ID;
                        pt.Project_Name = val.Project_Name;
                        pt.Start_Date = val.Start_Date;
                        pt.End_Date = val.End_Date;
                        pt.NumberOfTasks = val.NumberofTasks;
                        pt.Completed = val.Completed;
                        pt.Priority = val.Priority;
                        projects.Add(pt);
                    }
                }

                return projects;
            }
        }

        /// <summary>
        /// Method  to get only one user from the database
        /// </summary>
        /// <Return>users with details</return>
        public List<Project> GetFilteredProjects(string searchBy)
        {
            List<Project> projects = new List<Project>();
            DateTime dDate;
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                if (Regex.IsMatch(searchBy, @"^\d+$"))
                {
                    long searchId = Convert.ToInt64(searchBy);
                    projects = db.Project.Where(data => data.Priority != null &&
                    data.Priority.ToString().Contains(searchBy)).ToList();
                }
                else if (DateTime.TryParse(searchBy, out dDate))
                {
                    String.Format("{0:yyyy/MM/dd}", dDate);
                    projects = db.Project.Where(data => data.Start_Date >= dDate
                    || data.End_Date >= dDate).ToList();
                }
                else
                {
                    projects = db.Project.Where(data => data.Project_Name.Contains(searchBy)).ToList();
                }

                return projects;
            }
        }

        public Project GetProject(string searchBy)
        {
            Project projects = new Project();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                projects = db.Project.SingleOrDefault(data => data.Project_ID.Equals(searchBy));
                return projects;
            }
        }

        public void AddProject(Project item)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                db.Project.Add(item);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Method to update  the task into the database
        /// </summary>
        /// <param name="item">Task which needs to be updated</param>
        public void UpdateProject(Project item)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                var itemToUpdate = db.Project.SingleOrDefault(data => data.Project_ID.Equals(item.Project_ID));
                if (itemToUpdate != null)
                {
                    itemToUpdate.Project_ID = item.Project_ID;
                    itemToUpdate.Project_Name = item.Project_Name;
                    itemToUpdate.Start_Date = item.Start_Date;
                    itemToUpdate.End_Date = item.End_Date;
                    itemToUpdate.Priority = item.Priority;
                    db.SaveChanges();
                }
            }
        }


        /// <summary>
        /// Method to delete the task based on the user interaction
        /// </summary>
        /// <param name="taskID">Task Id which needs to be deleted</param>
        public void DeleteProject(int projectID)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                var itemToDelete = db.Project.SingleOrDefault(task => task.Project_ID.Equals(projectID));
                if (itemToDelete != null)
                {
                    db.Project.Remove(itemToDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
