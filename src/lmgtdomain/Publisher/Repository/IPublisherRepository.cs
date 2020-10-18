using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.Publisher.Dto;
namespace lmgtdomain.Publisher.Repository
{
    public interface IPublisherRepository
    {
        Task<PublisherDto> AddAsync(PublisherDto publisher);
        Task<PublisherDto> ByAsync(int iD);
        Task<PublisherDto> ByNameAsync(string name);
        Task<int> DeleteAsync(int iD);

        Task<List<PublisherDto>> AllAsync();

        Task<int> UpdateAsync(PublisherDto publisher);
    }
}