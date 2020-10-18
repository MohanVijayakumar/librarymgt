var Book = (function(){

    function _LoadAddBookForm(){
        axios.get("/Book/AddBookForm")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootAddBookForm();
        }).catch(function(error){
            alert(error);
        });
    }

    var _BookSettings = {
        ID : null,
        NameMinLength : null,
        NameMaxLength : null,
        DescriptionMinLength : null,
        DescriptionMaxLength : null,
        CoverImageMaxSizeInBytes : null,
        CoverImageAllowedFormats : null
    };

    function _BootAddBookForm(){
        _BookSettings = JSON.parse($('#id_bookadd_booksettingsdata').html());

        $('#id_bookadd_coverimage_file').change(function(){
            var fName = this.files[0].name;
            $('#id_bookadd_coverimage_filename').html(fName);
        });

        $('#id_bookadd_create').click(function(){
            _CreateBook();
        });
    }

    function _CreateBook(){
        var d = _ValidateBookAdd();
        if(!d){
            return;
        }
        var fD = new FormData();
        fD.append('Name',d.Name);
        fD.append('Description',d.Description);
        fD.append('AuthodID',d.AuthodID);
        fD.append('CategoryID',d.CategoryID);
        fD.append('CoverImageFile',d.CoverImageFile);
        fD.append('PublisherID',d.PublisherID);
        
        axios.post('/Book/Add',fD, {
            headers : {
                'Content-Type': 'multipart/form-data'
            }
        }).then(function(response){
            var d = response.data;
            if(d.success){
                return;
            }
            if(d.nameAlreadyExists){
                alert('Name already exists');
            }
            if(d.hasError){
                alert(d.error);
                return;
            }

        }).catch(function(error){
            alert(error);
        });
    }

    function _ValidateBookAdd(){
        var bookName = $('#id_bookadd_name').val();
        var authorID = $('#id_bookadd_author').val();
        var categoryID = $('#id_bookadd_category').val();
        var publisherID = $('#id_bookadd_publisher').val();
        var description = $('#id_bookadd_description').val();

        if(!bookName){
            alert('Please enter Book Name');
            return false;
        }

        if(!(authorID > 0)){
            alert('Please select Author');
            return false;
        }

        if(!(categoryID > 0)){
            alert('Please select Category');
            return false;
        }

        if(!(publisherID > 0)){
            alert('Please select Publisher');
            return false;
        }

        if(!description){
            alert('Please enter description');
            return false;
        }

        if(bookName.length < _BookSettings.NameMinLength || bookName.length > _BookSettings.NameMaxLength){
            alert('Book Name Length with in range , From ' + _BookSettings.NameMinLength.toString() + ' to ' + _BookSettings.NameMaxLength.toString());
            return false;
        }

        if(description.length < _BookSettings.DescriptionMinLength || description.length > _BookSettings.DescriptionMaxLength){
            alert('Description Length with in range , From ' + _BookSettings.DescriptionMinLength.toString() + ' to ' + _BookSettings.DescriptionMaxLength.toString());
            return false;
        }

        var uFiles =document.getElementById('id_bookadd_coverimage_file').files;
        var uFile  = null;
        var fExtension = null;
        if(uFiles){
            if(uFiles.length){
                uFile = uFiles[0];
                if(uFile.size > _BookSettings.CoverImageMaxSizeInBytes){
                    alert('Maximum allowed KB for image is ' + ((uFile.size) / 1024).toString());
                    return false;
                }

                fExtension = uFile.name.split('.').pop();
                fExtension = fExtension.toLowerCase();
                
                var allowedFileTypes = _BookSettings.CoverImageAllowedFormats.split(",");
                if(!(allowedFileTypes.indexOf(fExtension) > -1)){
                    alert('Invalid file format');
                    return false;
                }                
            }
            else{
                alert('Please select cover image');
                return false;
            }
        }

        return {
            Name : bookName,
            Description : description,
            CoverImageFile : uFile,
            CategoryID : categoryID,
            AuthodID : authorID,
            PublisherID : publisherID
        };
    }

    function _LoadBooksList() {
        axios.get("/Book/ListBooks")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootBooksList();
        }).catch(function(error){
            alert(error);
        });
    }
    var _SelectedBookIDToLend = null;
    function _BootBooksList(){
        $('.id_bookslist_edit').click(function(){
            var bookID = $(this).closest('tr').data('mybookid');
            _LoadEditBookForm(bookID);
        });
        $('.id_bookslist_lend').click(function(){
            _SelectedBookIDToLend = $(this).closest('tr').data('mybookid');
            $('#id_bookslist_userlend_modal').addClass('is-active');
        });
        $('.id_bookslist_delete').click(function(){

        });
        $('#id_bookslist_lendbook').click(function(){

            _LendBook();
        });
        $('#id_bookslist_userlend_close_modal').click(function(){   
            $('#id_bookslist_userlend_modal').removeClass('is-active');
        });
    }

    function _LoadEditBookForm(bookID){
        var fD = new FormData();
        fD.append('bookID',bookID);
        axios.post("/Book/EditBookForm",fD)
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootEditBookForm();
        }).catch(function(error){
            alert(error);
        });
    }
    var _HasCoverImageFileDeletedAtEdit = false;
    function _BootEditBookForm(){

        _BookSettings = JSON.parse($('#id_bookedit_booksettingsdata').html());
        _HasCoverImageFileDeletedAtEdit = false;
        $('#id_bookedit_deletefile').click(function(){
            $('#id_bookedit_showfile_container').css('display','none');
            $('#id_bookedit_selectfile_container').css('display','block');
            _HasCoverImageFileDeletedAtEdit = true;
        });

        $('#id_bookedit_coverimage_file').change(function(){
            var fName = this.files[0].name;
            $('#id_bookedit_coverimage_filename').html(fName);
        });

        $('#id_bookedit_update').click(function(){
            _UpdateBook();
        });
    }

    function _UpdateBook(){
        var d = _ValidateUpdateBook();
        if(!d){
            return;
        }
        var fD = new FormData();
        fD.append("BookID",d.BookID)
        fD.append('Name',d.Name);
        fD.append('Description',d.Description);
        fD.append('AuthodID',d.AuthodID);
        fD.append('CategoryID',d.CategoryID);        
        fD.append('CoverImageFile',d.CoverImageFile);
        fD.append('PublisherID',d.PublisherID);
        fD.append('IsOldCoverFileDeleted',d.IsOldCoverFileDeleted)

        axios.post('/Book/Edit',fD, {
            headers : {
                'Content-Type': 'multipart/form-data'
            }
        }).then(function(response){
            var d = response.data;
            if(d.success){
                return;
            }
            if(d.nameAlreadyExists){
                alert('Name already exists');
            }
            if(d.hasError){
                alert(d.error);
                return;
            }

        }).catch(function(error){
            alert(error);
        });
        
    }

    function _ValidateUpdateBook(){
        var bookName = $('#id_bookedit_name').val();
        var authorID = $('#id_bookedit_author').val();
        var categoryID = $('#id_bookedit_category').val();
        var publisherID = $('#id_bookedit_publisher').val();
        var description = $('#id_bookedit_description').val();

        if(!bookName){
            alert('Please enter Book Name');
            return false;
        }

        if(!(authorID > 0)){
            alert('Please select Author');
            return false;
        }

        if(!(categoryID > 0)){
            alert('Please select Category');
            return false;
        }

        if(!(publisherID > 0)){
            alert('Please select Publisher');
            return false;
        }

        if(!description){
            alert('Please enter description');
            return false;
        }

        if(bookName.length < _BookSettings.NameMinLength || bookName.length > _BookSettings.NameMaxLength){
            alert('Book Name Length with in range , From ' + _BookSettings.NameMinLength.toString() + ' to ' + _BookSettings.NameMaxLength.toString());
            return false;
        }

        if(description.length < _BookSettings.DescriptionMinLength || description.length > _BookSettings.DescriptionMaxLength){
            alert('Description Length with in range , From ' + _BookSettings.DescriptionMinLength.toString() + ' to ' + _BookSettings.DescriptionMaxLength.toString());
            return false;
        }

        var uFiles =document.getElementById('id_bookedit_coverimage_file').files;
        var uFile  = null;
        var fExtension = null;
        if(_HasCoverImageFileDeletedAtEdit){
            if(uFiles){
                if(uFiles.length){
                    uFile = uFiles[0];
                    if(uFile.size > _BookSettings.CoverImageMaxSizeInBytes){
                        alert('Maximum allowed KB for image is ' + ((uFile.size) / 1024).toString());
                        return false;
                    }
    
                    fExtension = uFile.name.split('.').pop();
                    fExtension = fExtension.toLowerCase();
                    
                    var allowedFileTypes = _BookSettings.CoverImageAllowedFormats.split(",");
                    if(!(allowedFileTypes.indexOf(fExtension) > -1)){
                        alert('Invalid file format');
                        return false;
                    }                
                }
            }
            else{
                alert('Please select the cover image');
                return false;
            }
        }

        return {

            BookID : JSON.parse($('#id_bookedit_bookoutputmodel').html()).ID,
            Name : bookName,
            Description : description,
            CoverImageFile : uFile,
            CategoryID : categoryID,
            AuthodID : authorID,
            PublisherID : publisherID,
            IsOldCoverFileDeleted : _HasCoverImageFileDeletedAtEdit
        };
    }

    function _LendBook(){
        if(!(_SelectedBookIDToLend > 0)){
            alert('No Book Selected to lend')
            return false;
        }

        var lendTo = $('#id_bookslist_users').val();
        if(!(lendTo > 0)){
            alert('Select the user to lend');
            return;
        }
        var fD = new FormData();
        fD.append('BookID',_SelectedBookIDToLend);
        fD.append('LendTo',lendTo);
        axios.post('/Book/Lend',fD)
        .then(function(response){
            $('#id_bookslist_userlend_modal').removeClass('is-active');
            var d = response.data;
            if(d.success){
                return;
            }
            if(d.bookAlreadyLend){
                alert('book already lend');
                return;
            }
        }).catch(function(error){
            $('#id_bookslist_userlend_modal').removeClass('is-active');
            alert(error);
        });
    }
    
    return {
        LoadAddBookForm : _LoadAddBookForm,
        LoadBooksList : _LoadBooksList
    };

}());