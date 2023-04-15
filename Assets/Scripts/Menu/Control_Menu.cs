using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Menu : MonoBehaviour
{
    public int Main_Menu;

    public void Back_Button() 
    {
        SceneManager.LoadScene(Main_Menu);
    }
}
