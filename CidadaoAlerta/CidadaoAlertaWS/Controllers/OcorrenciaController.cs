using CidadaoAlerta.Application.Application;
using CidadaoAlerta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace CidadaoAlertaWS.Controllers
{
    public class OcorrenciaController : ApiController
    {
        [HttpPost]
        [Route("Api/Categoria/Create")]
        [Authorize]
        public HttpResponseMessage Create(Ocorrencia ocorrencia)
        {
            try
            {
                ocorrencia.Usuario.Id = UsuarioApplication.ObtemUsuarioLogadoId((User.Identity as ClaimsIdentity).Claims.ToList());
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
