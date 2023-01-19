using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Shop
{
    public class StartButton : Graphic , IPointerDownHandler
    {
        public override void SetMaterialDirty() { return; }
        public override void SetVerticesDirty() { return; }
        
        public event Action ClickedDown;
        
        public void OnPointerDown(PointerEventData eventData) => 
            ClickedDown?.Invoke();
    }
}