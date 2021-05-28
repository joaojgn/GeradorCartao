using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeradorCartao.Data;
using GeradorCartao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeradorCartao.Controllers
{
    [ApiController]
    [Route("")]
    public class CartaoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cartao>>> Get([FromServices] DataContext context)
        {
            var cartoes = await context.Cartoes.ToListAsync();
            return cartoes;
        }

        [HttpPost]
        [Route("{email}")]
        public async Task<ActionResult<Cartao>> Post([FromServices] DataContext context, string email)
        {
            if (ModelState.IsValid)
            {
                var cartaoNovo = new Models.Cartao
                {
                    Email = email,
                    CodigoCartao = GerarCodigo(),
                };
                context.Cartoes.Add(cartaoNovo);
                var data = await context.SaveChangesAsync();
                return Ok(cartaoNovo);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private static string GerarCodigo()
        {
            Random rnd = new Random();
            string codigoCartao = "";

            for (int i = 0; i < 19; i++)
            {
                if (i == 4 || i == 9 || i == 14)
                {
                    codigoCartao += " ";
                }
                else
                {
                    codigoCartao += rnd.Next(10);
                }
            }
            return codigoCartao;
        }
    }
}