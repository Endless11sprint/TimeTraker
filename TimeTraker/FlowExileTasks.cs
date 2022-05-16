using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTraker
{
    class FlowExileTasks
    {
        private FlowLayoutPanel flow;

        public FlowExileTasks(FlowLayoutPanel Exile)
        {
            flow = Exile;
        }

        public FlowLayoutPanel GetExile
        {
            get => flow;
        }
    }
}
