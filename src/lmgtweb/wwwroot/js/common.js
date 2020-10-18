var Common = (function(){
    var _$AppElement = null;
    function _Boot(){
        _$AppElement = $('#id_app');
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