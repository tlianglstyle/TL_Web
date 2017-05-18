///import core
///commandsName  attachment
///commandsTitle  ¸½¼þÉÏ´«
UE.commands["attachment"] = {
    queryCommandState:function(){
        return this.highlight ? -1 :0;
    }
};
