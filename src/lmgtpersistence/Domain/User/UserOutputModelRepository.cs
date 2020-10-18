using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using lmgtdomain.User.Model;
using lmgtdomain.User.Repository;
namespace lmgtpersistence.Domain.User
{
    public class UserOutputModelRepository : RepositoryBase, IUserOutputModelRepository
    {
        public UserOutputModelRepository(IDatabaseWrapper database) : base(database)
        {

        }

        public async Task<List<UserOutputModel>> AllAsync()
        {
            string q = @"SELECT * FROM ""GetUsersList""();";
            return await _DbWrapper.ReturnProcAsync<UserOutputModel>(q);
        }

        public async Task<UserOutputModel> ByAsync(int userID)
        {
            string q = @"SELECT * FROM ""GetUserOutputModelByID""(@0);";
            
            object[] args =  new object[] { userID};            
            return (await _DbWrapper.ReturnProcAsync<UserOutputModel>(q,args)).FirstOrDefault();
        }
    }
}