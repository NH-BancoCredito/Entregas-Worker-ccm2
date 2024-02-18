  using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = EntregasWorker.Domain.Models;

namespace EntregasWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega
{
    public class RegistrarEntregaMapper: Profile
    {
        public RegistrarEntregaMapper() {
            CreateMap<RegistrarEntregaRequest, Models.Entrega>();

        }
    }
}
