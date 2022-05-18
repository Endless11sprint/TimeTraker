using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTraker
{
    public class TasksActive : Tasks
    {
        protected DateTime dateStart = new DateTime();
        public TasksActive()
        {
            
        }
        public TasksActive(int id, string name, string description, DateTime dateStart)
            : base(id, name, description)
        {
            this.dateStart = dateStart;
        }

        public DateTime GetDateStart
        {
            get => dateStart;
        }

        public string DateStartString()
        {
            return $"{dateStart.Day}/{dateStart.Month}/{dateStart.Year}";
        }
    }
}
