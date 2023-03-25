mergeInto(LibraryManager.library, {
  
  CanVibrate: function (){
    if(window.navigator && window.navigator.vibrate(1))
      return true;
    else
      return false;
  },
  
  Vibrate: function (millisecondsDuration){
    if(window.navigator && window.navigator.vibrate)
      window.navigator.vibrate(millisecondsDuration);
  },

});