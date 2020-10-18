using System.Threading.Tasks;
using System.Linq;
using System;
using System.Runtime.ExceptionServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using lmgtdomain.User.Model;
using lmgtusecase.User;
using lmgtcommon;
using lmgtdomain.User.Repository;
using lmgtsecurity.Password.Repository;

namespace lmgtweb.Controllers
{
    [Authorize(Roles = "1")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController(AddNewUser addNewUser,ILogger<UserController> logger,IUnitOfWork unitOfWork,
        EditUser editUser,DeleteUser deleteUser,IUserSettingsRepository userSettingsRepository,
        IPasswordSettingsRepository passwordSettingsRepository)
        {
            _AddNewUser = addNewUser;
            _Logger = logger;
            _UnitOfWork = unitOfWork;
            _EditUser = editUser;
            _DeleteUser = deleteUser;
            _UserSettingsRepository = userSettingsRepository;
            _PasswordSettingsRepository = passwordSettingsRepository;
        }

        private ILogger _Logger;
        private readonly AddNewUser _AddNewUser;
        private readonly EditUser _EditUser;
        private readonly DeleteUser _DeleteUser;

        private IUnitOfWork _UnitOfWork;

        private readonly IUserSettingsRepository _UserSettingsRepository;
        private readonly IPasswordSettingsRepository _PasswordSettingsRepository;

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(UserInputModel inputModel)
        {
            int userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            bool resAdd = false;
            _UnitOfWork.Start();
            try
            {
               resAdd =  await _AddNewUser.AddAsync(inputModel,userID);            
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();

            }
            

            if(!resAdd)
            {
                if(_AddNewUser.DoesNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {NameAlreadyExists = true});
                }
                else if (_AddNewUser.FailedValidations.Count > 0)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {HasError=true,Error = string.Join(" ", _AddNewUser.FailedValidations.Select(s=> s.ExposableErrorMessage)) });
                }
                else
                {
                    _UnitOfWork.RollBack();
                    return Ok(new {HasError=true,Error = "Unknown"});
                }
            }
            
            _UnitOfWork.Complete();
            return Ok(new {success=true});
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(EditUserInputModel inputModel)
        {
            int userID = UtilitiesClaims.GetUserID(HttpContext.User.Claims.ToList());
            bool resAdd = false;
            _UnitOfWork.Start();
            try
            {
               resAdd =  await _EditUser.EditAsync(inputModel);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();

            }
            

            if(!resAdd)
            {
                if(_EditUser.DoesNameAlreadyExist)
                {
                    _UnitOfWork.Complete();
                    return Ok(new {NameAlreadyExists = true});
                }
                else if (_EditUser.FailedValidations.Count > 0)
                {
                    _UnitOfWork.Complete();
                    _Logger.LogCritical(string.Join(" ", _EditUser.FailedValidations.Select(s=> s.SystemErrorMessage)));
                    return Ok(new {HasError=true,Error = string.Join(" ", _EditUser.FailedValidations.Select(s=> s.ExposableErrorMessage)) });
                }
                else
                {
                    _UnitOfWork.RollBack();
                    return Ok(new {HasError=true,Error = "Unknown"});
                }
            }

            _UnitOfWork.Complete();
            return Ok(new {success=true});
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int userID)
        {
            bool resDelete = false;
            _UnitOfWork.Start();
            try
            {
                resDelete = await _DeleteUser.DeleteAsync(userID);
            }
            catch(Exception ex)
            {
                _UnitOfWork.RollBack();
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            if(!resDelete)
            {
                _UnitOfWork.RollBack();
                return Ok(new {HasError = true,Error = "Unknown. Not ableto delete"});
            }

            _UnitOfWork.Complete();
            return Ok(new {success=true});

        }

        [Route("Settings")]
        public async Task<IActionResult> Settings()
        {
            return Ok((await _UserSettingsRepository.ByAsync()));
        }

        [Route("PasswordSettings")]
        public async Task<IActionResult> PasswordSettings()
        {
            return Ok((await _PasswordSettingsRepository.ByAsync()));
        }
    }
}