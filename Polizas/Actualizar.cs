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
    public partial class Actualizar : Form
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idPolizas = textBox1.Text;
            string sku = textBox2.Text;

            if (idPolizas == "" || sku == "")
            {
                MessageBox.Show("Favor de completar los campos vacios");
                return;
            }

            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/api/actualizarpolizas";
            var parameters = new Dictionary<string, string> { { "IDPolizas", idPolizas }, { "SKU", sku } };
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = client.PostAsync(url, encodedContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(responseString);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
