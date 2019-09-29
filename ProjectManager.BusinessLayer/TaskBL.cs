using ProjectManager.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManager.Entities;

namespace ProjectManager.BusinessLayer
{
    public class TaskBL
    {
        /// <summary>
        /// Method  to add the task to the database
        /// </summary>
        /// <param name="item">Task with details</param>
        public void AddTask(Task item)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                db.Task.Add(item);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Method to update  the task into the database
        /// </summary>
        /// <param name="item">Task which needs to be updated</param>
        public void UpdateTask(Task item)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                var itemToUpdate = db.Task.SingleOrDefault(task => task.Task_ID.Equals(item.Task_ID));
                if (itemToUpdate != null)
                {
                    itemToUpdate.Task_Name = item.Task_Name;
                    itemToUpdate.Parent_ID = item.Parent_ID;
                    itemToUpdate.Priority = item.Priority;
                    itemToUpdate.Start_Date = item.Start_Date;
                    itemToUpdate.End_Date = item.End_Date;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// This is the method to end the existing task based on user interaction
        /// </summary>
        /// <param name="taskID">Task id which needs to be ended</param>
        public void EndTask(int taskID)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                var itemToEnd = db.Task.SingleOrDefault(task => task.Task_ID.Equals(taskID));
                if (itemToEnd != null)
                {
                    itemToEnd.Status = true;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to delete the task based on the user interaction
        /// </summary>
        /// <param name="taskID">Task Id which needs to be deleted</param>
        public void DeleteTask(int taskID)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                var itemToDelete = db.Task.SingleOrDefault(task => task.Task_ID.Equals(taskID));
                if (itemToDelete != null)
                {
                    db.Task.Remove(itemToDelete);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to get all the existing tasks from database
        /// </summary>
        /// <returns>Returns list of task from databse</returns>
        public List<Task> GetAllTasks()
        {
            List<Task> tasks = new List<Task>();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                tasks = db.Task.ToList();
                return tasks;
            }
        }

        /// <summary>
        /// Method to get all the existing tasks from database
        /// </summary>
        /// <returns>Returns list of task from databse</returns>
        public List<ParentTask> GetParentTasks()
        {
            List<ParentTask> tasks = new List<ParentTask>();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                tasks = db.ParentTask.ToList();
                return tasks;
            }
        }


        /// <summary>
        /// Method to get all the existing tasks from database
        /// </summary>
        /// <returns>Returns list of task from databse</returns>
        public void AddParentTasks(ParentTask item)
        {
            List<ParentTask> tasks = new List<ParentTask>();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                db.ParentTask.Add(item);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Method to get the task based on the user selection
        /// </summary>
        /// <param name="taskID">Task Id which needs to be returned</param>
        /// <returns>Returns the selected task details</returns>
        public List<Task> GetTaskById(int taskID)
        {
            List<Task> filteredItems = new List<Task>();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                filteredItems = db.Task.Where(task => task.Project_ID.Equals(taskID)).ToList();
                
                return filteredItems;
            }
        }

        // <summary>
        /// Method to get the task based on the user selection
        /// </summary>
        /// <param name="taskID">Task Id which needs to be returned</param>
        /// <returns>Returns the selected task details</returns>
        public Task GetTask(int taskID)
        {
            Task filteredItem = new Task();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                filteredItem = db.Task.SingleOrDefault(task => task.Task_ID.Equals(taskID));

                return filteredItem;
            }
        }
    }
}
