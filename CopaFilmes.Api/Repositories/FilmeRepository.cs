using System.Collections.Generic;
using System.Net.Http;
using CopaFilmes.Api.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace CopaFilmes.Api.Repositories{
    public class FilmeRepository : IFilmeRepository
    {
        public List<Filme> filmes;
        static HttpClient client = new HttpClient();
        string url = "http://copafilmes.azurewebsites.net/api/filmes";

        public FilmeRepository(){
            filmes = new List<Filme>();
        }

        public async Task GetAsync()
        {
            HttpResponseMessage response = await client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                filmes = await JsonSerializer.DeserializeAsync<List<Filme>>(responseStream);
            }
        }

        public async Task<List<Filme>> Get()
        {
            HttpResponseMessage response = await client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                filmes = await JsonSerializer.DeserializeAsync<List<Filme>>(responseStream);
            }

            return filmes;
        }

        public List<Filme> RealizaCampeonato(List<Filme> filmes)
        {
            try{
                filmes = OrdenaPrimeiroUltimo(filmes.OrderBy(x=>x.titulo).ToList());
                filmes = Rodada(filmes);
                filmes = Rodada(filmes);
                
                return (filmes[0].nota == filmes[1].nota) ? filmes.OrderBy(x=>x.titulo).ToList() : filmes.OrderByDescending(x=>x.nota).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Filme> OrdenaPrimeiroUltimo(List<Filme> Filmes)
        {
            try{
                for(int i=0; i<Filmes.Count/2;i++){
                    var aux = Filmes[i];
                    Filmes[i] = Filmes[(Filmes.Count - 1) - i];
                    Filmes[(Filmes.Count - 1) - i] = aux;
                }

                return Filmes;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao realizar a ordenação: " +ex.Message);
            }
        }

        public List<Filme> Rodada(List<Filme> FilmesOrdenados)
        {
            try{
                List<Filme> Winners = new List<Filme>();

                int i = 0;
                while(i<(FilmesOrdenados.Count))
                {
                    if((i+1) < FilmesOrdenados.Count){
                        Winners.Add(Disputa(FilmesOrdenados[i],FilmesOrdenados[(i+1)]));
                        
                        i=i+2;
                    }
                }

                return Winners;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao realizar rodada do campeonato de filmes: " +ex.Message);
            }
        }
    
        public Filme Disputa(Filme filme1, Filme filme2)
        {
            try{
                var filmes = new List<Filme>();

                filmes.Add(filme1);
                filmes.Add(filme2);

                return (filme1.nota == filme2.nota) ? filmes.OrderBy(x=>x.titulo).FirstOrDefault() : filmes.OrderByDescending(x=>x.nota).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao realizar disputa entre filmes: " +ex.Message);
            }
        }
    }
}