using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Repositories{
    public interface IFilmeRepository{
        Task<List<Filme>> Get();
        Task GetAsync();
        List<Filme> RealizaCampeonato(List<Filme> filmes);
        List<Filme> OrdenaPrimeiroUltimo(List<Filme> filmes);
        public List<Filme> Rodada(List<Filme> FilmesOrdenados);
        Filme Disputa(Filme filme1, Filme filme2);
    }
}