using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTraker
{
    public class Tasks
    {
        protected int id;
        protected string name;
        
        protected string description;
        //private DateTime dateStart = new DateTime();
        //private DateTime dateFinish = new DateTime();

        public Tasks(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
        public Tasks()
        {
            
        }

        public int GetId
        {
            get => id;
        }

        public string GetName
        {
            get => name;
        }

        public string GetDescription
        {
            get => description;
        }

        /*public DateTime GetDateStart
        {
            get => dateStart;
        }
        */

       /* public DateTime GetDateFinish
        {
            get => dateFinish;
        }
       */
    }
}
