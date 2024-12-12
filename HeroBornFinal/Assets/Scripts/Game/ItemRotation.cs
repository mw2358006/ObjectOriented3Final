using UnityEngine;
public class ItemRotation : MonoBehaviour
{
    public int rotationSpeed = 100;
    private Transform itemTransform;
    void Awake()
    {
        itemTransform = this.GetComponent<Transform>();
    }

    void Update()
    {
        itemTransform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
