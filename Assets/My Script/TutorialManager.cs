using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    private int popUpIndex;

    void Awake() 
    {
 
        if (PlayerPrefs.GetInt("times") == 1)
        {
            SceneManager.LoadScene("SelectionScene");
        }
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
            PlayerPrefs.SetInt("times", 1);
            SceneManager.LoadScene("SelectionScene");
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