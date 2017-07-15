using CidadaoAlerta.Application.Application;
using CidadaoAlerta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace CidadaoAlertaWS.Controllers
{
    public class OcorrenciaController : ApiController
    {
        [HttpPost]
        [Route("Api/Ocorrencia/Get")]
        [Authorize]
        public HttpResponseMessage Get()
        {
            try
            {
                var ocorrencias = OcorrenciaApplication.Get();

                if (OcorrenciaApplication.ResponseType.Equals("Error"))
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, OcorrenciaApplication.ResponseMessage);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = OcorrenciaApplication.ResponseMessage,
                        Type = OcorrenciaApplication.ResponseType,
                        ListaOcorrencias = ocorrencias
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao recuperar as operações.");
            }
        }

        [HttpGet]
        [Route("Api/Ocorrencia/GetPorId")]
        [Authorize]
        public HttpResponseMessage GetPorId(int ocorrenciaId)
        {
            try
            {
                var ocorrencia = OcorrenciaApplication.Get(ocorrenciaId);

                if (OcorrenciaApplication.ResponseType.Equals("Success"))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Ocorrencia = ocorrencia
                    });
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, OcorrenciaApplication.ResponseMessage);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao recuperar a operação.");
            }
        }

        [HttpPost]
        [Route("Api/Ocorrencia/Create")]
        [Authorize]
        public HttpResponseMessage Create(Ocorrencia ocorrencia)
        {
            try
            {
                ocorrencia.Usuario = new Usuario()
                {
                    Id = UsuarioApplication.ObtemUsuarioLogadoId((User.Identity as ClaimsIdentity).Claims.ToList())
                };
                OcorrenciaApplication.Add(ocorrencia);
                return ValidaRetornoApplication();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao cadastrar a ocorrência.");
            }
        }

        private HttpResponseMessage ValidaRetornoApplication()
        {
            if (OcorrenciaApplication.ResponseType.Equals("Success") || OcorrenciaApplication.ResponseType.Equals("Warning"))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = OcorrenciaApplication.ResponseMessage,
                    Type = OcorrenciaApplication.ResponseType,
                    Fields = OcorrenciaApplication.FieldsInvalids
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    OcorrenciaApplication.ResponseMessage);
            }
        }
    }
}
