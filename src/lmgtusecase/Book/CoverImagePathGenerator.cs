using System.IO;
namespace lmgtusecase.Book
{
    public class CoverImagePathGenerator
    {
        public string Generate(string basePath,int bookID,string fileExtension)
        {
            return $"{basePath}{Path.DirectorySeparatorChar}bcimage{Path.DirectorySeparatorChar}{bookID}{fileExtension}";
        }
    }
}