using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using lmgtusecase.Author;
using lmgtdomain.Author.Model;
using lmgtcommon;
namespace lmgtweb.Controllers
{
    [Authorize(Roles="1")]
    [Route("Author")]
    public class AuthorController : ControllerBase
    {
        public AuthorController(AddNewAuthor addNewAuthor,EditAuthor editAuthor,DeleteAuthor deleteAuthor,
        IUnitOfWork unitOfWork,ILogger<AuthorController> logger)
        {
            _AddNewAuthor = addNewAuthor;
            _EditAuthor = editAuthor;
            _DeleteAuthor = deleteAuthor;
            _UnitOfWork = unitOfWork;
            _Logger = logger;
        }

        private AddNewAuthor _AddNewAuthor;
        private EditAuthor _EditAuthor;
        private DeleteAuthor _DeleteAuthor;

        private IUnitOfWork _UnitOfWork;
        private ILogger _Logger;


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(AuthorInputModel inputModel)
        {
            var userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            var resAdd = false;
            _UnitOfWork.Start();
            try
            {
                resAdd =  await    _AddNewAuthor.AddAsync(inputModel,userID);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resAdd)
            {
                if(_AddNewAuthor.DoesNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {NameAlreadyExists = true});
                }

                if(_AddNewAuthor.FailedValidations.Count > 0)
                {
                    _UnitOfWork.Complete();
                    _Logger.LogCritical(string.Join(" ",_AddNewAuthor.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError = true,Error = string.Join(" ",_AddNewAuthor.FailedValidations.Select(s=> s.ExposableErrorMessage))});
                }

                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown"});
            }

            _UnitOfWork.Complete();
            return  Ok(new {success = true});
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(EditAuthorInputModel inputModel)
        {
            var userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            var resAdd = false;
            _UnitOfWork.Start();
            try
            {
                resAdd = await _EditAuthor.EditAsync(inputModel,userID);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resAdd)
            {
                if(_EditAuthor.DoesNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {NameAlreadyExists = true});
                }

                if(_EditAuthor.FailedValidations.Count > 0)
                {
                    _UnitOfWork.Complete();
                    _Logger.LogCritical(string.Join(" ",_EditAuthor.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError = true,Error = string.Join(" ",_EditAuthor.FailedValidations.Select(s=> s.ExposableErrorMessage))});
                }

                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown"});
            }

            _UnitOfWork.Complete();
            return  Ok(new {success = true});
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int authorID)
        {
            var resDelete = await _DeleteAuthor.DeleteAsync(authorID);
            _UnitOfWork.Start();
            if(!resDelete)
            {
                _UnitOfWork.RollBack();
                return Ok(new {HasError=true,Error="Unknown"});
            }
            _UnitOfWork.Complete();
            return Ok(new {success=true});
        }

    }
}