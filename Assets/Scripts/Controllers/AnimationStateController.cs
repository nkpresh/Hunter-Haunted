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
            if (velocity < 1)
            {
                SetAnimationFloat("Velocity", velocity);
                velocity += 0.001f;
            }
        }
        else
        {
            velocity = 0;
        }
    }

    public void Move(bool active)
    {
        isMoving = active;
        SetAnimationBool("Move", active);
        SetAnimationFloat("Velocity", velocity);
        print(velocity);
    }


    public void SetAnimationFloat(string name, float value)
    {
        animator.SetFloat(name, value);
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
