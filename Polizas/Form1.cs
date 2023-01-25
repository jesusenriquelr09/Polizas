using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polizas
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar consultar = new Consultar();
            consultar.Show();
        }

        private void actualizarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Actualizar actualizar = new Actualizar();
            actualizar.Show();
        }

        private void guardarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Guardar guardar = new Guardar();
            guardar.Show();
        }

        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Eliminar eliminar = new Eliminar();
            eliminar.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
