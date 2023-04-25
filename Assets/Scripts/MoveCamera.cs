using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, GM.verticalVel, 3);
    }
}
