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
                    zapolnActive.TaskOverAdd();
                    zapolnActive.TaskOutOver();

                }
                catch
                {
                    throw new TheDatabaseNotOpenException("Наше исключение");
                }
            //_ = new List<int>();
            sqlConnection.Close();
            }
            catch(TheDatabaseNotOpenException Ex)
            {
                MessageBox.Show($"Ошибка: {Ex.Message}");
                sqlConnection.Close();
                Loger.AddLine(Ex.Message);
            }
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


            try
            {


                try
                {
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
                    zapolnActive.TaskOverAdd();
                    zapolnActive.TaskOutOver();



                    sqlConnection.Close();

                    textBox1.Text = null;
                    textBox2.Text = null;
                }
                catch
                {
                    throw new ButtonNoWorkException("не сработала кнопка добавления ивента");
                }
            }
            catch (ButtonNoWorkException Ex)
            {
                MessageBox.Show($"Ошибка: {Ex.Message}");
                sqlConnection.Close();
                Loger.AddLine(Ex.Message);
            }
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
                try
                {
                    sqlConnection.Open();
                    int item = int.Parse(picture.Name);

                    string name = IdDateBase.GetNameActive(item);
                    string description = IdDateBase.GetDescriptionActive(item);

                    DateTime dateTime = new DateTime();

                    IdDateBase.GetDateStartActive(item, dateTime);

                    SqlCommand command = new SqlCommand(
                    $"INSERT INTO [TasksOver] (Name, Description, DateStart,DateFinish) VALUES (@Name, @Description, @DateStart, @DateFinish)",
                    sqlConnection);

                    DateTime date = DateTime.Now;

                    command.Parameters.AddWithValue("Name", name);
                    command.Parameters.AddWithValue("Description", description);
                    command.Parameters.AddWithValue("DateStart", $"{dateTime.Month}/{dateTime.Day}/{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}");
                    command.Parameters.AddWithValue("DateFinish", $"{date.Month}/{date.Day}/{date.Year} {date.Hour}:{date.Minute}:{date.Second}");


                    SqlCommand sqlCom = new SqlCommand($"DELETE FROM TasksActive WHERE Id = {item}", sqlConnection);
                    int result = sqlCom.ExecuteNonQuery();

                    command.ExecuteNonQuery().ToString();


                    Zapoln zapoln = new Zapoln();
                    zapoln.TaskAdd();
                    zapoln.TaskOut();

                    Zapoln zapolnActive = new Zapoln();
                    zapolnActive.TaskActiveAdd();
                    zapolnActive.TaskOutActive();

                    Zapoln zapolnOver = new Zapoln();
                    zapolnActive.TaskOverAdd();
                    zapolnActive.TaskOutOver();
                }
                catch
                {
                    throw new ButtonNoWorkException("не сработала кнопка остановки ивента");
                }
                sqlConnection.Close();
            }

            catch(ButtonNoWorkException Ex)
            {
                MessageBox.Show($"Ошибка: {Ex.Message}");
                sqlConnection.Close();
                Loger.AddLine(Ex.Message);
            }


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
                    zapolnActive.TaskOverAdd();
                    zapolnActive.TaskOutOver();
                }
                catch
                {
                    throw new ButtonNoWorkException("не сработала кнопка активации ивента");
                }

                sqlConnection.Close();
            }
            catch(ButtonNoWorkException Ex)
            {
                MessageBox.Show($"Ошибка: {Ex.Message}");
                sqlConnection.Close();
            }
        }
    }









    
}
