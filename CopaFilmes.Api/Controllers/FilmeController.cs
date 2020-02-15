using System.Collections.Generic;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers{
    public class FilmeController: ControllerBase
    {
        private readonly FilmeRepository repositorio = new FilmeRepository();

        [HttpGet("v1/filmes")]
        public async System.Threading.Tasks.Task<IActionResult> Get(){
            List<Filme> filmes = await repositorio.Get();

            if(filmes == null){
                NotFound();
            }

            return Ok(filmes);
        }

        [HttpPost("v1/contest")]
        public IActionResult GetCampeoes([FromBody]List<Filme> filmes){
            List<Filme> winners = repositorio.RealizaCampeonato(filmes);

            if(winners == null){
                NotFound();
            }

            return Ok(winners);
        }
    }
}