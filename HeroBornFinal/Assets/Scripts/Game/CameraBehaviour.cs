using UnityEngine;
public class CameraBehaviour : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);

    private Transform _target;
    void Awake()
    {
        _target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        this.transform.position = _target.TransformPoint(camOffset);

        this.transform.LookAt(_target);
    }
}
