using MediatR;
using EntregasWorker.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntregasWorker.Domain.Repositories;
using System.Reflection;
using Models = EntregasWorker.Domain.Models;

namespace EntregasWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega
{
    public class RegistrarEntregaHandler : IRequestHandler<RegistrarEntregaRequest, IResult>
    {      
        private readonly IEntregaRepository _entregaRepository;
        private readonly IMapper _mapper;
        public RegistrarEntregaHandler(IEntregaRepository entregaRepository, IMapper mapper)
        {
            _entregaRepository = entregaRepository;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(RegistrarEntregaRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {
                //Aplicando el automapper para convertir el objeto Request a Entrega
                var entrega = _mapper.Map<Models.Entrega>(request);

                /// Registrar entrega
                /// 
                var insertar = await _entregaRepository.Adicionar(entrega);

                if (insertar)
                    response = new SuccessResult();
                else
                    response = new FailureResult();

                return response;
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }

        }

    }
}
