using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.LeaderboardLogic
{
    public class ChallengerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _rank;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _scores;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Sprite _highlightSprite;
        

        public void SetRank(int rank) => 
            _rank.text = rank.ToString();

        public void SetAvatar(Sprite avatar) => 
            _image.sprite = avatar;

        public void SetName(string name) => 
            _name.text = name;

        public void SetScores(int scores) => 
            _scores.text = scores.ToString();

        public void MakeHighlight() => 
            _backgroundImage.sprite = _highlightSprite;
    }
}