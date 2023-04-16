using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowCrash : MonoBehaviour
{
    public int Outside;

    private void Update() 
    {
        return;
    }
    
    public void GoOutside()
    {
        SceneManager.LoadScene(Outside);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GoOutside();
    }
}
