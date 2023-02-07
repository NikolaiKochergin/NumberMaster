using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Source.Scripts.UI.Elements
{
    public class ClickedDownButton : Graphic , IPointerDownHandler
    {
        public override void SetMaterialDirty() { return; }
        public override void SetVerticesDirty() { return; }
        
        public event Action ClickedDown;
        
        public void OnPointerDown(PointerEventData eventData) => 
            ClickedDown?.Invoke();
    }
}