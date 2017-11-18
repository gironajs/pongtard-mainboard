using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilota : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initPos;
    public float speed = 10f;


    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
        rb.AddForce(new Vector3(speed * 1.1f, speed, 0f), ForceMode.Impulse);
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
        //***NO***trans.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = speed * -1;
    }

    private void OnBecameInvisible()
    {
        transform.position = initPos;
    }
}
