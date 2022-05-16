using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
//using System.Data;
using System.Data.SqlClient;

namespace TimeTraker
{
    class Zapoln
    {
        private List<Tasks> tasksList = new List<Tasks>();
        private List<TasksActive> tasksListActive = new List<TasksActive>();
        private List<TasksOver> tasksListOver = new List<TasksOver>();

        public static FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
        public static FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();

        public static MainWinTime mainWinTime;

        public void TaskAdd()
        {
            List<int> id = IdDateBase.Id();

            foreach (var item in id)
            {
                string name = IdDateBase.GetName(item);
                string description = IdDateBase.GetDescription(item);
                Tasks tasks = new Tasks(item, name, description);
                tasksList.Add(tasks);
                //MessageBox.Show($"Элемент {tasks.GetId} содержит имя {tasks.GetName} описание {tasks.GetDescription}");
                //i++;

            }
        }

        public void TaskActiveAdd()
        {
            List<int> id = IdDateBase.IdActive();

            foreach (var item in id)
            {
                string name = IdDateBase.GetNameActive(item);
                string description = IdDateBase.GetDescriptionActive(item);
                DateTime dateTime = new DateTime();

                IdDateBase.GetDateStartActive(item, dateTime);

                TasksActive tasks = new TasksActive(item, name, description, dateTime);
                tasksListActive.Add(tasks);
                //MessageBox.Show($"Элемент {tasks.GetId} содержит имя {tasks.GetName} описание {tasks.GetDescription}");
                //i++;

            }
        }

        public void TaskOverAdd()
        {
            List<int> id = IdDateBase.IdOver();

            foreach (var item in id)
            {
                string name = IdDateBase.GetNameOver(item);
                string description = IdDateBase.GetDescriptionOver(item);
                DateTime dateTime = new DateTime();

                IdDateBase.GetDateStartOver(item, dateTime);

                DateTime dateTimeFinish = new DateTime();

                IdDateBase.GetDateStartOver(item, dateTimeFinish);

                TasksOver tasks = new TasksOver(item, name, description, dateTime, dateTimeFinish);
                tasksListOver.Add(tasks);
                //MessageBox.Show($"Элемент {tasks.GetId} содержит имя {tasks.GetName} описание {tasks.GetDescription}");
                //i++;

            }
        }

        public void TaskOut()
        {
            for (int i = 0; i < tasksList.Count; i++)
            {
                Panel panel = new Panel();
                panel.Tag = i;
                //panel.Width = 487;
                //panel.Height = 122;
                panel.MinimumSize = new System.Drawing.Size(387, 122);
                panel.MaximumSize = new System.Drawing.Size(387, 122);
                //panel.Controls.Add(DescrTask1);
                //panel.Controls.Add(this.pictureBox13);
                //panel.Controls.Add(this.pictureBox14);
                //panel.Controls.Add(NameTask1);
                //panel.Location = new System.Drawing.Point(4, 4);
                //panel.Margin = new System.Windows.Forms.Padding(4);
                //panel.Size = new System.Drawing.Size(487, 122);
                //panel.TabIndex = 4;

                Label DescrTask1 = new Label();
                DescrTask1.AutoSize = true;
                DescrTask1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                DescrTask1.Location = new System.Drawing.Point(23, 69);
                DescrTask1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                DescrTask1.MaximumSize = new System.Drawing.Size(200, 26);
                DescrTask1.Name = "DescrTask1";
                DescrTask1.Size = new System.Drawing.Size(166, 25);
                DescrTask1.TabIndex = 3;
                DescrTask1.Text = $"{tasksList[i].GetDescription}";
                panel.Controls.Add(DescrTask1);

                PictureBox pictureBox13 = new PictureBox();
                pictureBox13.Image = global::TimeTraker.Properties.Resources._3669217_stop_ic_icon;
                pictureBox13.Location = new System.Drawing.Point(300, 33);
                pictureBox13.Margin = new System.Windows.Forms.Padding(4);
                pictureBox13.Name = "pictureBox13";
                pictureBox13.Size = new System.Drawing.Size(67, 62);
                pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //pictureBox13.TabIndex = 2;
                pictureBox13.TabStop = false;
                //pictureBox13.Click += MainWinTime.buttonStopEv;
                panel.Controls.Add(pictureBox13);

                PictureBox pictureBox14 = new PictureBox();
                pictureBox14.Image = global::TimeTraker.Properties.Resources._211876_play_icon;
                pictureBox14.Location = new System.Drawing.Point(230, 33);
                pictureBox14.Margin = new System.Windows.Forms.Padding(4);
                pictureBox14.Name = $"{tasksList[i].GetId}";
                pictureBox14.Size = new System.Drawing.Size(67, 62);
                pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //pictureBox14.TabIndex = 1;
                pictureBox14.TabStop = false;

                MainWinTime.TaskNoActiveAdd(tasksList[i]);
                pictureBox14.Click += mainWinTime.buttonStartEv;

                panel.Controls.Add(pictureBox14);
                
                Label NameTask1 = new Label();
                NameTask1.AutoSize = true;
                NameTask1.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                NameTask1.Location = new System.Drawing.Point(20, 16);
                NameTask1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                NameTask1.MaximumSize = new System.Drawing.Size(200, 42);
                NameTask1.Name = "NameTask1";
                NameTask1.Size = new System.Drawing.Size(124, 39);
                NameTask1.TabIndex = 0;
                NameTask1.Text = $"{tasksList[i].GetName}";
                panel.Controls.Add(NameTask1);


                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        public void TaskOutActive()
        {
            for (int i = 0; i < tasksListActive.Count; i++)
            {
                Panel panel = new Panel();
                panel.Tag = i;
                //panel.Width = 487;
                //panel.Height = 122;
                panel.MinimumSize = new System.Drawing.Size(387, 122);
                panel.MaximumSize = new System.Drawing.Size(387, 122);
                //panel.Controls.Add(DescrTask1);
                //panel.Controls.Add(this.pictureBox13);
                //panel.Controls.Add(this.pictureBox14);
                //panel.Controls.Add(NameTask1);
                //panel.Location = new System.Drawing.Point(4, 4);
                //panel.Margin = new System.Windows.Forms.Padding(4);
                //panel.Size = new System.Drawing.Size(487, 122);
                //panel.TabIndex = 4;

                Label DescrTask1 = new Label();
                DescrTask1.AutoSize = true;
                DescrTask1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                DescrTask1.Location = new System.Drawing.Point(23, 69);
                DescrTask1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                DescrTask1.MaximumSize = new System.Drawing.Size(200, 26);
                DescrTask1.Name = "DescrTask1";
                DescrTask1.Size = new System.Drawing.Size(166, 25);
                DescrTask1.TabIndex = 3;
                DescrTask1.Text = $"{tasksListActive[i].GetDescription}";
                panel.Controls.Add(DescrTask1);

                PictureBox pictureBox13 = new PictureBox();
                pictureBox13.Image = global::TimeTraker.Properties.Resources._3669217_stop_ic_icon;
                pictureBox13.Location = new System.Drawing.Point(300, 33);
                pictureBox13.Margin = new System.Windows.Forms.Padding(4);
                pictureBox13.Name = $"{tasksListActive[i].GetId}";
                pictureBox13.Size = new System.Drawing.Size(67, 62);
                pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //pictureBox13.TabIndex = 2;
                pictureBox13.TabStop = false;

                MainWinTime.TaskActiveAdd(tasksListActive[i]);
                pictureBox13.Click += mainWinTime.buttonStopEvForActive; 

                panel.Controls.Add(pictureBox13);

                /*PictureBox pictureBox14 = new PictureBox();
                pictureBox14.Image = global::TimeTraker.Properties.Resources._211876_play_icon;
                pictureBox14.Location = new System.Drawing.Point(230, 33);
                pictureBox14.Margin = new System.Windows.Forms.Padding(4);
                pictureBox14.Name = "pictureBox14";
                pictureBox14.Size = new System.Drawing.Size(67, 62);
                pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //pictureBox14.TabIndex = 1;
                pictureBox14.TabStop = false;
                panel.Controls.Add(pictureBox14);
                */
                Label NameTask1 = new Label();
                NameTask1.AutoSize = true;
                NameTask1.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                NameTask1.Location = new System.Drawing.Point(20, 16);
                NameTask1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                NameTask1.MaximumSize = new System.Drawing.Size(200, 42);
                NameTask1.Name = "NameTask1";
                NameTask1.Size = new System.Drawing.Size(124, 39);
                NameTask1.TabIndex = 0;
                NameTask1.Text = $"{tasksListActive[i].GetName}";
                panel.Controls.Add(NameTask1);


                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        public void TaskOutOver()
        {
            for (int i = 0; i < tasksListOver.Count; i++)
            {
                Panel panel = new Panel();
                panel.Tag = i;
                //panel.Width = 487;
                //panel.Height = 122;
                panel.MinimumSize = new System.Drawing.Size(387, 122);
                panel.MaximumSize = new System.Drawing.Size(387, 122);
                //panel.Controls.Add(DescrTask1);
                //panel.Controls.Add(this.pictureBox13);
                //panel.Controls.Add(this.pictureBox14);
                //panel.Controls.Add(NameTask1);
                //panel.Location = new System.Drawing.Point(4, 4);
                //panel.Margin = new System.Windows.Forms.Padding(4);
                //panel.Size = new System.Drawing.Size(487, 122);
                //panel.TabIndex = 4;

                Label DescrTask1 = new Label();
                DescrTask1.AutoSize = true;
                DescrTask1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                DescrTask1.Location = new System.Drawing.Point(23, 69);
                DescrTask1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                DescrTask1.MaximumSize = new System.Drawing.Size(200, 26);
                DescrTask1.Name = "DescrTask1";
                DescrTask1.Size = new System.Drawing.Size(166, 25);
                DescrTask1.TabIndex = 3;
                DescrTask1.Text = $"{tasksListOver[i].GetDescription}";
                panel.Controls.Add(DescrTask1);

                /*PictureBox pictureBox13 = new PictureBox();
                pictureBox13.Image = global::TimeTraker.Properties.Resources._3669217_stop_ic_icon;
                pictureBox13.Location = new System.Drawing.Point(300, 33);
                pictureBox13.Margin = new System.Windows.Forms.Padding(4);
                pictureBox13.Name = $"{tasksListActive[i].GetId}";
                pictureBox13.Size = new System.Drawing.Size(67, 62);
                pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //pictureBox13.TabIndex = 2;
                pictureBox13.TabStop = false;

                MainWinTime.TaskActiveAdd(tasksListActive[i]);
                pictureBox13.Click += mainWinTime.buttonStopEvForActive;

                panel.Controls.Add(pictureBox13);

                /*PictureBox pictureBox14 = new PictureBox();
                pictureBox14.Image = global::TimeTraker.Properties.Resources._211876_play_icon;
                pictureBox14.Location = new System.Drawing.Point(230, 33);
                pictureBox14.Margin = new System.Windows.Forms.Padding(4);
                pictureBox14.Name = "pictureBox14";
                pictureBox14.Size = new System.Drawing.Size(67, 62);
                pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                //pictureBox14.TabIndex = 1;
                pictureBox14.TabStop = false;
                panel.Controls.Add(pictureBox14);
                */
                Label NameTask1 = new Label();
                NameTask1.AutoSize = true;
                NameTask1.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                NameTask1.Location = new System.Drawing.Point(20, 16);
                NameTask1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                NameTask1.MaximumSize = new System.Drawing.Size(200, 42);
                NameTask1.Name = "NameTask1";
                NameTask1.Size = new System.Drawing.Size(124, 39);
                NameTask1.TabIndex = 0;
                NameTask1.Text = $"{tasksListOver[i].GetName}";
                panel.Controls.Add(NameTask1);


                flowLayoutPanel2.Controls.Add(panel);
            }
        }
    }
}
