using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTo3D : MonoBehaviour
{
    public void FromDefault()
    {
        SceneManager.LoadScene("3DScenes");
        PlayerPrefs.SetInt("type", 0);
    }

    public void FromFile()
    {
        SceneManager.LoadScene("3DScenes");
        PlayerPrefs.SetInt("type", 1);
    }
}
