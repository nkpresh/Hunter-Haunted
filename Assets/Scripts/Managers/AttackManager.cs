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
    public float timer;
    // bool canAttack;

    List<CharacterController> targets;

    public AttackManager(CharacterController player, float maxEnergy, float currentEnergy)
    {
        targets = new List<CharacterController>();
        this.player = player;
        MaxEnergy = maxEnergy;
        this.currentEnergy = currentEnergy;
    }

    public void UpdateAttackTimer()
    {
        if (timer >= 2)
        {
            // canAttack = true;
            timer = 0;
        }
    }
    public void Attack(AttackType attackType, CharacterController target, Action callback)
    {
        switch (attackType)
        {
            case (AttackType.DownwardAttack):
                OnDownwardAttack(target);
                break;
            case (AttackType.BackwardAttack):
                OnBackwardAttack(target);
                break;
            case (AttackType.RoundAttack):
                OnRoundAttack(target);
                break;
            case (AttackType.Kick):
                OnKickAttack(target);
                break;
            default:
                break;
        }
        callback();
    }

    public IEnumerator StartAttack(CharacterController target, string animName, float amount, float delay)
    {
        player.animationController.SetAnimationTrigger(animName);
        yield return new WaitForSeconds(delay);
        target.TakeDamage(amount);
        yield break;

    }

    public void OnDownwardAttack(CharacterController target)
    {
        target.StartCoroutine(StartAttack(target, "DownAttackTrig", 5, 0.5F));
    }

    public void OnBackwardAttack(CharacterController target)
    {
        target.StartCoroutine(StartAttack(target, "BackAttackTrig", 5, 0.5F));

    }

    public void OnKickAttack(CharacterController target)
    {
        // target.StartCoroutine(StartAttack(target, "KickTrig", 5));

    }

    public void OnRoundAttack(CharacterController target)
    {
        target.StartCoroutine(StartAttack(target, "RoundAttackTrig", 10, 1.2F));
    }

    public void ComboAttack(CharacterController target)
    {
        // target.StartCoroutine(StartAttack(target, 20));
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
