using UnityEngine;

public class AttachToObject : MonoBehaviour
{
    [SerializeField] private Transform target; // The object you want to follow
[SerializeField] private Vector3 offset = new Vector3(0, 1, 0);

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
            transform.position = target.position + offset;

        }
    }
    
}
