using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTraker
{
    public class TasksOver : TasksActive
    {
        protected DateTime dateFinish = new DateTime();

        public TasksOver(int id, string name, string description, DateTime dateStart, DateTime dateFinish)
            : base(id, name, description, dateStart)
        {
            this.dateFinish = dateFinish;
        }

        public TasksOver()
        {
            
        }
        public DateTime GetDateFinish
        {
            get => dateFinish;
        }
    }
}
