Type.registerNamespace("Nucleo.Web.ListControls");Nucleo.Web.ListControls.ListInterfaceType=function(){throw Error.notImplemented()};Nucleo.Web.ListControls.ListInterfaceType.prototype={CheckboxList:0,RadioButtonList:1,DropDownList:2,BulletedList:3,Custom:4};Nucleo.Web.ListControls.ListInterfaceType.registerEnum("Nucleo.Web.ListControls.ListInterfaceType");Nucleo.Web.ListControls.ListItem=function(d,a,c,b){Nucleo.Web.ListControls.ListItem.initializeBase(this);this._text=d;this._value=a;this._selected=c;this._enabled=b};Nucleo.Web.ListControls.ListItem.prototype={get_enabled:function(){return this._enabled},set_enabled:function(a){if(this._enabled!=a){this._enabled=a;this.raisePropertyChanged("enabled")}},get_selected:function(){return this._selected},set_selected:function(a){if(this._selected!=a){this._selected=a;this.raisePropertyChanged("selected");if(this._selected==true){this.raise_selected()}this.raise_toggled()}},get_text:function(){return this._text},set_text:function(a){if(this._text!=a){this._text=a;this.raisePropertyChanged("text")}},get_value:function(){return this._value},set_value:function(a){if(this._value!=a){this._value=a;this.raisePropertyChanged("value")}},add_clicked:function(a){this.get_events().addHandler("clicked",a)},remove_clicked:function(a){this.get_events().removeHandler("clicked",a)},raise_clicked:function(){var a=this.get_events().getHandler("clicked");if(a!=null){a(this,Sys.EventArgs.Empty)}},add_selected:function(a){this.get_events().addHandler("selected",a)},remove_selected:function(a){this.get_events().removeHandler("selected",a)},raise_selected:function(){var a=this.get_events().getHandler("selected");if(a!=null){a(this,Sys.EventArgs.Empty)}},add_toggled:function(a){this.get_events().addHandler("toggled",a)},remove_toggled:function(a){this.get_events().removeHandler("toggled",a)},raise_toggled:function(){var a=this.get_events().getHandler("toggled");if(a!=null){a(this,Sys.EventArgs.Empty)}}};Nucleo.Web.ListControls.ListItem.descriptor={properties:[{name:"enabled",type:Boolean},{name:"selected",type:Boolean},{name:"text",type:String},{name:"value",type:String}],events:[{name:"clicked"},{name:"selected"},{name:"toggled"}]};Nucleo.Web.ListControls.ListItem.registerClass("Nucleo.Web.ListControls.ListItem",Sys.Component);Nucleo.Web.ListControls.ListItemCollection=function(){Nucleo.Web.ListControls.ListItemCollection.initializeBase(this);this._itemsList=[]};Nucleo.Web.ListControls.ListItemCollection.prototype={get_count:function(){return this._itemsList.length},get_item:function(a){if(a<0||a>=this.get_count()){throw Error.argumentOutOfRange("index",a)}return this._itemsList[a]},add_itemAdded:function(a){this.get_events().addHandler("itemAdded",a)},remove_itemAdded:function(a){this.get_events().removeHandler("itemAdded",a)},raise_itemAdded:function(b){var a=this.get_events().getHandler("itemAdded");if(a!=null){a(this,b)}},add_cleared:function(a){this.get_events().addHandler("cleared",a)},remove_cleared:function(a){this.get_events().removeHandler("cleared",a)},raise_cleared:function(){var a=this.get_events().getHandler("cleared");if(a!=null){a(this,Sys.EventArgs.Empty)}},add_itemRemoved:function(a){this.get_events().addHandler("itemRemoved",a)},remove_itemRemoved:function(a){this.get_events().removeHandler("itemRemoved",a)},raise_itemRemoved:function(b){var a=this.get_events().getHandler("itemRemoved");if(a!=null){a(this,b)}},add_selectionCleared:function(a){this.get_events().addHandler("selectionCleared",a)},remove_selectionCleared:function(a){this.get_events().removeHandler("selectionCleared",a)},raise_selectionCleared:function(){var a=this.get_events().getHandler("selectionCleared");if(a!=null){a(this,Sys.EventArgs.Empty)}},add:function(a){if(a==null){throw Error.argumentNull("listItem")}Array.add(this._itemsList,a);this.raise_itemAdded(new Nucleo.DataEventArgs(a))},clear:function(){Array.clear(this._itemsList);this.raise_cleared()},clearSelection:function(){for(var a=0;a<this.get_count();a++){this.get_items()[a].set_selected(false)}this.raise_selectionCleared()},contains:function(a){if(a==null){throw Error.argumentNull("listItem")}return(this.indexOf(a)!=-1)},findByText:function(c){for(var b=0;b<this.get_count();b++){var a=this.get_item(b);if(a.get_text()==c){return a}}return null},findByValue:function(a){for(var c=0;c<this.get_count();c++){var b=this.get_item(c);if(b.get_value()==a){return b}}return null},indexOf:function(b){if(b==null){throw Error.argumentNull("listItem")}for(var c=0;c<this.get_count();c++){var a=this.get_item(c);if(a.get_text()==b.get_text()&&a.get_value()==b.get_value()){return c}}return -1},remove:function(a){if(a==null){throw Error.argumentNull("listItem")}Array.remove(this._itemsList,a);this.raise_itemRemoved(new Nucleo.DataEventArgs(a))}};Nucleo.Web.ListControls.ListItemCollection.descriptor={properties:[{name:"count",type:Number,readOnly:true},{name:"item",type:Object,readOnly:true}],methods:[{name:"add"},{name:"clear"},{name:"contains"},{name:"findByText"},{name:"findByValue"},{name:"indexOf"},{name:"remove"}],events:[{name:"itemAdded"},{name:"cleared"},{name:"itemRemoved"},{name:"selectionCleared"}]};Nucleo.Web.ListControls.ListItemCollection.registerClass("Nucleo.Web.ListControls.ListItemCollection",Sys.Component);Nucleo.Web.ListControls.ListItemEventArgs=function(a){this._listItem=a};Nucleo.Web.ListControls.ListItemEventArgs.prototype={get_listItem:function(){return this._listItem}};Nucleo.Web.ListControls.ListItemEventArgs.registerClass("Nucleo.Web.ListControls.ListItemEventArgs",Sys.EventArgs);if(typeof(Sys)!=="undefined"){Sys.Application.notifyScriptLoaded()};