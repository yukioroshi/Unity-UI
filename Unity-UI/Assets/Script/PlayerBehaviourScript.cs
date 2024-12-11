using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody playerRb;


    private float horizontalInput;
    private float forwardInput;

    private float rotate;
    public float rotationspeed;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        //get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //rotate the player
        rotate = horizontalInput * rotationspeed * Time.deltaTime;
        transform.Rotate(0f, rotate, 0f);

        //move the player forward
        if (Input.GetKey(KeyCode.W))
        {
            playerRb.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);

        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddRelativeForce(Vector3.back * speed, ForceMode.Acceleration);
        }
    }


}
