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
    private Material cubeMAt;
    [SerializeField]
    private Text cubeText;
    [SerializeField]
    private Text counterText;

    int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        cubeMAt.color = Color.red;
        cube.GetComponent<Renderer>().material = cubeMAt;
        counterText.text = "Counter: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == cube)
                {
                    counterText.text = "Counter: " + counter++;
                    if (cubeMAt.color == Color.green)
                    {
                        ChangeCubeColorRed();
                        UpdateCubeTextRed();
                        return;
                    }
                    ChangeCubeColorGreen();
                    UpdateCubeTextGreen();
                }
            }
        }
    }

    //Green
    private void UpdateCubeTextGreen()
    {
        cubeText.text = "Green";
    }

    private void ChangeCubeColorGreen()
    {
        cubeMAt.color = Color.green;
    }

    //Red
    private void UpdateCubeTextRed()
    {
        cubeText.text = "Red";
    }
    private void ChangeCubeColorRed()
    {
        cubeMAt.color = Color.red;
    }
}
