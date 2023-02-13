using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToAR : MonoBehaviour
{
    public void ChangeAR()
    {
        SceneManager.LoadScene("ARscenes");
    }
}