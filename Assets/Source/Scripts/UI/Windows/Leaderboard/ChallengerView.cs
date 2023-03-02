using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Leaderboard
{
    public class ChallengerView : MonoBehaviour
    {
        private const string UnknownPlayerNameRu = "Неизвестный игрок";
        private const string UnknownPlayerNameEn = "Unknown player";
        private const string UnknownPlayerNameTr = "Bilinmeyen oyuncu";
        
        [SerializeField] private TextMeshProUGUI _rank;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _scores;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Sprite _highlightSprite;

        public void SetRank(int rank) => 
            _rank.text = rank.ToString();

        public void SetAvatar(string avatar) =>
            Debug.Log(avatar);
            //_image.sprite = avatar;

        public void SetName(string name) => 
            _name.text = string.IsNullOrEmpty(name) ? GetLocalLanguageUnknownPlayerName() : name;

        public void SetScores(int scores) => 
            _scores.text = scores.ToString();

        public void MakeHighlight() => 
            _backgroundImage.sprite = _highlightSprite;

        private string GetLocalLanguageUnknownPlayerName() =>
#if YANDEX_GAMES && !UNITY_EDITOR 
            YandexGamesSdk.Environment.i18n.lang switch
            {
                "tr" => UnknownPlayerNameTr,
                "ru" => UnknownPlayerNameRu,
                "en" => UnknownPlayerNameEn,
                _ => null
            };
#elif UNITY_EDITOR
            "Unknown Player";
#endif
    }
}