using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.Model;

namespace TaskManager.Service.Controllers
{

    public class TaskManagerController : ApiController
    {

        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns>Tasks</returns>
        [HttpGet]
        [Route("GetAllTasks")]
        public IHttpActionResult GetAllTasks()
        {
            TaskBusiness tb = new TaskBusiness();
            List<Task> allTasks = tb.GetAllTasks();
            return Ok(allTasks);
        }

        /// <summary>
        /// Get Task by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTaskByID")]
        public IHttpActionResult GetTaskByID(string id)
        {
            TaskBusiness tb = new TaskBusiness();
            Task selectedTask = tb.GetTaskByID(id);
            return Ok(selectedTask);
        }

        /// <summary>
        /// Post Task
        /// </summary>
        /// <param name="taskToAdd"></param>
        /// <returns></returns>        
        [HttpPost]
        [Route("PostTask")]
        public IHttpActionResult PostTask([FromBody] Task taskToAdd)
        {
            TaskBusiness tb = new TaskBusiness();
            taskToAdd.Task_ID = Guid.NewGuid().ToString();
            tb.AddTask(taskToAdd);
            return Ok(taskToAdd);
        }

        /// <summary>
        /// Update Task
        /// </summary>
        /// <param name="taskToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateTask")]
        public IHttpActionResult UpdateTask([FromBody] Task taskToUpdate)
        {
            TaskBusiness tb = new TaskBusiness();
            tb.UpdateTask(taskToUpdate);
            return Ok(taskToUpdate);
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteTask")]
        public IHttpActionResult DeleteTask(string id)
        {
            TaskBusiness tb = new TaskBusiness();
            var isDeleted = tb.DeleteTask(id);
            return Ok(isDeleted);
        }
    }
}
