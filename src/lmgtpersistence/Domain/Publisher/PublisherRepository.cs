using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Publisher.Repository;
using lmgtdomain.Publisher.Dto;
namespace lmgtpersistence.Domain.Publisher
{
    public class PublisherRepository : RepositoryBase,IPublisherRepository
    {
        public PublisherRepository(IDatabaseWrapper databaseWrapper) : base(databaseWrapper)
        {

        }

        public async Task<PublisherDto> AddAsync(PublisherDto publisher)
        {
            await _Db.InsertAsync<PublisherDto>(publisher);
            return publisher;
        }

        public async Task<PublisherDto> ByAsync(int iD)
        {
            return await _Db.SingleOrDefaultByIdAsync<PublisherDto>(iD);
        }

        public async Task<PublisherDto> ByNameAsync(string name)
        {
            return await _Db.Query<PublisherDto>().Where(w=> w.Name.ToLower() == name.ToLower()).SingleOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(int iD)
        {
            return await _Db.DeleteMany<PublisherDto>().Where(w=> w.ID == iD).ExecuteAsync();
        }

        public async Task<List<PublisherDto>> AllAsync()
        {
            return await _Db.Query<PublisherDto>().ToListAsync();
        }

        public async Task<int> UpdateAsync(PublisherDto publisher)
        {
            return await _Db.UpdateAsync(publisher);
        }
    }
}