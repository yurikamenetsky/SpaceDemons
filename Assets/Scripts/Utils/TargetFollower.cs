using UnityEngine;

namespace SpaceDemons.Utils
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField]
        Transform target;

        [SerializeField]
        bool smooth = false;

        [SerializeField]
        float smoothValue = 0.05f;

        Vector3 offset;
       
        void Start()
        {
            offset = transform.position - target.position;
        }

        void LateUpdate()
        {
            Vector3 newPosition = target.position + offset;
            if(smooth)
            {
                Vector3 velocity = Vector3.zero;
                newPosition = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothValue);
            }
            transform.position = newPosition;
        }
    }
}
