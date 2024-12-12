using UnityEngine;
public class BulletBehaviour : MonoBehaviour
{
    public float onScreenDelay = 3f;
    void Awake()
    {
        Destroy(this.gameObject, onScreenDelay);
    }

    // 총알이 벽에 닿으면 바로 삭제
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
