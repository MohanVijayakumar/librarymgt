using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using lmgtusecase.Publisher;
using lmgtdomain.Publisher.Model;
using lmgtcommon;
namespace lmgtweb.Controllers
{
    [Authorize(Roles="1")]
    [Route("Publisher")]
    public class PublisherController : ControllerBase
    {
        public PublisherController(AddNewPublisher addNewPublisher,EditPublisher editPublisher,
        DeletePublisher deletePublisher,IUnitOfWork unitOfWork,ILogger<PublisherController> logger)
        {
            _AddNewPublisher = addNewPublisher;
            _EditPublisher = editPublisher;
            _DeletePublisher = deletePublisher;
            _UnitOfWork = unitOfWork;
            _Logger = logger;
        }

        private AddNewPublisher _AddNewPublisher;
        private EditPublisher _EditPublisher;
        private DeletePublisher _DeletePublisher;
        private IUnitOfWork _UnitOfWork;
        private ILogger _Logger;

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(PublisherInputModel inputModel)
        {
            var userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            var resAdd = false;
            _UnitOfWork.Start();
            try
            {
                resAdd = await _AddNewPublisher.AddAsync(inputModel,userID);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resAdd)
            {
                if(_AddNewPublisher.DoesNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {NameAlreadyExists=true});
                }

                if(_AddNewPublisher.FailedValidations.Count > 0)
                {
                    _Logger.LogCritical(string.Join(" ",_AddNewPublisher.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError = true,Error = string.Join(" ",_AddNewPublisher.FailedValidations.Select(s=> s.ExposableErrorMessage))});
                }

                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown"});
            }

            _UnitOfWork.Complete();
            return  Ok(new {success = true});
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(EditPublisherInputModel inputModel)
        {
            var userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            var resAdd = false;
            _UnitOfWork.Start();
            try
            {
                resAdd = await _EditPublisher.EditAsync(inputModel,userID);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resAdd)
            {
                if(_EditPublisher.DoesNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {NameAlreadyExists=true});
                }

                if(_EditPublisher.FailedValidations.Count > 0)
                {
                    _Logger.LogCritical(string.Join(" ",_EditPublisher.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError = true,Error = string.Join(" ",_EditPublisher.FailedValidations.Select(s=> s.ExposableErrorMessage))});
                }

                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown"});
            }

            _UnitOfWork.Complete();
            return  Ok(new {success = true});
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int publisherID)
        {
            var resDelete = await _DeletePublisher.DeleteAsync(publisherID);
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