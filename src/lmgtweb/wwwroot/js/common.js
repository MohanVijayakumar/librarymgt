var Common = (function(){
    var _$AppElement = null;
    function _Boot(){
        _$AppElement = $('#id_app');
        $('#id_main_logout').click(function(){
            window.location.href = "/logout"
        });
    }

    function _getAppContainer(){
        return _$AppElement;
    }
    
    return {
        Boot : _Boot,
        $AppContainer : _getAppContainer
    };

}());

Common.Boot();