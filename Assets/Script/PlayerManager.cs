using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    // public float MoveSpeed;
    PlayerControls inputActions;


    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Enable();
    }
    void Start()
    {
    }

    void Update()
    {
        Vector2 move = inputActions.LandMovement.Move.ReadValue<Vector2>();
        if (move != Vector2.zero)
        {
            Vector2 moveResult = move * 10 * Time.deltaTime;
            transform.Translate(moveResult.x, 0, moveResult.y);
        }
        // print(move);

    }
}
