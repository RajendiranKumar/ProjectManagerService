using NUnit.Framework;
using ProjectManager.API.Controllers;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace ProjectManager.API.Tests
{
    [TestFixture]
    public class ProjectManagerProjectServiceTests
    {
        [Test]
        public void TestAddProjectService()
        {
            Project itemToAdd = new Project();

            itemToAdd.Project_Name = "TestProject_Nunit_1";
            itemToAdd.Priority = 4;
            itemToAdd.Start_Date = DateTime.Now;
            itemToAdd.End_Date = DateTime.Now.AddDays(15);

            var controller = new ProjectController();
            var actionResult = controller.GetAllProjects() as OkNegotiatedContentResult<List<Project>>;
            int actualCount = actionResult.Content.Count + 1;
            controller.AddProject(itemToAdd);
            actionResult = controller.GetAllProjects() as OkNegotiatedContentResult<List<Project>>;
            int expectedCount = actionResult.Content.Count;
            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void TestUpdateProjectService()
        {
            bool actualResult = true;
            bool expectedResult = true;
            //Entities.Task itemToUpdate = new Entities.Task();

            var controller = new ProjectController();
            var actionResult = controller.GetAllProjects() as OkNegotiatedContentResult<List<Project>>;

            var itemToUpdate = actionResult.Content.FirstOrDefault();

            itemToUpdate.Project_Name = "UpdatedProjectName_Nunit";
            controller.UpdateProject(itemToUpdate);

            var updatedItem = controller.GetProject(itemToUpdate.Project_ID.ToString()) as OkNegotiatedContentResult<Project>;

            if (!updatedItem.Content.Project_Name.Equals("UpdatedTaskName_Nunit"))
            {
                actualResult = false;
            }

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestDeleteProjectService()
        {
            bool actualResult = false;
            bool expectedResult = true;
            Entities.Project itemToDelete = new Entities.Project();

            var controller = new ProjectController();
            var actionResult = controller.GetAllProjects() as OkNegotiatedContentResult<List<Project>>;

            itemToDelete = actionResult.Content.FirstOrDefault();

            controller.DeleteProject(itemToDelete.Project_ID);

            var deletedItem = controller.GetProject(itemToDelete.Project_ID.ToString()) as OkNegotiatedContentResult<Project>;
            if (deletedItem == null)
            {
                actualResult = true;
            }
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestGetAllProjectService()
        {
            bool actualResult = false;
            bool expectedResult = true;

            var controller = new ProjectController();
            var actionResult = controller.GetAllProjects() as OkNegotiatedContentResult<List<Project>>;
            if (actionResult.Content.Count > 0)
            {
                actualResult = true;
            }
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestGetProjectByIdService()
        {
            bool actualResult = false;
            bool expectedResult = true;
            Entities.Project actualTask = new Entities.Project();
            //Entities.Task expectedTask = new Entities.Task();

            var controller = new ProjectController();
            var actionResult = controller.GetAllProjects() as OkNegotiatedContentResult<List<Project>>;

            actualTask = actionResult.Content.FirstOrDefault();
            var expectedTask = controller.GetProject(actualTask.Project_ID.ToString()) as OkNegotiatedContentResult<Task>;
            if (actualTask.Project_ID.Equals(expectedTask.Content.Project_ID))
            {
                actualResult = true;
            }
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
