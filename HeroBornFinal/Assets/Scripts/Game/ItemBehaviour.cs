using UnityEngine;
public class ItemBehaviour : MonoBehaviour
{
    void Awake()
    {
        // 아이템 위치 랜덤
        this.gameObject.transform.position = new Vector3(Random.Range(-15, 16), 1, Random.Range(-15, 16));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("아이템 딸깍");
        }
    }
}
