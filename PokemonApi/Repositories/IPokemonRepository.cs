using PokemonApi.Models;

namespace PokemonApi.Repositories
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(string id);
        Task AddAsync(Pokemon pokemon);
        Task UpdateAsync(string id, Pokemon updatedPokemon);
        Task DeleteAsync(string id);
    }
}
