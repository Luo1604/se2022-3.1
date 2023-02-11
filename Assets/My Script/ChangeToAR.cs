using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToAR : MonoBehaviour
{
    public void ChangeARdef()
    {
        SceneManager.LoadScene("ARscenes(DEF)");
    }

    public void ChangeARcus()
    {
        SceneManager.LoadScene("ARscenes(Custom)");
    }
}