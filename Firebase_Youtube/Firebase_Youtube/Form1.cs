using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace Firebase_Youtube
{
    public partial class Form1 : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "iESnzQcUWSg3CbDFckGzoGe7gEYWSNRTMb4cJRFO",
            BasePath = "https://fir-c2a1f-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {

                MessageBox.Show("connection is established !");

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = new Data
            {


                id = textBox1.Text,
                Name = textBox2.Text,
                Age = textBox3.Text,
                Phone = textBox4.Text

            };
            SetResponse response = await client.SetTaskAsync("Information/" + textBox1.Text, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted " + result.id);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Information/" + textBox1.Text);
            Data obj = response.ResultAs<Data>();

            textBox1.Text = obj.id;
            textBox2.Text = obj.Name;
            textBox3.Text = obj.Age;
            textBox4.Text = obj.Phone;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var Data = new Data
            {
                id = textBox1.Text,
                Name = textBox2.Text,
                Age = textBox3.Text,
                Phone = textBox4.Text
            };
            FirebaseResponse response = await client.UpdateTaskAsync<Data>("Information/"+textBox1.Text,Data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Updated at ID" + result.id);

        }
    }

}