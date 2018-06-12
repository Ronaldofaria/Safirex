using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Safirex.App_Start
{
    public class MeuManipuladorDeRota : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var url = requestContext.HttpContext.Request.Path.TrimStart('/');

            if (!string.IsNullOrEmpty(url))
            {
                ItemDePagina item = GerenciadorDeRedirecionamento.ObterPaginaPorUrl(url);
                if (item != null)
                {
                    MontarRequisicao(item.Controller,
                        item.Action ?? "Index",
                        item.ConteudoId.ToString(),
                        requestContext);
                }
            }

            return base.GetHttpHandler(requestContext);
        }

        private static void MontarRequisicao(string controller, string action, string id, RequestContext requestContext)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }

            requestContext.RouteData.Values["controller"] = controller;
            requestContext.RouteData.Values["action"] = action;
            requestContext.RouteData.Values["id"] = id;
        }

        public class ItemDePagina
        {
            public String Controller { get; set; }
            public String Action { get; set; }
            public int ConteudoId { get; set; }
        }

        public static class GerenciadorDeRedirecionamento
        {
            public static ItemDePagina ObterPaginaPorUrl(string url)
            {
                ItemDePagina item = null;

                /* Aqui você pesquisa na entidade pela descrição, passando o parâmetro url. */
                /* Este é o ponto mais importante da lógica, que é onde você vai pesquisar o item de acordo com as suas regras de negócio. */
                /* Depois você monta um objeto ItemDePagina (no caso, item) e o devolve. */

                return item;
            }
        }
    }
}