﻿using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Interfaces;
using CidadaoAlerta.Domain.Services;
using CidadaoAlerta.Infra.DependencyInjection.Services;
using System;
using System.Collections.Generic;

namespace CidadaoAlerta.Application.Application
{
    public class UsuarioApplication
    {
        private static readonly UsuarioService _usuarioService = new UsuarioService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IUsuarioRepository>());

        public static string ResponseMessage
        {
            get
            {
                return _usuarioService.ResponseService.Message;
            }
        }

        public static string ResponseType
        {
            get
            {
                return _usuarioService.ResponseService.Type.ToString();
            }
        }

        public static List<string> FieldsInvalids
        {
            get
            {
                return _usuarioService.ResponseService.FieldsInvalids;
            }
        }

        public static Usuario Get(string login, string senha)
        {
            return _usuarioService.Get(login, senha);
        }
        public static int ObtemUsuarioLogadoId(List<System.Security.Claims.Claim> claims)
        {
            var usuarioId = Convert.ToInt32(claims.Find(x => x.Type == "UsuarioId").Value);

            return usuarioId;
        }
    }
}
