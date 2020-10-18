var Author = (function(){
    function _LoadAddAuthorForm(){
        axios.get("/Author/AddAuthorForm")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootAddAuthorForm();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootAddAuthorForm(){
        $('#id_authoradd_create').click(function(){
            _AddAuthor();
        });
    }

    function _AddAuthor(){
        var aName = _ValidateAddAuthorForm();
        if(!aName){
            return;
        }
        var fD = new FormData();
        fD.append("Name",aName);
        axios.post("/Author/Add",fD).
        then(function(response){
            var d = response.data;
            if(d.success){
                alert("Added");
                return;
            }

            if(d.nameAlreadyExists){
                alert("Author Name Already Exists");
                return;
            }

            if(d.hasError){
                alert(d.error);
                return;
            }

            alert('Unknown Error');
            
        }).catch(function(error){
            alert(error);
        });
    }
    function _ValidateAddAuthorForm(){
        var authorName = $('#id_authoradd_authorname').val();
        if(!authorName){
            alert("Enter Author Name");
            return false;
        }

        return authorName;
    }

    function _LoadAllAuthors(){
        axios.get("/Author/ListAuthors")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootAuthorsList();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootAuthorsList(){
        $('.id_authorslist_edit').click(function(){
            var authorID =  $(this).closest('tr').data('myauthorid');
            _LoadEditAuthorForm(authorID);
        });

        $('.id_authorslist_delete').click(function(){

        });
    }

    function _LoadEditAuthorForm(authorID){
        var fD = new FormData();
        fD.append('authorID',authorID);
        axios.post("/AUthor/EditAuthorForm",fD)
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootEditAuthorForm();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootEditAuthorForm(){
        $('#id_authoredit_update').click(function(){
            _UpdateAuthor();
        });
    }

    function _UpdateAuthor(){
        var d = _ValidateEditAuthorForm();
        if(!d){
            return;
        }
        
        var fD = new FormData();
        fD.append('AuthorID',d.ID);
        fD.append("Name",d.Name);

        axios.post("/AUthor/Edit",fD)
        .then(function(response){
            var d = response.data;
            if(d.success){
                _LoadAllAuthors();
                return;
            }

            if(d.nameAlreadyExists){
                alert("Name Already Exists");
                return;
            }

            if(d.hasError){
                alert(error);
            }

        }).catch(function(error){
            alert(error);
        });
    }

    function _ValidateEditAuthorForm(){
        var d = JSON.parse( $('#id_authoredit_authordata').html());
        var aName = $('#id_authoredit_authorname').val();

        if(d.Name == aName){
            alert("No Changes done");
            return false;
        }

        if(!aName){
            alert('Please enter name');
            return false;
        }

        return {
            ID : d.ID,
            Name : aName
        };
    }

    return {
        LoadAddAuthorForm : _LoadAddAuthorForm,
        LoadAllAuthors : _LoadAllAuthors
    };
}());