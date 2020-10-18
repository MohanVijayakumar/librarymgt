namespace lmgtdomain.Book.Model
{
    public class LendBookInputModel
    {
        public int BookID {get;set;}
        public int LendTo {get;set;}
        public int LendBy {get;set;}
    }
}