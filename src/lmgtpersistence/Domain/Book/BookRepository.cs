using System.Threading.Tasks;

using lmgtdomain.Book.Repository;
using lmgtdomain.Book.Dto;
namespace lmgtpersistence.Domain.Book
{
    public class BookRepository : RepositoryBase,IBookRepository
    {
        public BookRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<BookDto> AddAsync(BookDto book)
        {
            await _Db.InsertAsync<BookDto>(book);
            return book;
        }
        public async Task<BookDto> ByNameAsync(string name)
        {
            return await _Db.Query<BookDto>().Where(w=> w.Name.ToLower() == name.ToLower()).SingleOrDefaultAsync();
        }
        public async Task<BookDto> ByAsync(int iD)
        {
            return await _Db.SingleOrDefaultByIdAsync<BookDto>(iD);
        }

        public async Task<int> DeleteAsync(int iD)
        {
            return await _Db.DeleteMany<BookDto>().Where(w=> w.ID == iD).ExecuteAsync();
        }

        public async Task<int> UpdateAsync(BookDto book)
        {
            return await _Db.UpdateAsync(book);
        }

        public async Task<int> UpdateCoverImageAsync(BookDto book)
        {
            return await _Db.UpdateAsync<BookDto>(book,(b) => new {b.CoverImagePath});
        }       

        public async Task<int> UpdateLendAsync(BookDto book)
        {
            return await _Db.UpdateManyAsync<BookDto>().Where(w=> w.ID == book.ID && w.IsLend == !book.IsLend)
            .OnlyFields((f) => new {f.IsLend}).Execute(book);
        }
    }
}