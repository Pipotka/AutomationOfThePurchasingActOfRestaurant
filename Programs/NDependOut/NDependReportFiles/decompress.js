function loadCompressedHTML(){var a=UncompressSourceContent(reportCompressed);var b=getIFrame();var e=window.location.href;if(e.indexOf("?")===-1&&e.indexOf("#")===-1){e+="#Main";updateBrowserURL(e)}var d="";var g=false;var f;try{f=b.contentDocument||b.contentWindow.document}catch(c){alert("Please reload the report with F5");return}f.open();f.write(a);f.close();setInterval(function(){var h=tryGetIFrameURL();if(!h){return}if(!g){g=true;b.contentWindow.location.href=e;d=e;return}if(h!==d){updateBrowserURL(h);d=h}},100);window.addEventListener("popstate",function(i){var j=window.location.href;var h=tryGetIFrameURL();if(!h){return}if(h!==j){d=j;b.contentWindow.history.replaceState(null,"",j);b.contentWindow.dispatchEvent(new PopStateEvent("hashchange"))}});b.addEventListener("load",function(){var h=document.getElementById("uncompressLoad");h.style.visibility="hidden";b.style.visibility="visible"})}function updateBrowserURL(a){history.pushState(null,"",a)}function tryGetIFrameURL(){try{return getIFrame().contentWindow.location.href}catch(a){return""}}function getIFrame(){return document.getElementById("contentIframe")};