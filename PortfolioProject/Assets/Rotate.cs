using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    int speed = 10;
    [SerializeField]
    float offSpeed = 2;
    [SerializeField]
    private GameObject cube;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offSpeed = Mathf.PingPong(Time.time, 5f);
        cube.transform.Rotate(new Vector3(15 * offSpeed, 30 * offSpeed, 45) * Time.deltaTime * speed);
    }
}
