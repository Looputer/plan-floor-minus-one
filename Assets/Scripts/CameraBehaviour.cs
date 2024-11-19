using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(15.61f, 2.44f, 2.23f);

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = target.TransformPoint(offset);
        transform.LookAt(target);
    }
}