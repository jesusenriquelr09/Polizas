using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizas
{
    public partial class Generica
    {
        [JsonProperty("nombreArticulo")]
        public string NombreArticulo { get; set; }
        [JsonProperty("idPolizas")]
        public int IdPolizas { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("apellido")]
        public string Apellido { get; set; }
        [JsonProperty("sku")]
        public int Sku { get; set; }
        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }
    }
}
