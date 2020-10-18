using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;
using System.IO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using lmgtdomain.Book.Model;
using lmgtusecase.Book;
using lmgtcommon;
using lmgtweb.Book.Models;
using lmgtconfiguration;
namespace lmgtweb.Controllers
{
    [Route("Book")]
    [Authorize(Roles = "1")]
    public class BookController : ControllerBase
    {
        public BookController(AddNewBook addNewBook,EditBook editBook,DeleteBook deleteBook,IUnitOfWork unitOfWork,
        IWebHostEnvironment webHostEnvironment,ILogger<BookController> logger,LendBook lendBook
        )
        {
            _AddNewBook = addNewBook;
            _EditBook = editBook;
            _DeleteBook = deleteBook;
            _UnitOfWork = unitOfWork;
            _WebHostEnvironMent = webHostEnvironment;
            _Logger = logger;
            _LendBook = lendBook;
        }

        private AddNewBook _AddNewBook;
        private EditBook _EditBook;
        private DeleteBook _DeleteBook;
        private LendBook _LendBook;

        private IUnitOfWork _UnitOfWork;
        private IWebHostEnvironment _WebHostEnvironMent;
        private ILogger _Logger;

        [Route("Add")]
        public async Task<IActionResult> Add(AddBookInputModel inputModel)
        {
            var resAddBook = false;
            var basePath = _WebHostEnvironMent.WebRootPath;
            var userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            _UnitOfWork.Start();
            try
            {
                BookInputModel im = new BookInputModel();
                im.AuthodID = inputModel.AuthodID;
                im.CategoryID = inputModel.CategoryID;
                im.TempCoverImagePath = await _GetBookCoverTempFilePath(inputModel.CoverImageFile);
                im.Description = inputModel.Description;
                im.Name = inputModel.Name;
                im.PublisherID = inputModel.PublisherID;
                resAddBook = await _AddNewBook.AddAsync(im,userID,basePath);
            }           
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resAddBook)
            {
                if(_AddNewBook.DoesBookNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {NameAlreadyExists = true});
                }

                if(_AddNewBook.FailedValidations.Count > 0)
                {
                    _UnitOfWork.Complete();
                    _Logger.LogCritical(string.Join(" ",_AddNewBook.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError=true,Error = string.Join(" ", _AddNewBook.FailedValidations.Select(s=> s.ExposableErrorMessage)) });
                }

                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown"});
            }

            _UnitOfWork.Complete();
            return Ok(new {success=true});
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(EditBookInputModelForWeb inputModel)
        {
            var resAddBook = false;
            var basePath = _WebHostEnvironMent.WebRootPath;
            var userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            _UnitOfWork.Start();
            try
            {
                BookEditInputModel im = new BookEditInputModel();
                im.AuthodID= inputModel.AuthodID;
                im.BookID = inputModel.BookID;
                im.CategoryID = inputModel.CategoryID;
                im.Description = inputModel.Description;
                im.IsOldCoverFileDeleted = inputModel.IsOldCoverFileDeleted;
                im.Name = inputModel.Name;
                im.PublisherID = inputModel.PublisherID;
                if(inputModel.IsOldCoverFileDeleted)
                {
                    im.TempCoverImagePath = await  _GetBookCoverTempFilePath(inputModel.CoverImageFile);
                }
                resAddBook = await _EditBook.EditAsync(im,userID,basePath);
            }           
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resAddBook)
            {
                if(_EditBook.DoesBookNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {BookNameExists = true});
                }

                if(_EditBook.FailedValidations.Count > 0)
                {
                    _UnitOfWork.Complete();
                    _Logger.LogCritical(string.Join(" ",_EditBook.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError=true,Error = string.Join(" ", _EditBook.FailedValidations.Select(s=> s.ExposableErrorMessage)) });
                }

                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown"});
            }

            _UnitOfWork.Complete();
            return Ok(new {success=true});
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int bookID)
        {
            bool resDelete = false;
            _UnitOfWork.Start();
            try
            {
                resDelete = await _DeleteBook.DeleteAsync(bookID);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resDelete)
            {
                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown. Not ablet o delete"});
            }

            _UnitOfWork.Complete();
            return Ok(new {success=true});

        }

        [HttpPost]
        [Route("Lend")]
        public async Task<IActionResult> Lend(LendBookInputModel inputModel)
        {
            bool resDelete = false;
            int userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            inputModel.LendBy = userID;
            _UnitOfWork.Start();
            try
            {
                resDelete = await _LendBook.LendAsync(inputModel,userID);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resDelete)
            {
                _UnitOfWork.RollBack();
                if(_LendBook.IsBookLend)
                {                    
                    return Ok(new {BookAlreadyLend = true});
                }

                if(_LendBook.FailedValidations.Count > 0)
                {
                    _UnitOfWork.Complete();
                    _Logger.LogCritical(string.Join(" ",_EditBook.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError=true,Error = string.Join(" ", _EditBook.FailedValidations.Select(s=> s.ExposableErrorMessage)) });
                }
                else
                {

                    return Ok(new {HasError = true,Error = "Unknown"});
                }
            }

            _UnitOfWork.Complete();
            return Ok(new {success=true});

        }

        private async Task<string> _GetBookCoverTempFilePath(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(formFile.FileName);            
            if(string.IsNullOrEmpty(fileExtension))
            {
                throw new Exception($"Invalid profile image file {formFile.FileName}");
            }            
            
            var tempFilePath = Path.GetTempPath()  + Path.DirectorySeparatorChar + Path.GetRandomFileName();
            tempFilePath = tempFilePath + fileExtension;
            var fileStream = new FileStream(tempFilePath,FileMode.Create);
            await formFile.CopyToAsync(fileStream);
            fileStream.Dispose();

            return tempFilePath;
        }
    }
}