using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CustomController;
using Enums;


public class AttackState : CharacterBaseState
{
    AttackType attackType;
    public override void UpdateState(CharacterController characterController)
    {
        // characterController.Attack();
        // characterController.SwitchState(characterController.idleState);
    }
}
