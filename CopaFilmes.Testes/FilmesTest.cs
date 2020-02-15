using System;
using System.Collections.Generic;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Repositories;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace CopaFilmes.Testes
{
    public class FilmesTest
    {
        FilmeRepository repository = new FilmeRepository();
        
        [Theory]
        [InlineData("[{'id': 'tt5463162','titulo': 'Deadpool 2','ano': 2018,'nota': 8.1},{'id': 'tt3778644','titulo': 'Han Solo: Uma História Star Wars','ano': 2018,'nota': 7.2},{'id': 'tt7784604','titulo': 'Hereditário','ano': 2018,'nota': 7.8},{'id': 'tt4881806','titulo': 'Jurassic World: Reino Ameaçado','ano': 2018,'nota': 6.7},{'id': 'tt5164214','titulo': 'Oito Mulheres e um Segredo','ano': 2018,'nota': 6.3},{'id': 'tt3606756','titulo': 'Os Incríveis 2','ano': 2018,'nota': 8.5},{'id': 'tt3501632','titulo': 'Thor: Ragnarok','ano': 2017,'nota': 7.9},{'id': 'tt4154756','titulo': 'Vingadores: Guerra Infinita','ano': 2018,'nota': 8.8}]",
                    "[{'id': 'tt5463162','titulo': 'Deadpool 2','ano': 2018,'nota': 8.1},{'id': 'tt4154756','titulo': 'Vingadores: Guerra Infinita','ano': 2018,'nota': 8.8},{'id': 'tt3778644','titulo': 'Han Solo: Uma História Star Wars','ano': 2018,'nota': 7.2},{'id': 'tt3501632','titulo': 'Thor: Ragnarok','ano': 2017,'nota': 7.9},{'id': 'tt7784604','titulo': 'Hereditário','ano': 2018,'nota': 7.8},{'id': 'tt3606756','titulo': 'Os Incríveis 2','ano': 2018,'nota': 8.5},{'id': 'tt5164214','titulo': 'Oito Mulheres e um Segredo','ano': 2018,'nota': 6.3},{'id': 'tt4881806','titulo': 'Jurassic World: Reino Ameaçado','ano': 2018,'nota': 6.7}]")]
        public void OrdenaPrimeiroUltimoFilmesTest(String filmesSelecionados, String filmesOrdenados){
            List<Filme> filmes = JsonConvert.DeserializeObject<List<Filme>>(filmesSelecionados);
            List<Filme> ordenados = JsonConvert.DeserializeObject<List<Filme>>(filmesOrdenados);

            List<Filme> resultado = repository.OrdenaPrimeiroUltimo(filmes);    
            resultado.Should().BeEquivalentTo(ordenados, $"Filmes vencedores da primeira rodada não são os que deveriam: ({filmesOrdenados})");
        }

        [Theory]
        [InlineData("[{'id': 'tt5463162','titulo': 'Deadpool 2','ano': 2018,'nota': 8.1},{'id': 'tt4154756','titulo': 'Vingadores: Guerra Infinita','ano': 2018,'nota': 8.8},{'id': 'tt3778644','titulo': 'Han Solo: Uma História Star Wars','ano': 2018,'nota': 7.2},{'id': 'tt3501632','titulo': 'Thor: Ragnarok','ano': 2017,'nota': 7.9},{'id': 'tt7784604','titulo': 'Hereditário','ano': 2018,'nota': 7.8},{'id': 'tt3606756','titulo': 'Os Incríveis 2','ano': 2018,'nota': 8.5},{'id': 'tt5164214','titulo': 'Oito Mulheres e um Segredo','ano': 2018,'nota': 6.3},{'id': 'tt4881806','titulo': 'Jurassic World: Reino Ameaçado','ano': 2018,'nota': 6.7}]",
                    "[{'id': 'tt4154756','titulo': 'Vingadores: Guerra Infinita','ano': 2018,'nota': 8.8},{'id': 'tt3501632','titulo': 'Thor: Ragnarok','ano': 2017,'nota': 7.9},{'id': 'tt3606756','titulo': 'Os Incríveis 2','ano': 2018,'nota': 8.5},{'id': 'tt4881806','titulo': 'Jurassic World: Reino Ameaçado','ano': 2018,'nota': 6.7}]")]
        public void PrimeiraRodadaTest(String filmesSelecionados, String vencedores)
        {
            List<Filme> filmes = JsonConvert.DeserializeObject<List<Filme>>(filmesSelecionados);
            List<Filme> filmesVencedores = JsonConvert.DeserializeObject<List<Filme>>(vencedores);

            List<Filme> resultado = repository.Rodada(filmes);    
            resultado.Should().BeEquivalentTo(filmesVencedores, $"Filmes vencedores da primeira rodada não são os que deveriam: ({vencedores})");
        }

        [Theory]
        [InlineData("[{'id': 'tt4154756','titulo': 'Vingadores: Guerra Infinita','ano': 2018,'nota': 8.8},{'id': 'tt3501632','titulo': 'Thor: Ragnarok','ano': 2017,'nota': 7.9},{'id': 'tt3606756','titulo': 'Os Incríveis 2','ano': 2018,'nota': 8.5},{'id': 'tt4881806','titulo': 'Jurassic World: Reino Ameaçado','ano': 2018,'nota': 6.7}]",
                    "[{'id': 'tt4154756','titulo': 'Vingadores: Guerra Infinita','ano': 2018,'nota': 8.8},{'id': 'tt3606756','titulo': 'Os Incríveis 2','ano': 2018,'nota': 8.5}]")]
        public void SegundaRodadaTest(String vencedores,String finalistas){
            List<Filme> filmesVencedores = JsonConvert.DeserializeObject<List<Filme>>(vencedores);
            List<Filme> filmesFinalistas = JsonConvert.DeserializeObject<List<Filme>>(finalistas);

            List<Filme> resultado = repository.Rodada(filmesVencedores);
            resultado.Should().BeEquivalentTo(filmesFinalistas, $"Filmes vencedores da segunda rodada não são os que deveriam: ({filmesFinalistas})");
        }
    }
}
