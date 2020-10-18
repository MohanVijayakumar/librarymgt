using System.IO;
namespace lmgtusecase.Book
{
    public class CoverImagePathGenerator
    {
        public string FullFilePath {get;private set;}
        public string WebImageSrcPath {get;private set;}

        public void Generate(string basePath,int bookID,string fileExtension)
        {
            FullFilePath = $"{basePath}{Path.DirectorySeparatorChar}bcimage{Path.DirectorySeparatorChar}{bookID}{fileExtension}";
            WebImageSrcPath =  $"/bcimage/{bookID}{fileExtension}";
        }
    }
}