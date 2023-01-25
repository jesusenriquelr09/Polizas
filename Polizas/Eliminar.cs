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

namespace Polizas
{
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Eliminar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idpolizas = textBox1.Text;

            if (idpolizas == "")
            {
                MessageBox.Show("Favor de completar el campo vacio");
                return;
            }

            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/api/eliminarpolizas";
            var parameters = new Dictionary<string, string> { { "IDPolizas", idpolizas } };
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = client.PostAsync(url, encodedContent).Result;
            if (response.IsSuccessStatusCode)
            {
                // Do something with response. Example get content:
                string responseString = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(responseString);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar la poliza #" + idpolizas);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
