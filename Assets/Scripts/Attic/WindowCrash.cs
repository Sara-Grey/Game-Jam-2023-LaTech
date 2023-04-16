using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowCrash : MonoBehaviour
{
    public int Outside;
 
    public void StartGame()
    {
        SceneManager.LoadScene(Outside);
    }

}
