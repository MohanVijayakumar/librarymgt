using lmgtpersistence.Mapping;

using lmgtdomain.Publisher.Dto;
namespace lmgtpersistence.Domain.Mapping
{
    public class PublisherDtosMapping :IMapDto
    {
        public void Map(IDtoMappings mappings)
        {
            mappings.For<PublisherDto>().
            TableName("Publisher");            

            mappings.For<PublisherSettingsDto>().
            TableName("PublisherSettings").
            PrimaryKey("ID",false);
        }
    }
}