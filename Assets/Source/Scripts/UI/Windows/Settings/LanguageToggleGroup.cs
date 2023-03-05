using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.UI.Windows.Settings
{
    public class LanguageToggleGroup : MonoBehaviour
    {
        [SerializeField] private LanguageToggle[] _languageToggles;

        public IEnumerable<LanguageToggle> Toggles => _languageToggles;
    }
}
