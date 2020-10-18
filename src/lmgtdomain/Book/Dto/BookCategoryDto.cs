using System;
namespace lmgtdomain.Book.Dto
{
    public class BookCategoryDto
    {
        public int ID {get;set;}
        public string Name {get;set;}        
        public int CreateBy {get;set;}
        public DateTime CreateTime {get;set;}
    }
}