using System.Threading.Tasks;

using lmgtdomain.Author.Dto;
using lmgtdomain.Author.Model;
using lmgtdomain.Author.Repository;
namespace lmgtusecase.Author
{
    public class DeleteAuthor
    {
        public DeleteAuthor(IAuthorRepository authorRepository)
        {
            _AuthorRepository = authorRepository;
        }

        private readonly IAuthorRepository _AuthorRepository;

        public async Task<bool> DeleteAsync(int authorID)
        {

            var countDelete = await _AuthorRepository.DeleteAsync(authorID);
            return  countDelete ==1;
        }
    }
}