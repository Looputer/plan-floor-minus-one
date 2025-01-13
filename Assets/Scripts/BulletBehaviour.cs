using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float onScreenTime = 5f;

    void Start()
    {
        Destroy(gameObject, onScreenTime);
    }
}
