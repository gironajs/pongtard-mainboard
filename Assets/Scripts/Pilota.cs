using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilota : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initPos;
    public float hSpeed = 10f;
    public float vSpeed = 0f;

    public Points points;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
        rb.AddForce(new Vector3(hSpeed * 1.1f, vSpeed, 0f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(hSpeed, vSpeed, 0f);
        //***NO***trans.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.name.Contains("Paret"))
        {
            vSpeed = vSpeed * -1;
        }
        else if (col.transform.name.Contains("pad"))
        {
            ColliderId colId = col.transform.GetComponent<ColliderId>();

            switch (colId.Pos)
            {
                case 0: vSpeed = 5f; break;
                case 1: vSpeed = 0f; break;
                case 2: vSpeed = -5f; break;
            }

            hSpeed = hSpeed * -1;
        }
        
    }

    private void OnBecameInvisible()
    {
        if (transform.position.x > 0)
            points.Player1up();
        else
            points.Player2up();

        transform.position = initPos;
    }
}
