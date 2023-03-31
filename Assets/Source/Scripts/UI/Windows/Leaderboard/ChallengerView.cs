using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Source.Scripts.UI.Windows.Leaderboard
{
    public class ChallengerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _rank;
        [SerializeField] private RawImage _avatar;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _scores;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Sprite _highlightSprite;

        private Coroutine _avatarRoutine;

        private void OnDisable()
        {
            if(_avatarRoutine != null)
                StopCoroutine(_avatarRoutine);
        }

        public void SetRank(int rank) =>
            _rank.text = rank.ToString();

        public void SetAvatar(string avatarUrl) => 
            _avatarRoutine = StartCoroutine(SetAvatarUrl(avatarUrl));

        public void SetName(string challengerName)
        {
            if (!string.IsNullOrEmpty(challengerName))
                _name.text = challengerName;
        }

        public void SetScores(int scores) =>
            _scores.text = scores.ToString();

        public void MakeHighlight() =>
            _backgroundImage.sprite = _highlightSprite;

        private IEnumerator SetAvatarUrl(string url)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();
            if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                Debug.Log(request.error);
            else
                _avatar.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
        }
    }
}