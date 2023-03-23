mergeInto(LibraryManager.library, {
  
  Vibration: function (){    
    if(window.navigator && window.navigator.vibrate)
      window.navigator.vibrate();
  }

});