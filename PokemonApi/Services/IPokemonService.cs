using PokemonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApi.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(string id);
        Task AddAsync(Pokemon pokemon);
        Task UpdateAsync(string id, Pokemon updatedPokemon);
        Task DeleteAsync(string id);
    }
}
