using System;
using System.Web.Mvc;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;

namespace PauloRodrigues.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder: IModelBinder
    {
        private const String SessionKey = "Carrinho";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Obtendo carrinho ... 
            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho) controllerContext.HttpContext.Session[SessionKey];
            }

            // Criando sessão, caso não exista ...
            if (carrinho == null)
            {
                carrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            // Retornando ...
            return carrinho;
        }
    }
}