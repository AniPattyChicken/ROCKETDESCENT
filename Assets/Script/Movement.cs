using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] private  float MainThrust = 200;
    [SerializeField] private  float mainRotate = 1f;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessThrust();
       ProcessRotation(); 
    }
    void ProcessThrust()
    {
       if (Input.GetKey(KeyCode.Space))
       {
       //Debug.Log("Pressed SPACE - Boost");
       rb.AddRelativeForce(Vector3.up * MainThrust * Time.deltaTime);

       }
    }

    void ProcessRotation()
    {
if (Input.GetKey(KeyCode.A))
       {
       //Debug.Log("Rotating Left");
         ApplyRotation(mainRotate);
       }
    else if (Input.GetKey(KeyCode.D))
       {
        //Debug.Log("Rotating Right");
         ApplyRotation(-mainRotate);
       }
    }
    void ApplyRotation(float rotationFrame)
    {
        rb.freezeRotation = true; //freezing rotation to rotate manually
         transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
         rb.freezeRotation = false; //unfreezing rotation so physics system can get over
    }
    }

