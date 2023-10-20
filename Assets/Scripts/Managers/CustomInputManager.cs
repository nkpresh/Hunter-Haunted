using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CustomInputManager : MonoBehaviour
{
    public delegate void Attack();
    public static event Attack OnDownwardAttack;
    public static event Attack OnUpwardAttack;
    public static event Attack OnKickAttack;
    public static event Attack OnComboAttack;



    public delegate void MovementCallbackType(float x, float y);
    public static event MovementCallbackType OnMove;

    void Start()
    {

    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                if (OnMove != null)
                    OnMove.Invoke(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                if (OnDownwardAttack != null)
                    OnDownwardAttack.Invoke();
            }
        }
    }

    public void GetPlayerInput()
    {

    }
}
