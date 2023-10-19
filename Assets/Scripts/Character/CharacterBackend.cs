using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Enums;
using Models;
using UnityEngine;
using CharacterController = CustomController.CharacterController;

public class CharacterBackend

{

    public float currentHp;
    public float maxHp;
    public float attack;
    public float kick;
    public float ComboAttack;

    public AttackData attackData;

    public CharacterController characterController;

    public CharacterBackend(CharacterController characterController)
    {
        this.characterController = characterController;
    }
    public void ReduceHealth(AttackData attackData)
    {
        // switch (attackData.attackType)
        // {
        //     case AttackType.Attack:
        //         {
        //             currentHp -= attack;
        //             break;
        //         }
        //     case AttackType.ComboAttack:
        //         {
        //             currentHp -= ComboAttack;
        //             break;
        //         }
        //     case AttackType.Kick:
        //         {
        //             currentHp -= kick;
        //             break;
        //         }
        // }
    }
}
