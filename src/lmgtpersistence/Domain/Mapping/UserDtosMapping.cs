using lmgtpersistence.Mapping;

using lmgtdomain.User.Dto;
namespace lmgtpersistence.Domain.Mapping
{
    public class UserDtosMapping : IMapDto
    {
        public void Map(IDtoMappings mappings)
        {
            mappings.For<UserDto>().
            TableName("User");            

            mappings.For<UserRoleDto>().
            TableName("UserRole").
            PrimaryKey("ID",false);

            mappings.For<UserSettingsDto>().
            TableName("UserSettings").
            PrimaryKey("ID",false);
        }
    }
}