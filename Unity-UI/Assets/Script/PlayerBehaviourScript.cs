using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]

public class PlayerBehaviourScript : MonoBehaviour
{
    public PlayerInput playerControls;



    private Vector2 _input;
    private Vector3 _direction;

    private CharacterController _characterController;

    private void Awake()
    {

        _characterController = GetComponent<CharacterController>();
    }


    public void Move(InputAction.CallbackContext context)
    {
        
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _direction.y);
        Debug.Log(_input);
    }


    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("piuu");
    }

    public void Look(InputAction.CallbackContext context)
    {
        Debug.Log("looking");
    }
}
