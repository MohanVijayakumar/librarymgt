namespace lmgtdomain.Book.Dto
{
    public class BookSettingsDto
    {
        public short ID {get;set;}
        public short NameMinLength {get;set;}
        public short NameMaxLength {get;set;}
        public short DescriptionMinLength {get;set;}
        public short DescriptionMaxLength {get;set;}
        public int CoverImageMaxSizeInBytes {get;set;}
        /// <summary>
        /// The allowed image formats for the book cover, seperated by comma
        /// the extension includes "." also
        /// </summary>
        /// <value></value>
        public string CoverImageAllowedFormats {get;set;}
    }
}