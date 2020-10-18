using System.Threading.Tasks;

using lmgtdomain.Book.Dto;
namespace lmgtdomain.Book.Repository
{
    public interface ILendBookRepository
    {
        Task<LendBookDto> AddAsync(LendBookDto lendBook);
    }
}