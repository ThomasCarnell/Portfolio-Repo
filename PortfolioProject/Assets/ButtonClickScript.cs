using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonClickScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private GameManager gameManager;
    [Header("Text GameObjects")]
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject unityPortfolio;

    [Space(10)]
    
    [SerializeField]
    int speed = 10;
    [SerializeField]
    float offSpeed = 2;
    float size = 2;

    public Camera mainCamera;
     
     
    // size control
    [SerializeField]
    float dynamicSize = 1f;             // current uniform scale
    [SerializeField]
    float growthRate = 1f;       // units per second while growing
    [SerializeField]
    float maxSize = 3f;          // clamp max scale
    private bool growing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = mainCamera != null ? mainCamera : Camera.main;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    gameManager.openTarget(gameObject.name);
                                ButtonClickSeq();

                }
            }
            //gameManager.openTarget(gameObject.name);
        }

        offSpeed = Mathf.PingPong(Time.time, 5f);
        //size = Mathf.PingPong(Time.time, 5f);
        cube.transform.Rotate(new Vector3(15 * offSpeed, 30 * offSpeed, 45) * Time.deltaTime * speed);

         // increase size over time when growing
        if (growing)
        {
            size += growthRate * Time.deltaTime;
            size = Mathf.Min(size, maxSize);
            cube.transform.localScale = Vector3.one * size;

            // stop growing if reached max AND remove UI elements
            if (Mathf.Approximately(size, maxSize))
            {
                growing = false;
                cube.gameObject.SetActive(false);
                mainCamera.backgroundColor = Color.white;
                title.gameObject.SetActive(false);


            }
        }
    }
    
    void ButtonClickSeq()
    {
        growing = true;
    }
}
