using System.Collections;
using System.Collections.Generic;
using CustomController;

public class IdleState : CharacterBaseState
{

    public override void UpdateState(CharacterController characterController)
    {
        // currentState = this;
        UnityEngine.Debug.Log("Working fine");
    }
}
