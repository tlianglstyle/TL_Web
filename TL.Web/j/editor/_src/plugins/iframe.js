///import core
///import plugins\inserthtml.js
///commands ≤Â»ÎøÚº‹
///commandsName  InsertFrame
///commandsTitle  ≤Â»ÎIframe
///commandsDialog  dialogs\insertframe\insertframe.html

UE.plugins['insertframe'] = function() {
   var me =this;
    function deleteIframe(){
        me._iframe && delete me._iframe;
    }

    me.addListener("selectionchange",function(){
        deleteIframe();
    });
    me.commands["insertframe"] = {

        queryCommandState : function(){
            return this.highlight ? -1 :0;
        }
    }
};


