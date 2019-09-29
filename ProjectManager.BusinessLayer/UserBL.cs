using ProjectManager.DataLayer;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectManager.BusinessLayer
{
    public class UserBL
    {
        /// <summary>
        /// Method  to get all user from the database
        /// </summary>
        /// <Return>users with details</return>
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                users = db.User.ToList();
                return users;
            }
        }

        /// <summary>
        /// Method  to get only one user from the database
        /// </summary>
        /// <Return>users with details</return>
        public List<User> GetFilteredUsers(string searchBy)
        {
            List<User> users = new List<User>();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                if (Regex.IsMatch(searchBy, @"^\d+$"))
                {
                    long searchId = Convert.ToInt64(searchBy);
                    users = db.User.Where(data => data.Employee_ID != null &&
                    data.Employee_ID.ToString().Contains(searchBy)).ToList();
                }
                else
                {
                    users = db.User.Where(data => data.FirstName.Contains(searchBy) ||
                                    data.LastName.Contains(searchBy)).ToList();
                }
                return users;
            }
        }

        public User GetUser(string searchBy)
        {
            int id = 0;
            id = Convert.ToInt32(searchBy);
            User user = new User();
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                user = db.User.SingleOrDefault(data =>data.Employee_ID.Equals(id));
                return user;
            }
        }

        public void AddUser(User item)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                db.User.Add(item);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Method to update  the task into the database
        /// </summary>
        /// <param name="item">Task which needs to be updated</param>
        public void UpdateUser(User item)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                var itemToUpdate = db.User.SingleOrDefault(data => data.User_ID.Equals(item.User_ID));
                if (itemToUpdate != null)
                {
                    itemToUpdate.User_ID = item.User_ID;
                    itemToUpdate.FirstName= item.FirstName;
                    itemToUpdate.LastName = item.LastName;
                    itemToUpdate.Employee_ID = item.Employee_ID;
                    db.SaveChanges();
                }
            }
        }


        /// <summary>
        /// Method to delete the task based on the user interaction
        /// </summary>
        /// <param name="taskID">Task Id which needs to be deleted</param>
        public void DeleteUser(int userID)
        {
            using (ProjectManagerContext db = new ProjectManagerContext())
            {
                var itemToDelete = db.User.SingleOrDefault(task => task.User_ID.Equals(userID));
                if (itemToDelete != null)
                {
                    db.User.Remove(itemToDelete);
                    db.SaveChanges();
                }
            }
        }

    }
}
