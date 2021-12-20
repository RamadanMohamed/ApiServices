using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace company.Desktop.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillEmployeeTodataGrideView();
            FillEmployeeTocombox();

        }

        private void FillEmployeeTocombox()
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:9090/api/employees").Result;
            if (result.IsSuccessStatusCode)
            {
                var emp = result.Content.ReadAsAsync<List<EmploeesGet>>().Result;
                comboBox1.DataSource = emp;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }

        }

        private void FillEmployeeTodataGrideView()
        {
            HttpClient Client = new HttpClient();
            var result=Client.GetAsync("http://localhost:9090/api/employees").Result;
            if (result.IsSuccessStatusCode)
            {
                var emp = result.Content.ReadAsAsync<List<EmploeesGet>>().Result;
                dataGridView1.DataSource = emp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmploeesGet employees = new EmploeesGet
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                Age = int.Parse(textBox3.Text),
                Salary = int.Parse(textBox4.Text),
                Deptid = int.Parse(textBox5.Text)
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9090");
            var result=client.PostAsJsonAsync("api/employees", employees).Result;
            if (result.IsSuccessStatusCode)
            {
                FillEmployeeTodataGrideView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmploeesGet employees = new EmploeesGet
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                Age = int.Parse(textBox3.Text),
                Salary = int.Parse(textBox4.Text),
                Deptid = int.Parse(textBox5.Text)
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9090");
            var result = client.PutAsJsonAsync($"api/employees/{textBox1.Text}", employees).Result;
            if (result.IsSuccessStatusCode)
            {
                FillEmployeeTodataGrideView();
                FillEmployeeTocombox();
            }
            else
            {
                MessageBox.Show("not Updated");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync($"http://localhost:9090/api/employees/{comboBox1.SelectedValue}").Result;
            if (result.IsSuccessStatusCode)
            {
                var emp = result.Content.ReadAsAsync<EmploeesGet>().Result;
                textBox1.Text = emp.Id.ToString();
                textBox2.Text = emp.Name;
                textBox3.Text = emp.Age.ToString();
                textBox4.Text = emp.Salary.ToString();
                textBox5.Text = emp.Deptid.ToString();
                textBox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync($"http://localhost:9090/api/employees/{comboBox1.SelectedValue}").Result;
            
            if (result.IsSuccessStatusCode)
            {
                FillEmployeeTodataGrideView();
                FillEmployeeTocombox();
            }
        }
    }
}
