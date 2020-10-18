var Login = (function(){
    
    function _GetCredential(){
        _Credential.password = document.getElementById('id_password').value;
        _Credential.userName = document.getElementById('id_username').value;
        return _Credential;
    }
    function _validateCredential(){
        if(!_Credential.userName){
            alert ('Please enter username');
            return false;
        }

        if(!_Credential.password){
            alert('Please enter password');
            return false;
        }
        
        return true;
    }
    var _Credential = {
        userName: null,
        password:null
    };
    
    function _DoLogin(){
        _GetCredential();
        if(!_validateCredential()){
            return;
        }

        
        var data = new FormData();
        data.append('userName',_Credential.userName);
        data.append('password',_Credential.password);

        axios.post('/Credential/Validate',data)
        .then(function(response){
            var d =response.data;
            if(d.success == true){
                window.location.href = '/home';
                return;
            }
            
            if(d.InvalidCredentials == true){
                alert('Invalid Credentials');
            }
            
        }).catch(function(error){
            alert('Error');
        });

    }

    function _Boot(){
        document.getElementById('id_btn_login').addEventListener('click',function(){
            _DoLogin();
        });
    }

    return {
        Boot : _Boot
    };
}());

Login.Boot();