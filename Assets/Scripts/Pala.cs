using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    private Transform trans;
    public float speed = 4f;
    private enum Movements { stop = 0, up = 1, down = 2}
    private Movements movement = Movements.stop;

    private void Awake()
    {
        trans = transform;
    }

    private void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        switch(movement)
        {
            case Movements.stop: trans.position += new Vector3( 0f, 0f, 0f); break;
            case Movements.up: trans.position += new Vector3(0f, Time.deltaTime * speed, 0f); break;
            case Movements.down: trans.position -= new Vector3(0f, Time.deltaTime * speed, 0f); break;
        }
    }

    public void MoveUp()
    {
        movement = Movements.up;
    }

    public void MoveDown()
    {
        movement = Movements.down;
    }

    public void StopMove()
    {
        movement = Movements.stop;
    }

}
