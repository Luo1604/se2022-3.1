using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    private int popUpIndex;

    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++) {
            if (i == popUpIndex) {
                popUps[popUpIndex].SetActive(true);
            } else {
                popUps[i].SetActive(false);
            }
        }

        ClickEvent();

        if (popUpIndex == popUps.Length) { 
            popUps[popUpIndex - 1].SetActive(false);
            this.enabled = false;
        }
    }

    void ClickEvent() 
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                popUpIndex++;
            }
        }
    }
}