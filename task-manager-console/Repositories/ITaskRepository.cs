using System;
using System.Collections.Generic;
using System.Text;
using ExercicioPreApi2.Entites;

namespace ExercicioPreApi2.Repositories
{
    internal interface ITaskRepository
    {
        List<TaskItem> GetAllTasks();
        void SaveAll(List<TaskItem> tasks);
    }
}
