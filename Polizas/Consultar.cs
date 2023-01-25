using Newtonsoft.Json;
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
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idpolizas = textBox1.Text;

            if (idpolizas == "")
            {
                MessageBox.Show("Favor de completar los campos vacios");
                return;
            }

            UriBuilder builder = new UriBuilder("http://localhost:8080/api/obtenerpolizas");
            builder.Query = "IDPolizas=" + idpolizas;

            //Create a query
            HttpClient client = new HttpClient();
            var response = client.GetAsync(builder.Uri).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var jsonDeserialized = JsonConvert.DeserializeObject<Generica>(json.Substring(1, json.Length - 2));

                if (jsonDeserialized == null)
                {
                    MessageBox.Show("No se encontro informacion de la poliza #" + idpolizas);
                    return;
                }

                var IdPolizas = jsonDeserialized.IdPolizas;
                var Cantidad = jsonDeserialized.Cantidad;
                var Nombre = jsonDeserialized.Nombre.Trim();
                var Apellido = jsonDeserialized.Apellido.Trim();
                var Sku = jsonDeserialized.Sku;
                var NombreArticulo = jsonDeserialized.NombreArticulo.Trim();


                textBox2.Text = IdPolizas.ToString();
                textBox3.Text = Cantidad.ToString();
                textBox4.Text = Nombre;
                textBox5.Text = Apellido;
                textBox6.Text = Sku.ToString();
                textBox7.Text = NombreArticulo;

            }
        }

        private void Consultar_Load(object sender, EventArgs e)
        {

        }
    }
}
