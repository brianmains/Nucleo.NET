if(typeof(n$)==="undefined"){n$={}}n$.ValidatorDisplays={};n$.ValidatorDisplays.Error=function(b){Sys.UI.DomElement.addCssClass(b.element,"NucleoValidationItemError");var a=document.createElement("span");a.innerHTML=b.message;b.element.appendChild(a)};n$.ValidatorDisplays.Information=function(b){Sys.UI.DomElement.addCssClass(b.element,"NucleoValidationItemInformation");var a=document.createElement("span");a.innerHTML=b.message;b.element.appendChild(a)};n$.ValidatorDisplays.Warning=function(b){Sys.UI.DomElement.addCssClass(b.element,"NucleoValidationItemWarning");var a=document.createElement("span");a.innerHTML=b.message;b.element.appendChild(a)};