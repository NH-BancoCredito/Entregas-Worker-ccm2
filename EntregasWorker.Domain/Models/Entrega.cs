using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasWorker.Domain.Models
{
    public class Entrega
    {
        public ObjectId Id { get; set; }    
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }

        public string NombreCliente { get; set; }

        public string DireccionEntrega { get; set; }

        public string Ciudad { get; set; }

        public List<EntregaDetalle> Detalle { get; set; }

    }
}
