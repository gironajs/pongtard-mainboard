using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    private Transform trans;
    public float speed = 4f;
    private enum Movements { stop = 0, up = 1, down = 2}
    private Movements movement = Movements.stop;

    private bool canGoUp, canGoDown;

    private void Awake()
    {
        trans = transform;
        canGoUp = canGoDown = true;
    }

    private void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        switch(movement)
        {
            case Movements.stop: break;
            case Movements.up: trans.position += new Vector3(0f, Time.deltaTime * speed, 0f); break;
            case Movements.down: trans.position -= new Vector3(0f, Time.deltaTime * speed, 0f); break;
        }
    }

    public void MoveUp()
    {
        if(canGoUp)
            movement = Movements.up;

        canGoDown = true;
    }

    public void MoveDown()
    {
        if(canGoDown)
            movement = Movements.down;

        canGoUp = true;
    }

    public void StopMove()
    {
        movement = Movements.stop;
    }

    public void StopUp()
    {

        canGoUp = false;
        StopMove();
        Debug.Log("stop up");
    }

    public void StopDown()
    {
        canGoDown = false;
        StopMove();
        Debug.Log("stop down");
    }
}
