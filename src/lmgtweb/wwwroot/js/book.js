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

    function _BootBooksList(){
        $('.id_bookslist_edit').click(function(){

        });
        $('.id_bookslist_lend').click(function(){

        });
        $('.id_bookslist_delete').click(function(){

        });
    }
    
    return {
        LoadAddBookForm : _LoadAddBookForm,
        LoadBooksList : _LoadBooksList
    };

}());