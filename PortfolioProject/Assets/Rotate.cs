using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    int speed = 10;
    [SerializeField]
    float offSpeed = 2;
    [SerializeField]
    float size = 2;
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private bool iAmAButton = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offSpeed = Mathf.PingPong(Time.time, 5f);
        size = Mathf.PingPong(Time.time, 5f);
        cube.transform.Rotate(new Vector3(15 * offSpeed, 30 * offSpeed, 45) * Time.deltaTime * speed);

        cube.transform.localScale = new Vector3(1 + size / 5, 1 + size / 5, 1 + size / 5);
        
            if (cube.transform.localScale.x >= 3 && iAmAButton == false)
            {
                cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
    }
}
