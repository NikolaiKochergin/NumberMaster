mergeInto(LibraryManager.library, {
  
  CanVibrate: function (){
    return window.navigator && window.navigator.vibrate
  }
  
  Vibrate: function (var time){
    window.navigator.vibrate(time);
  }

});