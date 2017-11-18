using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderId : MonoBehaviour
{ 
    public int pos = 0;
	public int Pos { get { return pos; }}

    public Pala parent;

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.name.Contains("Bound"))
        {
            if (pos == 0)
                parent.StopUp();
            else if (pos == 2)
                parent.StopDown();
        }   
    }
}
