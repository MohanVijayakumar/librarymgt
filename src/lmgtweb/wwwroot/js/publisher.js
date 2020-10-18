var Publisher = (function(){
    function _LoadAddPublisherForm(){
        axios.get("/Publisher/AddPublisherForm")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootAddPublisherForm();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootAddPublisherForm(){
        $('#id_publisheradd_create').click(function(){
            _AddPublisher();
        });
    }

    function _AddPublisher(){
        var aName = _ValidateAddPublisherForm();
        if(!aName){
            return;
        }
        var fD = new FormData();
        fD.append("Name",aName);
        axios.post("/Publisher/Add",fD).
        then(function(response){
            var d = response.data;
            if(d.success){
                _LoadAllPublishers();
                return;
            }

            if(d.nameAlreadyExists){
                alert("Publisher Name Already Exists");
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
    function _ValidateAddPublisherForm(){
        var publisherName = $('#id_publisheradd_publishername').val();
        if(!publisherName){
            alert("Enter Publisher Name");
            return false;
        }

        return publisherName;
    }

    function _LoadAllPublishers(){
        axios.get("/publisher/Listpublishers")
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootPublishersList();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootPublishersList(){
        $('.id_publisherslist_edit').click(function(){
            var publisherID =  $(this).closest('tr').data('mypublisherid');
            _LoadEditPublisherForm(publisherID);
        });

        $('.id_publisherslist_delete').click(function(){

        });
    }

    function _LoadEditPublisherForm(publisherID){
        var fD = new FormData();
        fD.append('publisherID',publisherID);
        axios.post("/Publisher/EditPublisherForm",fD)
        .then(function(response){
            Common.$AppContainer().html('').html(response.data);
            _BootEditPublisherForm();
        }).catch(function(error){
            alert(error);
        });
    }

    function _BootEditPublisherForm(){
        $('#id_publisheredit_update').click(function(){
            _UpdatePublisher();
        });
    }

    function _UpdatePublisher(){
        var d = _ValidateEditPublisherForm();
        if(!d){
            return;
        }
        
        var fD = new FormData();
        fD.append('PublisherID',d.ID);
        fD.append("Name",d.Name);

        axios.post("/Publisher/Edit",fD)
        .then(function(response){
            var d = response.data;
            if(d.success){
                _LoadAllPublishers();
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

    function _ValidateEditPublisherForm(){
        var d = JSON.parse( $('#id_publisheredit_publisherdata').html());
        var aName = $('#id_publisheredit_publishername').val();

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
        LoadAddPublisherForm : _LoadAddPublisherForm,
        LoadAllPublishers : _LoadAllPublishers
    };
}());