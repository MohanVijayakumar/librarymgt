namespace lmgtweb.Book.Models
{
    public class EditBookInputModelForWeb : AddBookInputModel
    {
        public int BookID {get;set;}

        public bool IsOldCoverFileDeleted {get;set;}
    }
}