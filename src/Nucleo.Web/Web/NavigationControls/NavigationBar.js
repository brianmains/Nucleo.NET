Type.registerNamespace("Nucleo.Web.NavigationControls");Nucleo.Web.NavigationControls.NavigationBar=function(a){Nucleo.Web.NavigationControls.NavigationBar.initializeBase(this,[a]);this._container=null;this._items=new Nucleo.Collections.Collection();this._selectedItem=null};Nucleo.Web.NavigationControls.NavigationBar.prototype={get_container:function(){return this._container},set_container:function(a){this._container=a},addItem:function(a){this._items.add(a);a.add_selected(this._itemSelected)},get_items:function(){return this._items},get_selectedItem:function(){return this._selectedItem},clearSelections:function(){this._selectedItem=null;for(var b=0,a=this._items.get_count();b<a;b++){this._items.get_item(b).set_isSelected(false)}},removeItem:function(a){a.remove_selected(this._itemSelected);this._items.remove(a)},_itemSelected:function(a,b){var c=a.get_bar();if(c._selectedItem!=null){c._selectedItem.set_isSelected(false)}c._selectedItem=a;c._onitemSelected(new Nucleo.DataEventArgs(a,false))},add_itemSelected:function(a){this.get_events().addHandler("itemSelected",a)},remove_itemSelected:function(a){this.get_events().removeHandler("itemSelected",a)},_onitemSelected:function(b){var a=this.get_events().getHandler("itemSelected");if(a){a(this,b)}},initialize:function(){Nucleo.Web.NavigationControls.NavigationBar.callBaseMethod(this,"initialize");if(this.get_container()!=null){this.get_container().addBar(this)}},dispose:function(){Nucleo.Web.NavigationControls.NavigationBar.callBaseMethod(this,"dispose")}};Nucleo.Web.NavigationControls.NavigationBar.registerClass("Nucleo.Web.NavigationControls.NavigationBar",Nucleo.Web.BaseAjaxControl);if(typeof(Sys)!=="undefined"){Sys.Application.notifyScriptLoaded()};