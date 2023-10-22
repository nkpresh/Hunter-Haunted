using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.UIElements;
using CharacterController = CustomController.CharacterController;

public class AttackManager
{

    public float currentEnergy;
    public float MaxEnergy;
    CharacterController player;
    CharacterController target;

    public float timer;
    bool canAttack;

    List<CharacterController> targets;

    public AttackManager(CharacterController player, float maxEnergy, float currentEnergy)
    {
        target = BattleManager.Instance.enemyCollection[0];
        targets = new List<CharacterController>();
        this.player = player;
        MaxEnergy = maxEnergy;
        this.currentEnergy = currentEnergy;
    }

    public void UpdateAttackTimer()
    {
        if (timer >= 2)
        {
            canAttack = true;
            timer = 0;
        }
    }
    public void Attack(AttackType attackType, Action callback)
    {
        // if (canAttack == false) return;
        switch (attackType)
        {
            case (AttackType.DownwardAttack):
                OnDownwardAttack();
                break;
            case (AttackType.BackwardAttack):
                OnBackwardAttack();
                break;
            case (AttackType.RoundAttack):
                OnRoundAttack();
                break;
            case (AttackType.Kick):
                OnKickAttack();
                break;
            default:
                break;
        }
        callback();
    }
    public void OnDownwardAttack()
    {
        target.TakeDamage(5);
    }

    public void OnBackwardAttack()
    {
        target.TakeDamage(5);
    }

    public void OnKickAttack()
    {
        target.TakeDamage(5);
    }

    public void OnRoundAttack()
    {
        target.TakeDamage(10);
    }

    public void ComboAttack()
    {
        target.TakeDamage(20);
    }

    public void RotatePlayerTo(Transform target)
    {
        var dotProd = Vector3.Dot(player.playerObj.transform.forward.normalized, target.forward.normalized);
        if (Math.Abs(dotProd) != 1)
        {
            player.SetRotation(-target.transform.forward);
        }
    }

    public void IncreaseEnergy(float rate)
    {
        if (currentEnergy >= MaxEnergy)
        {
            currentEnergy = 0;
        }
        currentEnergy += rate;
    }
}
