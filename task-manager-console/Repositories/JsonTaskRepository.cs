using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ExercicioPreApi2.Entites;

namespace ExercicioPreApi2.Repositories
{
    internal class JsonTaskRepository : ITaskRepository
    {

        private readonly string _filePath;

        public JsonTaskRepository()
        {
            string basepath = AppDomain.CurrentDomain.BaseDirectory;
            _filePath = Path.Combine(basepath, "tasks.json");
        }

        public List<TaskItem> GetAllTasks()
        {

            if (!File.Exists(_filePath))
            {

                return new List<TaskItem>();

            }

            string json = File.ReadAllText(_filePath);
            var tasks = JsonSerializer.Deserialize<List<TaskItem>>(json);
            return tasks ?? new List<TaskItem>();
        }

        public void SaveAll(List<TaskItem> tasks) { 
            
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(_filePath, json);
        
        }
    }
}
