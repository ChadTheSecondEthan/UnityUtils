using UnityEngine;

namespace Utils
{
    public class FloatingText : MonoBehaviour
    {
        public Transform textPrefab;

        static FloatingText instance;

        void Awake() => instance = this;

        public static Transform CreateFloatingText(Vector3 location, float velocity, string text, bool followPlayer = false, float time = 1f)
        {
            Transform transform = Instantiate(instance.textPrefab, instance.transform);
            transform.position = location;

            float distance = Player.instance.DistanceTo(location) * 0.15f * time;
            transform.localScale = VectorAddons.Value(distance);
            velocity *= distance;

            if (followPlayer)
            {
                TransformFollower tf = transform.gameObject.AddComponent<TransformFollower>();
                tf.toFollow = Player.instance.transform;
                tf.offset = 180f;
            }
            transform.gameObject.SetActive(true);
            LeanTween.moveY(transform.gameObject, location.y + velocity, time);
            transform.GetComponent<TMPro.TMP_Text>().text = text;
            Destroy(transform.gameObject, 1f);

            return transform;
        }
    }
}