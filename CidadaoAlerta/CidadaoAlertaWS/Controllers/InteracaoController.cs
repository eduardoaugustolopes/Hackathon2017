using CidadaoAlerta.Application.Application;
using CidadaoAlerta.Domain.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace CidadaoAlertaWS.Controllers
{
    public class InteracaoController : ApiController
    {
        [HttpPost]
        [Route("Api/Categoria/Create")]
        [Authorize]
        public HttpResponseMessage Create(Interacao interacao)
        {
            try
            {
                interacao.Usuario.Id = UsuarioApplication.ObtemUsuarioLogadoId((User.Identity as ClaimsIdentity).Claims.ToList());
                InteracaoApplication.Add(interacao);
                return ValidaRetornoApplication();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao cadastrar a ocorrência.");
            }
        }

        private HttpResponseMessage ValidaRetornoApplication()
        {
            if (InteracaoApplication.ResponseType.Equals("Success") || InteracaoApplication.ResponseType.Equals("Warning"))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = InteracaoApplication.ResponseMessage,
                    Type = InteracaoApplication.ResponseType,
                    Fields = InteracaoApplication.FieldsInvalids
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    InteracaoApplication.ResponseMessage);
            }
        }
    }
}
