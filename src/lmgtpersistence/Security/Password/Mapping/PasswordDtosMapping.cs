using lmgtpersistence.Mapping;
using lmgtsecurity.Password.Dto;
namespace lmgtpersistence.Security.Mapping
{
    public class PasswordDtosMapping : IMapDto
    {
        public void Map(IDtoMappings mappings)
        {
            mappings.For<PasswordSettingsDto>()
            .TableName("PasswordSettings")
            .PrimaryKey("ID",false);
        }
    } 
}