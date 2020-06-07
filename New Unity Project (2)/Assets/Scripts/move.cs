using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed=20.0f;
    [SerializeField] float turnSpeed=45.0f;
    private float horizontalInput;
    private float forwardInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput) ;
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //}
        
    }
}
