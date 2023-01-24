using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.LeaderboardScripts
{
    public class ChallengerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _coins;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _rank;

        private Challenger _challenger;

        public void Render(Challenger challenger)
        {
            _challenger = challenger;
            _rank.text = challenger.Rank.ToString();
            _name.text = challenger.Name;
            _coins.text = challenger.CoinCount.ToString();
            _image.sprite = challenger.RankIcon;
        }

        public void SetName(string name)
        {
            _name.text = name;
        }

        public void SetScore(int score)
        {
            _coins.text = score.ToString();
        }
    }
}