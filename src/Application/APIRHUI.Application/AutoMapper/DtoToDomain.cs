using APIRHIU.Core.DomainObjects;
using APIRHIU.Domain.Models;
using AutoMapper;
using System.Runtime.InteropServices;

namespace APIRHUI.Application.AutoMapper
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            CreateMap<RetornoUnico, CapaEnvelopeEmpregado>()
                .ConstructUsing((RetornoUnico, CapaEnvelopeEmpregado) =>
                {
                    CapaEnvelopeEmpregado capaEnvelopeEmpregado = new CapaEnvelopeEmpregado();

                    CapaEnvelopeEmpregado capa2 = new CapaEnvelopeEmpregado(string.Empty, DateTime.Now, "teste", "4341235234123");

                    return capa2;
                }
                );
        }
    }
}
