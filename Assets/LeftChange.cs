using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeftChange : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("paper");
    }
}
