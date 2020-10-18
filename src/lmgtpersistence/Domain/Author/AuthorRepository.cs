using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Author.Repository;
using lmgtdomain.Author.Dto;
namespace lmgtpersistence.Domain.Author
{
    public class AuthorRepository : RepositoryBase,IAuthorRepository
    {
        public AuthorRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {
            
        }

        public async Task<AuthorDto> AddAsync(AuthorDto author)
        {
            await _Db.InsertAsync<AuthorDto>(author);
            return author;
        }

        public async Task<AuthorDto> ByNameAsync(string name)
        {            
            return await _Db.Query<AuthorDto>().Where(w=> w.Name.ToLower() == name.ToLower()).SingleOrDefaultAsync();
        }

        public async Task<AuthorDto> ByAsync(int iD)
        {            
            return await _Db.SingleOrDefaultByIdAsync<AuthorDto>(iD);
        }
        
        public async Task<int> DeleteAsync(int iD)
        {            
            return await _Db.DeleteManyAsync<AuthorDto>().Where(w=> w.ID == iD).Execute();
        }

        public async Task<int> UpdateAsync(AuthorDto author)
        {
            return await _Db.UpdateAsync(author);
        }

        public async Task<List<AuthorDto>> AllAsync()
        {
            return await _Db.Query<AuthorDto>().ToListAsync();
        }

    }
}