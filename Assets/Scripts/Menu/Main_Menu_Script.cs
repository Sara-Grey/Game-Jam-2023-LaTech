using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour
{
    public int Attic;
    public int Control;

    public void StartGame()
    {

        SceneManager.LoadScene(Attic);
    }
    public void Controls() 
    {
        SceneManager.LoadScene(Control);    
    }
}
