using MediatR;
using EntregasWorker.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntregasWorker.Domain.Models;
using MongoDB.Bson;

namespace EntregasWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega
{
    public class RegistrarEntregaRequest: IRequest<IResult>
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }

        public string NombreCliente { get; set; }

        public string DireccionEntrega { get; set; }

        public string Ciudad { get; set; }

        public List<EntregaDetalle> Detalle { get; set; }

    }

}
