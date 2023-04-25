using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public KeyCode moveLeft;
    public KeyCode moveRight;

    private int lane = 1;
    private float HorVel = 0f;
    private bool moving = false;

    public Rigidbody rb;
     
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(HorVel, GM.verticalVel, 3);

        if (Input.GetKeyDown(moveLeft) && lane >= 1 && !moving)
        {
            moving = true;
            HorVel = -2f;
            lane -= 1;
            StartCoroutine(StopSlide());
            

        }
        if (Input.GetKeyDown(moveRight) && lane <= 1 && !moving)
        {
            moving = true;
            HorVel = 2f;
            lane += 1;
            StartCoroutine(StopSlide());
            

        }
    }

    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        HorVel = 0f;
        moving = false;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obs")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Capsule")
        {
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RampTrigger")
        {
            GM.verticalVel = 1.6f;
        }

        if (other.gameObject.name == "RampExit")
        {
            GM.verticalVel = 0;
        }
    }
}
