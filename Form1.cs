using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkladSystemManager
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sklad.accdb";
        private OleDbConnection myConnection;
        public string procesNow, placeNow;
        public int page=0;
        public bool acces = false;
        public string[] processes= {"Контроль качества","Присвоение уникального кода","Сортировка","Сбор заказа","Упаковка", "Отгрузка" ,"Доставка"};
        public string[] places = {"Зона предварительного хранения","Зона контроля качества","Сортировочный конвеер","Зона сбоки и упаковки","Зона отгрузки","Товар за пределами склада"};
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "skladDataSet.skadItemsTable". При необходимости она может быть перемещена или удалена.
            this.skadItemsTableTableAdapter.Fill(this.skladDataSet.skadItemsTable);
            NewMaterial();
            procesNow = "Отгрузка";
            placeNow = places[0];
            label4.Text = " " + procesNow;
            label3.Text = " " + placeNow;
            button1.Enabled = acces;
        }
        public void PageMananger(int page)
        {
            
                procesNow = processes[page];
                switch (page)
                {
                    case 0:
                        placeNow = places[0];
                        break;
                    case 1:
                        placeNow = places[1];
                        break;
                    case 2:
                        placeNow = places[1];
                        string str = RandomCode();
                        string query1 = "UPDATE skadItemsTable SET tovar =  " + "('" + str + "')";
                        OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                        command1.ExecuteNonQuery();
                        break;
                    case 3:
                        placeNow = places[2];
                        break;
                    case 4:
                        placeNow = places[3];
                        break;
                    case 5:
                        placeNow = places[3];
                        break;
                    case 6:
                        placeNow = places[4];
                        break;
                    case 7:
                        placeNow = places[5];
                        break;
                }
                string query = "UPDATE skadItemsTable SET status =  " + "('" + procesNow + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                label4.Text = " " + procesNow;
                label3.Text = " " + placeNow;
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
        public void NewMaterial()
        {
            for (int i = 0; i < 10; i++)
            {
                string categoryName = RandomCategory();
                string status = "Отгрука";
                string query = "INSERT INTO skadItemsTable (category,status)VALUES  " + "('" + categoryName + "','" + status + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
        }
        public string RandomCategory()
        {
            Random random = new Random();
            int category = random.Next(0, 6);
            string res = "";
            switch (category)
            {
                case 0:
                    res = "Продукты питания";
                    break;
                case 1:
                    res = "Техника и гаджеты";
                    break;
                case 2:
                    res = "Одежда и обувь";
                    break;
                case 3:
                    res = "Бытовые приборы";
                    break;
                case 4:
                    res = "Бытовая химия";
                    break;
                case 5:
                    res = "Литература";
                    break;
                case 6:
                    res = "Сувениры";
                    break;

            }
            return res;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
        }
        public int i = 0;
        public int a = 25;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            i++;
            if (i>25)
            {
                acces = true;
                button2.Enabled = false;
                button1.Enabled=acces;
                i = 0;
                timer1.Stop();
            }
            label5.Text = (a - i).ToString();
        }
        public string RandomCode()
        { 
            Random random = new Random();
            Random random1 = new Random();
            int one=random1.Next(0, 9);
            int two= random1.Next(0, 9);
            int three = random1.Next(0, 9);
            int four = random1.Next(0, 9);
            int five = random1.Next(1, 26);
            int six = random1.Next(1, 26);
            int seven = random1.Next(1, 26);
            int eigth = random1.Next(1, 26);
            int ninne = random1.Next(0, 9);
            int ten = random1.Next(0, 9);
            int eleven = random1.Next(0, 9);
            int twelwe = random1.Next(0, 9);
            string code= one.ToString()+ two.ToString() + three.ToString() + four.ToString() + Switcharnick(five).ToString() + Switcharnick(six).ToString() + Switcharnick(seven).ToString() + Switcharnick(eigth).ToString() + ninne.ToString() + ten.ToString() + eleven.ToString()+ twelwe.ToString();
            return code;
        }
        public string Switcharnick(int chir)
        {
            string str="";
            switch (chir)
            { 
                case 1:
                    str = "A";
                    break;
                case 2:
                    str = "B";
                    break;
                case 3:
                    str = "C";
                    break;
                case 4:
                    str = "D";
                    break;
                case 5:
                    str = "E";
                    break;
                case 6:
                    str = "F";
                    break;
                case 7:
                    str = "G";
                    break;
                case 8:
                    str = "H";
                    break;
                case 9:
                    str = "I";
                    break;
                case 10:
                    str = "J";
                    break;
                case 11:
                    str = "K";
                    break;
                case 12:
                    str = "L";
                    break;
                case 13:
                    str = "M";
                    break;
                case 14:
                    str = "N";
                    break;
                case 15:
                    str = "O";
                    break;
                case 16:
                    str = "P";
                    break;
                case 17:
                    str = "R";
                    break;
                case 18:
                    str = "S";
                    break;
                case 19:
                    str = "T";
                    break;
                case 20:
                    str = "U";
                    break;
                case 21:
                    str = "V";
                    break;
                case 22:
                    str = "W";
                    break;
                case 23:
                    str = "X";
                    break;
                case 24:
                    str = "Y";
                    break;
                case 25:
                    str = "Z";
                    break;
                case 26:
                    break;
            }
            return str;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (acces)
            {
                if (page == 6)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    MessageBox.Show("Весь процесс завершен");
                }
                else
                {
                    PageMananger(page);
                    this.skadItemsTableTableAdapter.Fill(this.skladDataSet.skadItemsTable);
                    label5.Text = page.ToString();
                    page++;
                    acces = false;
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
        }
    }
}
