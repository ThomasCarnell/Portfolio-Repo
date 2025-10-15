using UnityEngine;

public class PointAttObj : MonoBehaviour
{
    [SerializeField] private Transform target; // Assign your target object in the Inspector
    [SerializeField] private float orbitSpeed = 30f;
    [SerializeField] private float orbitRadius = 5f;
    [SerializeField] private Vector3 orbitAxis = Vector3.up;

    private float angle = 0f;

    void Update()
    {
        if (target != null)
        {
            // Calculate new position in a circle around the target
            angle += orbitSpeed * Time.deltaTime;
            float rad = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Sin(rad), 0, Mathf.Cos(rad)) * orbitRadius;
            transform.position = target.position + offset;

            // Always look at the target
            transform.LookAt(target);
        }
    }
}