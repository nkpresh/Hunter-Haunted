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

    public AttackData attackData;

    public CharacterController characterController;

    public CharacterBackend(CharacterController characterController)
    {
        this.characterController = characterController;
    }
    public void ReduceHealth(float amount)
    {
        currentHp -= amount;
    }
}
