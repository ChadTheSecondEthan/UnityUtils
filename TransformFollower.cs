using UnityEngine;

namespace Utils
{
    public class TransformFollower : MonoBehaviour
    {
        public Transform toFollow;
        public bool yAxisOnly = true;
        [Range(0f, 360f)]
        public float offset = 0f;

        void Start() => Update();

        void Update()
        {
            if (yAxisOnly)
            {
                float dx = toFollow.position.x - transform.position.x;
                float dz = transform.position.z - toFollow.position.z;
                float yRotation = Mathf.Rad2Deg * Mathf.Atan(-dx / dz);
                if (dz > 0) yRotation += 180f;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                    yRotation + offset, transform.eulerAngles.z);
            }
            else
                transform.LookAt(toFollow);
        }
    }
}