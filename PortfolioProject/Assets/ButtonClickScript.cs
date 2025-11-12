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
    [Header("Button Texts")]
    private GameObject buttonTexts;
    [SerializeField]
    private GameObject unityPortfolio;
    [Header("Button GameObjects")]
    [SerializeField]
    private GameObject unityButton;
    [SerializeField]
    private GameObject soundDesignButton;
    [SerializeField]
    private GameObject physicalToysButton;
    [SerializeField]
    private GameObject returnToMainMenuButton;
    [SerializeField] PortfolioManager pm;

    [Space(10)]
    
    [SerializeField]
    int speed = 10;
    [SerializeField]
    float offSpeed = 2;
    float size = 2;

    public Camera mainCamera;
  
     
    // size control         
    [SerializeField]
    float growthRate = 1f;       // units per second while growing
    [SerializeField]
    float maxSize = 3f;          // clamp max scale
    private bool growing = false;

    private Vector3 startsize;
    private Vector3 startPos;
    private bool returnButtonClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        startsize = GetComponent<Transform>().localScale;
    }


    // Update is called once per frame
    void Update()
    {
        // Vector3 screenpos = mainCamera.WorldToScreenPoint(transform.position);
        // unityPortfolio.transform.position = screenpos;
        if (Input.GetMouseButtonDown(0))
        {

            Camera cam = mainCamera != null ? mainCamera : Camera.main;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject && tag != "ReturnButton")
                {
                    gameManager.openTarget(gameObject.name);
                    growing = true;
                }
                
                //restart buttons
                if(hit.collider.gameObject == gameObject && tag == "ReturnButton")
                {
                    gameManager.openTarget(gameObject.name);
                    pm.GetComponent<PortfolioManager>().ClearPortfolio();
                    pm.GetComponent<PortfolioManager>().ResetCurrentIndex();

                }
            }
        }

        offSpeed = Mathf.PingPong(Time.time, 5f);
        cube.transform.Rotate(new Vector3(15 * offSpeed, 30 * offSpeed, 45) * Time.deltaTime * speed);

         // increase size over time when growing
        // if (growing == true && returnButtonClicked == false)
        // {
        //     size += growthRate * Time.deltaTime;
        //     size = Mathf.Min(size, maxSize);
        //     cube.transform.localScale = Vector3.one * size;

        //     // stop growing if reached max AND remove UI elements
        //     if (Mathf.Approximately(size, maxSize))
        //     {
        //         DisableButtons();
        //         growing = false;
        //         cube.transform.localScale = startsize;
        //         size = 2;
        //     }
        // }
    }

    public void DisableButtons()
    {
        unityButton.SetActive(false);
        soundDesignButton.SetActive(false);
        physicalToysButton.SetActive(false);
        
    }
    public void EnableButtons()
    {
        returnButtonClicked = false;
        unityButton.SetActive(true);
        soundDesignButton.SetActive(true);
        physicalToysButton.SetActive(true);
    }
}
