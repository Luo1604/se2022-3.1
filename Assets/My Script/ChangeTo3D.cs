using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTo3D : MonoBehaviour
{
    public void Change3Ddef()
    {
        SceneManager.LoadScene("3DScenes(DEF)");
    }

    public void Change3Dcus()
    {
        SceneManager.LoadScene("3DScenes(Custom)");
    }
}
