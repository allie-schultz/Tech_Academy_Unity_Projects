using UnityEngine;
using System.Collections;

public class ball_move : MonoBehaviour
{
    public float speed;
    private Rigidbody rigb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigb = GetComponent<Rigidbody>();
        
       
        if (rigb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject!");
            return;
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        

        Vector3 movement = new Vector3(moveHoriz, 0.0f, moveVert);
        rigb.AddForce(movement * speed);

        

    }
}
