///import core
///import plugins\inserthtml.js
///commands ÌØÊâ×Ö·û
///commandsName  Spechars
///commandsTitle  ÌØÊâ×Ö·û
///commandsDialog  dialogs\spechars\spechars.html
UE.commands['spechars'] = {
    queryCommandState : function(){
        return this.highlight ? -1 :0;
    }
};

