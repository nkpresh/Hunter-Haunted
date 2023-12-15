using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerAnimationController animationController;// public float MoveSpeed;
    PlayerControls inputActions;

    float moveVelocity;
    public float rotateSpeed;
    public float moveSpeed;
    // bool sprint = false;

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
        Vector3 movementDir = new Vector3(move.x, 0, move.y);
        movementDir.Normalize();
        if (move != Vector2.zero)
        {
            transform.Translate(movementDir * moveSpeed * Time.deltaTime, Space.World);
            animationController.SetMoveAnimation(true);
            Quaternion rotation = Quaternion.LookRotation(movementDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            moveVelocity = Math.Clamp(moveVelocity, 0, 1);

            // print(10 * Time.deltaTime * 0.01);
            // print(move);
        }
        else
        {
            animationController.SetMoveAnimation(false);
            print(move);
        }

    }
}
