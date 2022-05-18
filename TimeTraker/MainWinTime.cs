using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
//using System.Data;
using System.Data.SqlClient;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TimeTraker
{
    public partial class MainWinTime : Form
    {
        private SqlConnection sqlConnection = null;

       // private List<Tasks> tasksList = new List<Tasks>();

        static private TasksActive tasksMyActive;

        static private Tasks tasksNoActive;

        public MainWinTime()
        {
            InitializeComponent();
        }

        int countPl1 = 1;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            countPl1 += 1;
            if (countPl1 % 2 == 0)
            {
                pictureBox4.Image = Properties.Resources._211648_up_chevron_icon;
                pictureBox5.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox6.Image = Properties.Resources._211645_down_chevron_icon;
                panel3.Size = panel3.MinimumSize;
                panel1.Size = panel1.MaximumSize;
            }
            else
            {
                pictureBox4.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox6.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox5.Image = Properties.Resources._211648_up_chevron_icon;
                panel3.Size = panel3.MinimumSize;
                panel1.Size = panel1.MinimumSize;
            }
                


        }

        int countPl2 = 1;
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            countPl2 += 1;

            if (countPl2 % 2 == 0)
            {
                pictureBox5.Image = Properties.Resources._211648_up_chevron_icon;
                pictureBox4.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox6.Image = Properties.Resources._211645_down_chevron_icon;
                panel3.Size = panel3.MinimumSize;
                panel1.Size = panel1.MinimumSize;
            }
            else
            {
                pictureBox4.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox6.Image = Properties.Resources._211648_up_chevron_icon;
                pictureBox5.Image = Properties.Resources._211645_down_chevron_icon;
                panel3.Size = panel3.MaximumSize;
                panel1.Size = panel1.MinimumSize;
            }
        }

        int countPl3 = 1;
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            countPl3 += 1;
            if (countPl3 % 2 == 0)
            {
                pictureBox4.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox6.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox5.Image = Properties.Resources._211648_up_chevron_icon;
                panel3.Size = panel3.MinimumSize;
                panel1.Size = panel1.MinimumSize;
            }

            else
            {
                pictureBox6.Image = Properties.Resources._211648_up_chevron_icon;
                pictureBox4.Image = Properties.Resources._211645_down_chevron_icon;
                pictureBox5.Image = Properties.Resources._211645_down_chevron_icon;
                panel3.Size = panel3.MaximumSize;
                panel1.Size = panel1.MinimumSize;
            }
                
        }


        private void MainWinTime_Load(object sender, EventArgs e)
        {
            
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);

                sqlConnection.Open();

                Zapoln.flowLayoutPanel2 = flowLayoutPanel2;
                Zapoln.flowLayoutPanel1 = flowLayoutPanel1;

                Zapoln.mainWinTime = this;

                Zapoln zapoln = new Zapoln();
                zapoln.TaskAdd();
                zapoln.TaskOut();

                Zapoln zapolnActive = new Zapoln();
                zapolnActive.TaskActiveAdd();
                zapolnActive.TaskOutActive();

                Zapoln zapolnOver = new Zapoln();
                zapolnOver.TaskOverAdd();
                zapolnOver.TaskOutOver();
                
            }
            catch
            {
                MessageBox.Show($"БД не открылась");
                sqlConnection.Close();
            }
            //_ = new List<int>();
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            while (flowLayoutPanel1.Controls.Count > 0)
            {
                var controltoremove = flowLayoutPanel1.Controls[0];
                flowLayoutPanel1.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }

            while (flowLayoutPanel2.Controls.Count > 0)
            {
                var controltoremove = flowLayoutPanel2.Controls[0];
                flowLayoutPanel2.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }

            sqlConnection.Open();
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Tasks] (Name, Description) VALUES (@Name, @Description)", 
                sqlConnection);

            //DateTime date = DateTime.Now;

            command.Parameters.AddWithValue("Name", textBox1.Text);
            command.Parameters.AddWithValue("Description", textBox2.Text);
           // command.Parameters.AddWithValue("DateStart", $"{date.Month}/{date.Day}/{date.Year} {date.Hour}:{date.Minute}:{date.Second}");

            command.ExecuteNonQuery().ToString();

            Zapoln.mainWinTime = this;

            Zapoln zapoln = new Zapoln();
            zapoln.TaskAdd();
            zapoln.TaskOut();

            Zapoln zapolnActive = new Zapoln();
            zapolnActive.TaskActiveAdd();
            zapolnActive.TaskOutActive();

            Zapoln zapolnOver = new Zapoln();
            zapolnOver.TaskOverAdd();
            zapolnOver.TaskOutOver();

            

            sqlConnection.Close();

            textBox1.Text = null;
            textBox2.Text = null;
        }

        public static void TaskActiveAdd(TasksActive tasksActive)
        {
            tasksMyActive = new TasksActive(tasksActive.GetId, tasksActive.GetName, tasksActive.GetDescription, tasksActive.GetDateStart);
        }

        public void buttonStopEvForActive(object sender, EventArgs e)
        {
            while (flowLayoutPanel1.Controls.Count > 0)
            {
                var controltoremove = flowLayoutPanel1.Controls[0];
                flowLayoutPanel1.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }

            while (flowLayoutPanel2.Controls.Count > 0)
            {
                var controltoremove = flowLayoutPanel2.Controls[0];
                flowLayoutPanel2.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }
            PictureBox picture = sender as PictureBox;
            try
            {
                sqlConnection.Open();
                int item = int.Parse(picture.Name);

                string name = IdDateBase.GetNameActive(item);
                string description = IdDateBase.GetDescriptionActive(item);

                DateTime dateTime = new DateTime();

                dateTime = DateTime.Parse(IdDateBase.GetDateStartActive(item));

                SqlCommand command = new SqlCommand(
                $"INSERT INTO [TasksOver] (Name, Description, DateStart, DateFinish) VALUES (@Name, @Description, @DateStart, @DateFinish)",
                sqlConnection);
                
                DateTime date = DateTime.Now;

                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("Description", description);
                command.Parameters.AddWithValue("DateStart", $"{dateTime.Month}/{dateTime.Day}/{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}");
                command.Parameters.AddWithValue("DateFinish", $"{date.Month}/{date.Day}/{date.Year} {date.Hour}:{date.Minute}:{date.Second}");

                command.ExecuteNonQuery();
                SqlCommand sqlCom = new SqlCommand($"DELETE FROM TasksActive WHERE Id = {item}", sqlConnection);
                int result = sqlCom.ExecuteNonQuery();

               


                Zapoln zapoln = new Zapoln();
                zapoln.TaskAdd();
                zapoln.TaskOut();

                Zapoln zapolnActive = new Zapoln();
                zapolnActive.TaskActiveAdd();
                zapolnActive.TaskOutActive();

                Zapoln zapolnOver = new Zapoln();
                zapolnOver.TaskOverAdd();
                zapolnOver.TaskOutOver();
            }
            catch
            {
                MessageBox.Show($"Ты дурак");
                sqlConnection.Close();
            }
            sqlConnection.Close();
        }
        
        

        public static void TaskNoActiveAdd(Tasks tasksActive)
        {
            tasksNoActive = new Tasks(tasksActive.GetId, tasksActive.GetName, tasksActive.GetDescription);
        }

        public void buttonStartEv(object sender, EventArgs e)
        {
            while (flowLayoutPanel1.Controls.Count > 0)
            {
                var controltoremove = flowLayoutPanel1.Controls[0];
                flowLayoutPanel1.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }
            while (flowLayoutPanel2.Controls.Count > 0)
            {
                var controltoremove = flowLayoutPanel2.Controls[0];
                flowLayoutPanel2.Controls.Remove(controltoremove);
                controltoremove.Dispose();
            }

            PictureBox picture = sender as PictureBox;
            try
            {
                sqlConnection.Open();
                int item = int.Parse(picture.Name);

                string name = IdDateBase.GetName(item);
                string description = IdDateBase.GetDescription(item);
                SqlCommand command = new SqlCommand(
                $"INSERT INTO [TasksActive] (Name, Description, DateStart) VALUES (@Name, @Description, @DateStart)",
                sqlConnection);

                DateTime date = DateTime.Now;

                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("Description", description);
                command.Parameters.AddWithValue("DateStart", $"{date.Month}/{date.Day}/{date.Year} {date.Hour}:{date.Minute}:{date.Second}");

                command.ExecuteNonQuery().ToString();
                

                SqlCommand sqlCom = new SqlCommand($"DELETE FROM Tasks WHERE Id = {item}", sqlConnection);
                int result = sqlCom.ExecuteNonQuery();

               

                Zapoln zapoln = new Zapoln();
                zapoln.TaskAdd();
                zapoln.TaskOut();

                Zapoln zapolnActive = new Zapoln();
                zapolnActive.TaskActiveAdd();
                zapolnActive.TaskOutActive();

                Zapoln zapolnOver = new Zapoln();
                zapolnOver.TaskOverAdd();
                zapolnOver.TaskOutOver();
            }
            catch
            {
                MessageBox.Show($"Ты дурак");
                sqlConnection.Close();
            }

            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<TasksOver> tasksListOver = new List<TasksOver>();
            try
            {
                List<int> id = IdDateBase.IdOver();

                foreach (var item in id)
                {
                    string name = IdDateBase.GetNameOver(item);
                    string description = IdDateBase.GetDescriptionOver(item);
                    DateTime dateTime = new DateTime();

                    dateTime = DateTime.Parse(IdDateBase.GetDateStartOver(item));

                    DateTime dateTimeFinish = new DateTime();

                    dateTimeFinish = DateTime.Parse(IdDateBase.GetDateFinishOver(item));

                    TasksOver tasks = new TasksOver(item, name, description, dateTime, dateTimeFinish);
                    tasksListOver.Add(tasks);
                    //MessageBox.Show($"Элемент {tasks.GetId} содержит имя {tasks.GetName} описание {tasks.GetDescription}");
                    //i++;

                }
            }
            catch
            {
                MessageBox.Show("База данных не доступна");
            }

            try
            {
                string fg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Fradm.TTF");
                BaseFont fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 10);

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("TestPDF.pdf", FileMode.Create));

                doc.Open();
                Paragraph paragraph = new Paragraph(10, "Отчет", fgFont);//интервал между строками, текст, шрифт
                doc.Add(paragraph);

                //////////////////////////////////////////////////////////////////
                PdfPTable table = new PdfPTable(4);


                table.AddCell("Date");
                table.AddCell("Name");
                table.AddCell("Description");
                table.AddCell("Duration");


                for (int i = 0; i < tasksListOver.Count; i++)
                {
                    table.AddCell(new Phrase($"{tasksListOver[i].DateStartString()}", fgFont));
                    table.AddCell(new Phrase($"{tasksListOver[i].GetName}", fgFont));
                    table.AddCell(new Phrase($"{tasksListOver[i].GetDescription}", fgFont));
                    table.AddCell(new Phrase($"{tasksListOver[i].DurationTime()}", fgFont));

                }



                doc.Add(table);
                //////////////////////////////////////////////////////////////////

                doc.Close();
            }
            catch
            {
                MessageBox.Show("Записи не отрисовались");
            }

            MessageBox.Show("PDF успешно создан!!!");
        }

        bool statusChange = true;

        private void button3_Click(object sender, EventArgs e)
        {

            //bool statusChange = true;

            
            if (statusChange==false)
            {

                while (flowLayoutPanel2.Controls.Count > 0)
                {
                    var controltoremove = flowLayoutPanel2.Controls[0];
                    flowLayoutPanel2.Controls.Remove(controltoremove);
                    controltoremove.Dispose();
                }

                Zapoln zapolnOver = new Zapoln();
                zapolnOver.TaskOverAdd();
                zapolnOver.TaskOutOver();

                
            }
            else if (statusChange==true)
            {
                while (flowLayoutPanel2.Controls.Count > 0)
                {
                    var controltoremove = flowLayoutPanel2.Controls[0];
                    flowLayoutPanel2.Controls.Remove(controltoremove);
                    controltoremove.Dispose();
                }

                Zapoln zapolnOver = new Zapoln();
                zapolnOver.TaskOverAdd();
                zapolnOver.TaskOutOverChange();

                
            }
            statusChange = !statusChange;
        }
    }









    
}
