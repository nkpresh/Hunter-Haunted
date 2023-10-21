using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enums
{
    public enum AnimationParams
    {

    }

    [Serializable]
    public enum CharacterType
    {
        Player,
        Ai
    }

    [Serializable]
    public enum AttackType
    {
        ComboAttack,
        BackwardAttack,
        DownwardAttack,
        RoundAttack,
        Kick
    }

    public enum PlayerState
    {
        Idle,
        Attack,
        Movement
    }
}
