using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CustomInputManager : MonoBehaviour
{
    public delegate void Attack(AttackType attackType);
    public static event Attack OnDownwardAttack;
    public static event Attack OnBackwardAttack;
    public static event Attack OnRoundAttack;



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
                    OnDownwardAttack.Invoke(AttackType.DownwardAttack);
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                if (OnBackwardAttack != null)
                    OnBackwardAttack.Invoke(AttackType.BackwardAttack);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                if (OnRoundAttack != null)
                    OnRoundAttack.Invoke(AttackType.RoundAttack);
            }

            // if (Input.GetKeyDown(KeyCode.I))
            // {
            //     if (OnDownwardAttack != null)
            //         OnDownwardAttack.Invoke(AttackType.RoundAttack);
            // }

            //Combo
            // if (Input.GetKeyDown(KeyCode.T))
            // {
            //     if (OnDownwardAttack != null)
            //         OnDownwardAttack.Invoke(AttackType.DownwardAttack);
            // }
        }
    }
}
