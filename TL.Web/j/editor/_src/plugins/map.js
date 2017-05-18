///import core
///import plugins\inserthtml.js
///commands µØÍ¼
///commandsName  Map,GMap
///commandsTitle  BaiduµØÍ¼,GoogleµØÍ¼
///commandsDialog  dialogs\map\map.html,dialogs\gmap\gmap.html
UE.commands['gmap'] =
UE.commands['map'] = {
     queryCommandState : function(){
        return this.highlight ? -1 :0;
    }
};

