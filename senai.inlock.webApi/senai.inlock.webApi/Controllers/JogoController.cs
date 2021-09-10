using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]


    [Route("api/[controller]")]
    [ApiController]

    [Authorize]

    public class JogoController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogoController()
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _JogoRepository.ListarTodos();


            return Ok(listaJogos);

        }

        [Authorize(Roles = "administrador, comum")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(id);

            if (JogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }

            return Ok(JogoBuscado);
        }

        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {

            _JogoRepository.Cadastrar(novoJogo);


            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult PutIdBody(JogoDomain JogoAtualizado)
        {
            if (JogoAtualizado.nomeJogo == null || JogoAtualizado.DataLan == null || JogoAtualizado.Valor == null || JogoAtualizado.Descricao == null || JogoAtualizado.idJogo <= 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome ou o id do jogo não foi informado!"
                    });
            }

            JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(JogoAtualizado.idJogo);

            if (JogoBuscado != null)
            {
                try
                {
                    _JogoRepository.AtualizarIdCorpo(JogoAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagem = "Jogo não encontrado!",
                        errorStatus = true
                    }
                );
        }


        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _JogoRepository.Deletar(id);

            return NoContent();
        }
    }
}
