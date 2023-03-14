using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Leaderboard
{
    public class AuthorizationMenu : MonoBehaviour
    {
        [SerializeField] private Button _authorizationButton;

        public Button AuthorizationButton => _authorizationButton;

        private void Awake() => 
            Hide();

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);
    }
}
