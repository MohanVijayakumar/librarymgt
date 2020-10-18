var Menu = (function(){
    function _Boot(){
        $('#id_menu_addnewuser').click(function(){
            User.LoadAddUserForm();
        });

        $('#id_menu_allusers').click(function(){
           User.LoadUsersList(); 
        });

        $('#id_menu_addnewauthor').click(function(){
            Author.LoadAddAuthorForm();
        });

        $('#id_menu_allauthors').click(function(){
            Author.LoadAllAuthors();
         });
        
         $('#id_menu_addnewpublisher').click(function(){
            Publisher.LoadAddPublisherForm();
        });

        $('#id_menu_allpublishers').click(function(){
            Publisher.LoadAllPublishers();
         });

         $('#id_menu_addnewbook').click(function(){
            Book.LoadAddBookForm();
         });
         
         $('#id_menu_allbooks').click(function(){
            Book.LoadBooksList();
         });

         $('#id_menu_searchbook').click(function(){
            Book.LoadSearchBookForm();
         });
         
    }    

    return {
        Boot : _Boot,
        User : {
            
        },
        Book : {

        },
        Author : {

        },
        Publisher : {

        }
    };

}());

Menu.Boot();