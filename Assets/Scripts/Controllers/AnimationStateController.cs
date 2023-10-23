using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;

    bool isMoving;

    float velocity;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isMoving)
        {
            if (velocity <= 5)
                velocity += 0.01f;
        }
    }

    public void Move(bool active)
    {
        isMoving = active;
        animator.SetBool("Moving", active);
    }


    public void SwitchAnimationFloat(string name, float value)
    {

    }

    public void SetAnimationBool(string name, bool value)
    {
        animator.SetBool(name, value);

    }

    public void SetAnimationTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
