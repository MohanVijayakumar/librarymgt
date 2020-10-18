using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Book.Repository;
using lmgtdomain.Book.Dto;
namespace lmgtpersistence.Domain.Book
{
    public class BookCategoryRepository :RepositoryBase,IBookCategoryRepository
    {
        public BookCategoryRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {
                        
        }

        public async Task<BookCategoryDto> AddAsync(BookCategoryDto bookCategory)
        {
            await _Db.InsertAsync<BookCategoryDto>(bookCategory);
            return bookCategory;
        }

        public async Task<BookCategoryDto> ByAsync(int iD)
        {
            return await _Db.SingleOrDefaultByIdAsync<BookCategoryDto>(iD);
        }

        public async Task<List<BookCategoryDto>> AllAsync()
        {
            return await _Db.Query<BookCategoryDto>().ToListAsync();
        }
    }
}