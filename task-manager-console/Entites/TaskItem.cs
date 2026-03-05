using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ExercicioPreApi2.Entites
{
    internal class TaskItem
    {
        private static int _contador = 1;
        public int Id { get; private set; }
        public string Description { get; private set; }
        public bool Completed { get; private set; }
        public DateTime CreatedAt { get; private set; }


        public TaskItem(string title, string description)
        {

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Titulo é obrigatorio");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Descricao é obrigatorio");
            }

            Id = _contador++;
            Completed = false;
            CreatedAt = DateTime.Now;
        }


        public void MarcarComoFeito()
        {
            if (!Completed)
            {
                Completed = true;

            }
        }
    }


    
}
