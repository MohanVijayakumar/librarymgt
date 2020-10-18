var User = (function(){

    var _HasUserSettingsLoaded = false;
    var _HasPasswordSettingsLoaded = false;

    var _UserSettings = {
        iD : null,
        nameMinLength : null,
        nameMaxLength : null
    };
    var _PasswordSettings = {
        iD : null,
        passwordMinLength : null,
        passwordMaxLength : null
    };

    function _LoadAddUserFrom(){
        axios.get("/User/AddUserForm")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootAddUserForm();
        }).catch(function(error){
            alert(error);
        });
    }

    function _CreateUser(){
        var d = _ValidateCreateUser();
        if(!d){
            return;
        }
        var fD = new FormData();
        fD.append('Name',d.Name);
        fD.append('Password',d.Password);
        fD.append('RoleID',d.RoleID);

        axios.post('/user/add',fD).
        then(function(response){
            var rdata = response.data;
            if(rdata.success){
                _LoadAllUsers();
               return ; 
            }

            if(rdata.nameAlreadyExists){
                alert('Name already exits');
                return;
            }

            if(rdata.hasError){
                alert(rdata.error);
            }

        }).catch(function(error){
            alert('Error');
        });

    }

    function _ValidateCreateUser(){
        var userName = $('#id_useradd_username').val();
        var password = $('#id_useradd_password').val();
        var confirmPassword = $('#id_useradd_confirmpassword').val();
        var userRole = $('#id_useradd_userroles').val();

        if(!userName){
            alert('Enter valid user name');
            return false;
        }

        if(!password){
            alert('Enter password');
            return false;
        }
        
        if(!confirmPassword){
            alert('Enter Confirm password');
            return false;
        }

        if(!(userRole > 0)){
            alert('Select User Role');
            return false;
        }
        
        if(userName.length < _UserSettings.nameMinLength || userName.length > _UserSettings.nameMaxLength){
            alert('User name length should be with in range ' + _UserSettings.nameMinLength.toString() + ' - ' + _UserSettings.nameMaxLength.toString());
            return false;
        }

        if(password != confirmPassword){
            alert('Password and ConfirmPassword not matched');
            return false;
        }
        
        if(password.length < _PasswordSettings.passwordMinLength || password.length > _PasswordSettings.passwordMaxLength){
            alert('Password length should be with in range ' + _PasswordSettings.passwordMinLength.toString() + ' - ' + _PasswordSettings.passwordMaxLength.toString());
            return false;
        }

        return {
            Name : userName,
            Password : password,            
            RoleID : userRole
        };
    }

    function _LoadUserSettings(){
        if(_HasUserSettingsLoaded){
            return true;
        }
        var res = false;
        axios.get("/user/settings")
        .then(function(response){
            _UserSettings = response.data;
            _HasUserSettingsLoaded = true;
            
        }).catch(function(error){
            alert("Not -able to get validation data");            
            
        });
    }

    function _LoadPasswordSettings(){
        if(_HasPasswordSettingsLoaded){
            return true;
        }
        var res = false;
        axios.get('/user/passwordsettings')
        .then(function(response){
            _PasswordSettings = response.data;
            _HasPasswordSettingsLoaded = true;
            
        }).catch(function(error){
            alert("Not able to get validation data");
            
        });         
    }

    function _BootAddUserForm(){
        _LoadUserSettings();
        _LoadPasswordSettings();
        $('#id_useradd_create').click(function(){
            _CreateUser();
        });
    }
    
    function _LoadAllUsers(){
        axios.get("/User/ListUsers")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootAllUsersList();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootAllUsersList(){
        
        $(".id_userslist_edit").click(function(){
            var userID =  $(this).closest('tr').data('myuserid');
            _LoadEditUserForm(userID);
        });
        $(".id_userslist_delete").click(function(){
            alert("delete");
        });
    }

    function _LoadEditUserForm(userID){
        var fD = new FormData();
        fD.append('userID',userID);
        axios.post("/User/EditUserForm",fD)
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootEditUserForm();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootEditUserForm(){
        _LoadPasswordSettings();
        _LoadUserSettings();
        $('#id_useredit_update').click(function(){
            _UpdateUser();
        });
    
    }

    function _UpdateUser(){
        var d = _EditUserValidate();
        if(!d){
            return;
        }

        var fD = new FormData();
        fD.append('UserID',d.userID);
        fD.append('Name',d.name);
        fD.append('RoleID',d.roleID);

        axios.post('/user/edit',fD).
        then(function(response){
            var rdata = response.data;
            if(rdata.success){
                _LoadAllUsers();
               return ; 
            }

            if(rdata.nameAlreadyExists){
                alert('Name already exits');
                return;
            }

            if(rdata.hasError){
                alert(rdata.error);
            }

        }).catch(function(error){
            alert('Error');
        });
    }

    function _EditUserValidate(){
        var userName = $('#id_useredit_username').val();
        var userRole = $('#id_useredit_userroles').val();
        var preData = JSON.parse($('#id_useredit_userdata').html());

        if(preData.Name == userName && preData.RoleID == userRole){
            alert("No chnages made");
            return false;
        }

        if(!userName){
            alert('Enter valid user name');
            return false;
        }

        if(!(userRole > 0)){
            alert('Select User Role');
            return false;
        }
        
        if(userName.length < _UserSettings.nameMinLength || userName.length > _UserSettings.nameMaxLength){
            alert('User name length should be with in range ' + _UserSettings.nameMinLength.toString() + ' - ' + _UserSettings.nameMaxLength.toString());
            return false;
        }

        return {
            userID : preData.ID,
            name : userName,
            roleID : userRole
        };
    }

    return {
        LoadAddUserForm : _LoadAddUserFrom,
        LoadUsersList : _LoadAllUsers
    };

}());