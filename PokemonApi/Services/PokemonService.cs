using PokemonApi.Models;
using PokemonApi.Repositories;

namespace PokemonApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _pokemonRepository.GetAllAsync();
        }

        public async Task<Pokemon> GetByIdAsync(string id)
        {
            return await _pokemonRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task UpdateAsync(string id, Pokemon updatedPokemon)
        {
            await _pokemonRepository.UpdateAsync(id, updatedPokemon);
        }

        public async Task DeleteAsync(string id)
        {
            await _pokemonRepository.DeleteAsync(id);
        }
    }
}
