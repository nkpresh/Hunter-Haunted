using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using CustomController;

public abstract class CharacterBaseState
{
    public void EnterState(CharacterController characterController, CharacterBaseState nextState)
    {
        characterController.currentState = nextState;
        UpdateState(characterController);
    }

    public abstract void UpdateState(CharacterController characterController);

    public void OnExitState(CharacterController characterController, CharacterBaseState nextState)
    {
        nextState.EnterState(characterController, nextState);
    }

}
