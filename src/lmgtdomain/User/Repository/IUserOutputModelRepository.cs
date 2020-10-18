using System.Threading.Tasks;
using System.Collections.Generic;

using lmgtdomain.User.Model;
namespace lmgtdomain.User.Repository
{
    public interface IUserOutputModelRepository
    {
        Task<List<UserOutputModel>> AllAsync();

        Task<UserOutputModel> ByAsync(int iD);
    }
}