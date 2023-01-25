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
    public partial class Guardar : Form
    {
        public Guardar()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idpolizas = textBox1.Text;
            string empleadoGenero = textBox2.Text;
            string sku = textBox3.Text;
            string cantidad = textBox4.Text;

            if (idpolizas == "" || empleadoGenero == "" || sku == "" || cantidad == "")
            {
                MessageBox.Show("Favor de completar los campos vacios");
                return;
            }

            HttpClient client = new HttpClient();
            var url = "http://localhost:8080/api/guardarpolizas";
            var parameters = new Dictionary<string, string> { { "IDPolizas", idpolizas }, { "EmpleadoGenero", empleadoGenero }, { "SKU", sku }, { "Cantidad", cantidad } };
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = client.PostAsync(url, encodedContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var jsonDeserialized = JsonConvert.DeserializeObject<Generica>(json.Substring(1, json.Length - 2));

                if (jsonDeserialized == null)
                {
                    MessageBox.Show("Ocurrio un error al almacenar la informacion de la poliza #" + idpolizas);
                    return;
                }

                var IdPolizas = jsonDeserialized.IdPolizas;
                var Cantidad = jsonDeserialized.Cantidad;
                var Nombre = jsonDeserialized.Nombre.Trim();
                var Apellido = jsonDeserialized.Apellido.Trim();
                var Sku = jsonDeserialized.Sku;
                var NombreArticulo = jsonDeserialized.NombreArticulo.Trim();

                MessageBox.Show("Informacion guardada con exito para la poliza #" + idpolizas);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al almacenar la informacion de la poliza #" + idpolizas);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Guardar_Load(object sender, EventArgs e)
        {

        }
    }
}
