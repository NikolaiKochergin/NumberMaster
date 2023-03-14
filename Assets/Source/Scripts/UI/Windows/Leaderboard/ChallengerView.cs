using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Leaderboard
{
    public class ChallengerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _rank;
        [SerializeField] private Image _avatar;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _scores;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Sprite _highlightSprite;

        public void SetRank(int rank) =>
            _rank.text = rank.ToString();

        public void SetAvatar(Sprite avatar) =>
            _avatar.sprite = avatar;

        public void SetName(string challengerName)
        {
            if (!string.IsNullOrEmpty(challengerName))
                _name.text = challengerName;
        }

        public void SetScores(int scores) =>
            _scores.text = scores.ToString();

        public void MakeHighlight() =>
            _backgroundImage.sprite = _highlightSprite;
    }
}