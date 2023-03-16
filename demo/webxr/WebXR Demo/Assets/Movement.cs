using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 0.015f;
    public float Sensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Speed;
        float zMove = Input.GetAxis("Vertical") * Speed;
        float yMove = 0.0f;

        float xRotate = Input.GetAxis("Mouse X") * Sensitivity;

        Vector3 move = transform.rotation * new Vector3(xMove, yMove, zMove);

        transform.position = transform.position + move;
        transform.Rotate(0, xRotate, 0);
    }
}
