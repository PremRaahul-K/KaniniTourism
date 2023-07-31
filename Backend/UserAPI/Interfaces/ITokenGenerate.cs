using UserAPI.Models;

namespace UserAPI.Interfaces
{
    public interface ITokenGenerate
    {
        public Task<string> GenerateToken(User user);

    }
}
