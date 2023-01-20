using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.Scripts.PlayerLogic.ViewLogic
{
    public class NumberView : MonoBehaviour
    {
        [SerializeField] private Character[] _characters;

        private Dictionary<char, GameObject> _characterMap;

        private void Awake()
        {
            HideGlyphs();
            _characterMap = _characters.ToDictionary(x => x.Key, x => x.Glyph);
        }

        public void Show(char character)
        {
            HideGlyphs();
            _characterMap[character].SetActive(true);
        }

        private void HideGlyphs()
        {
            foreach (Character character in _characters)
                character.Glyph.SetActive(false);
        }
    }
}
