using System;
namespace lmgtdomain.Book.Dto
{
    public class LendBookDto
    {
        public int ID {get;set;}
        public int BookID {get;set;}
        public int LendTo {get;set;}
        public int LendBy {get;set;}
        public DateTime LendOn{get;set;}
        public DateTime? ReturnedOn {get;set;}
    }
}