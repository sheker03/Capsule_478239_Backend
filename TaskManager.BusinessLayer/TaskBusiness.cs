using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DataLayer;
using TaskManager.Model;

namespace TaskManager.BusinessLayer
{
    public class TaskBusiness
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Task> GetAllTasks()
        {
            using (TaskDBContext _db = new TaskDBContext())
            {
                return _db.Tasks.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task GetTaskByID(string id)
        {
            using (TaskDBContext _db = new TaskDBContext())
            {
                List<Task> allTasks = (from task1 in _db.Tasks
                                       select task1).ToList();
                Model.Task task = allTasks.Where(a => a.Task_ID == id).FirstOrDefault();
                return task;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTask"></param>
        public void AddTask(Task newTask)
        {
            using (TaskDBContext _db = new TaskDBContext())
            {
                _db.Tasks.Add(newTask);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="taskToUpdate"></param>
        public void UpdateTask(Task taskToUpdate)
        {
            using (TaskDBContext _db = new TaskDBContext())
            {
                Task updateTask = _db.Tasks.FirstOrDefault(a => a.Task_ID == taskToUpdate.Task_ID);
                if (updateTask != null)
                {
                    _db.Tasks.Remove(updateTask);
                    _db.Tasks.Add(taskToUpdate);
                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception(string.Format("Task - {0} not found", taskToUpdate.Task_Name));
                }
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTask(string id)
        {
            using (TaskDBContext _db = new TaskDBContext())
            {
                Task taskToDelete = _db.Tasks.FirstOrDefault(a => a.Task_ID == id);
                if (taskToDelete != null)
                {
                    _db.Tasks.Remove(taskToDelete);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception(string.Format("Task - {0} not found", taskToDelete.Task_Name));
                }
            }
        }


    }
}
