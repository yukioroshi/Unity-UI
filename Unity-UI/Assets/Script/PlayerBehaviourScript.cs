using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviourScript : MonoBehaviour
{
    public PlayerInput playerControls;

    private InputAction move;
    private InputAction mouse;
    private InputAction look;


    private void Awake()
    {
        playerControls = new PlayerInput();

        
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        move.performed += Move;

        mouse = playerControls.Player.Fire;
        mouse.Enable();
        mouse.performed += Fire;

        look = playerControls.Player.Look;
        look.Enable();
        look.performed += Look;
    }

    private void OnDisable()
    {
        move.Disable();
        mouse.Disable();
        look.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log("forward");
    }


    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("piuu");
    }

    private void Look(InputAction.CallbackContext context)
    {
        Debug.Log("looking");
    }
}
