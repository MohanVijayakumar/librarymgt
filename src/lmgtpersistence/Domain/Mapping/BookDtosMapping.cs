using lmgtpersistence.Mapping;

using lmgtdomain.Book.Dto;
namespace lmgtpersistence.Domain.Mapping
{
    public class BookDtosMapping :IMapDto
    {
        public void Map(IDtoMappings mappings)
        {
            mappings.For<BookCategoryDto>().
            TableName("BookCategory");
            
            mappings.For<BookDto>().
            TableName("Book");

            mappings.For<BookSettingsDto>().
            TableName("BookSettings").
            PrimaryKey("ID",false);

            mappings.For<LendBookDto>().
            TableName("LendBook");
        }
    }
}