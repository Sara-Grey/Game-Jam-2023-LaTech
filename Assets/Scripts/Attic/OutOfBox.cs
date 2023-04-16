using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBox : MonoBehaviour
{
    public int pushes = 0;

    private void Update() 
    {
        return;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        pushes++;
        if (pushes == 3) 
        {
            OpenBox();
        }
        else 
        {
            Debug.Log("Teddy pushes box");
            return;
        }
    }

    void OpenBox() 
    {
        return;
    }
}
