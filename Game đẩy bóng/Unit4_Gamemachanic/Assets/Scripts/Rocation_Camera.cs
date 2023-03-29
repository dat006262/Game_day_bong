using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocation_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed=100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorazeInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateSpeed*Time.deltaTime*HorazeInput);
    }
}
