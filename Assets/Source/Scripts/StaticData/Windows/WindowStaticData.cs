using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.StaticData.Windows
{
    [CreateAssetMenu(menuName = "Static Data/Window static data", fileName = "WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}