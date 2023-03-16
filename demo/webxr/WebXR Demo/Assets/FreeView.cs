using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeView : MonoBehaviour
{
    const float ROT_DEAD_ZONE = 15f;
    const float MIN_ROT_X = 360f - 90f + ROT_DEAD_ZONE;
    const float MAX_ROT_X = 90f - ROT_DEAD_ZONE;

    public float Sensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yRotate = Input.GetAxis("Mouse Y") * Sensitivity;
        if (yRotate == 0) {
            return;
        }
        
        Vector3 rotate = new Vector3(-yRotate, 0, 0);

        Quaternion rotation = transform.rotation;
        Vector3 current = rotation.eulerAngles;
        Vector3 target = (rotation * Quaternion.Euler(rotate)).eulerAngles;

        if (Math.Abs(current.y - target.y) < 0.1 && Math.Abs(current.z - target.z) < 0.1) {
            if (target.x > 180 && target.x < MIN_ROT_X) {
                target = new Vector3(MIN_ROT_X, target.y, target.z);
            } else if (target.x < 180 && target.x > MAX_ROT_X) {
                target = new Vector3(MAX_ROT_X, target.y, target.z);
            }
            transform.rotation = Quaternion.Euler(target);
        }
    }
}
