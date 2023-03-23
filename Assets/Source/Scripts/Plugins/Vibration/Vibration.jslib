mergeInto(LibraryManager.library, {
  
  CanVibrate: function (){
    return window.navigator && window.navigator.vibrate;
  },
  
  Vibrate: function (millisecondsDuration){
    if(window.navigator && window.navigator.vibrate)
      window.navigator.vibrate(millisecondsDuration);
  },

});