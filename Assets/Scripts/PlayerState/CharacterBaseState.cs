using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using CustomController;
using System;

public abstract class CharacterBaseState
{
    public void EnterState(CharacterController characterController)
    {

        characterController.currentState = this;
    }

    public abstract void UpdateState(CharacterController characterController);

    public void OnExitState(CharacterController characterController, CharacterBaseState nextState)
    {
        nextState.EnterState(characterController);
    }

}
