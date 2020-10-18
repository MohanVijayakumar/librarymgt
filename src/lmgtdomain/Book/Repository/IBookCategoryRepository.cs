using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Book.Dto;
namespace lmgtdomain.Book.Repository
{
    public interface IBookCategoryRepository
    {
        Task<BookCategoryDto> AddAsync(BookCategoryDto bookCategory);
        Task<BookCategoryDto> ByAsync(int iD);
        Task<List<BookCategoryDto>> AllAsync();
    }
}