using UnityEngine;

namespace Source.Scripts.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _following;

        private void LateUpdate()
        {
            if(_following != null)
                transform.position = FollowPointPosition();
        }

        public void Follow(Transform following) => 
            _following = following;

        private Vector3 FollowPointPosition() => 
            new Vector3(transform.position.x, transform.position.y, _following.transform.position.z);
    }
}
