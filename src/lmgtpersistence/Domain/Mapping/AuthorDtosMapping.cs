using lmgtpersistence.Mapping;

using lmgtdomain.Author.Dto;
namespace lmgtpersistence.Domain.Mapping
{
    public class AuthorDtosMapping :IMapDto
    {
        public void Map(IDtoMappings mappings)
        {
            mappings.For<AuthorDto>().
            TableName("Author");            

            mappings.For<AuthorSettingsDto>().
            TableName("AuthorSettings").
            PrimaryKey("ID",false);
        }
    }
}