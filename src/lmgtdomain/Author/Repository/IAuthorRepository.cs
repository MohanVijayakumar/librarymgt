using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Author.Dto;
namespace lmgtdomain.Author.Repository
{
    public interface IAuthorRepository
    {
        Task<AuthorDto> AddAsync(AuthorDto author);

        Task<AuthorDto> ByNameAsync(string name);

        Task<AuthorDto> ByAsync(int iD);

        Task<int> DeleteAsync(int iD);

        Task<int> UpdateAsync(AuthorDto author);

        Task<List<AuthorDto>> AllAsync();
    }
}