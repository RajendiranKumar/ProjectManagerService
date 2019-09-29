using NUnit.Framework;
using ProjectManager.API.Controllers;
using ProjectManager.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace ProjectManager.API.Tests
{
    [TestFixture]
    public class ProjectManagerUserServiceTests
    {
        [Test]
        public void TestAddProjectService()
        {
            User itemToAdd = new User();

            itemToAdd.FirstName = "TestUser_Nunit_fn1";
            itemToAdd.LastName = "TestUser_Nunit_ln1"; 
            itemToAdd.Employee_ID = 312037;
           

            var controller = new UserController();
            var actionResult = controller.GetAllUsers() as OkNegotiatedContentResult<List<User>>;
            int actualCount = actionResult.Content.Count + 1;
            controller.AddUser(itemToAdd);
            actionResult = controller.GetAllUsers() as OkNegotiatedContentResult<List<User>>;
            int expectedCount = actionResult.Content.Count;
            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void TestUpdateUserService()
        {
            bool actualResult = true;
            bool expectedResult = true;
            //Entities.Task itemToUpdate = new Entities.Task();

            var controller = new UserController();
            var actionResult = controller.GetAllUsers() as OkNegotiatedContentResult<List<User>>;

            var itemToUpdate = actionResult.Content.FirstOrDefault();

            itemToUpdate.FirstName = "UpdatedUserName_Nunit_fn2";
            controller.UpdateUser(itemToUpdate);

            var updatedItem = controller.GetUser(itemToUpdate.User_ID.ToString()) as OkNegotiatedContentResult<User>;

            if (!updatedItem.Content.FirstName.Equals("UpdatedUserName_Nunit_fn2"))
            {
                actualResult = false;
            }

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestDeleteUserService()
        {
            bool actualResult = false;
            bool expectedResult = true;
            Entities.User itemToDelete = new Entities.User();

            var controller = new UserController();
            var actionResult = controller.GetAllUsers() as OkNegotiatedContentResult<List<User>>;

            itemToDelete = actionResult.Content.FirstOrDefault();

            controller.DeleteUser(itemToDelete.User_ID);

            var deletedItem = controller.GetUser(itemToDelete.User_ID.ToString()) as OkNegotiatedContentResult<User>;
            if (deletedItem == null)
            {
                actualResult = true;
            }
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestGetAllUserService()
        {
            bool actualResult = false;
            bool expectedResult = true;

            var controller = new UserController();
            var actionResult = controller.GetAllUsers() as OkNegotiatedContentResult<List<User>>;
            if (actionResult.Content.Count > 0)
            {
                actualResult = true;
            }
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestGetUserByIdService()
        {
            bool actualResult = false;
            bool expectedResult = true;
            Entities.User actualTask = new Entities.User();
            //Entities.Task expectedTask = new Entities.Task();

            var controller = new UserController();
            var actionResult = controller.GetAllUsers() as OkNegotiatedContentResult<List<User>>;

            actualTask = actionResult.Content.FirstOrDefault();
            var expectedTask = controller.GetUser(actualTask.User_ID.ToString()) as OkNegotiatedContentResult<User>;
            if (actualTask.User_ID.Equals(expectedTask.Content.User_ID))
            {
                actualResult = true;
            }
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
