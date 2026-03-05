using ExercicioPreApi2.Entites;
using ExercicioPreApi2.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExercicioPreApi2.Services
{
    internal class TaskServices
    {

        private readonly ITaskRepository _taskRepository;


        public void CreateTask(string taskName, string taskDescription)
        {
            var taskList = _taskRepository.GetAllTasks();
            taskList.Add(new TaskItem(taskName, taskDescription));
            _taskRepository.SaveAll(taskList);
        }

        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> taskList = _taskRepository.GetAllTasks();

              return taskList;
            
        }

        public TaskItem GetTaskById(int id) {

            var task = _taskRepository.GetAllTasks();
            TaskItem taskId = task.FirstOrDefault(t => t.Id == id);

            if (taskId != null)
            {
                return taskId;
            } else
            {
                throw new ArgumentException("Tarefa nao encontrada");
            }
           
        }

        public void DeleteTaskById(int id) {
            var task = _taskRepository.GetAllTasks();
            TaskItem taskId = task.FirstOrDefault(t => t.Id == id);

            if (taskId != null) {

                task.Remove(taskId);
            }
            else
            {
                throw new ArgumentException("Tarefa nao encontrada");
            }

            _taskRepository.SaveAll(task);

        }

        public void CompleteTask(int id) {
            var task = _taskRepository.GetAllTasks();
            TaskItem taskId = task.FirstOrDefault(t => t.Id == id);

            if (taskId != null) {
                taskId.MarcarComoFeito();
            
            }
            else
            {
                throw new ArgumentException("Tarefa nao encontrada");
            }

            _taskRepository.SaveAll(task);

        }


    }
}