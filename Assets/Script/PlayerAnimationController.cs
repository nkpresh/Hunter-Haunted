using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    int velocityHash;
    float velocity = 0;
    bool canMove = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");

    }

    void Update()
    {
        animator.SetFloat(velocityHash, velocity);
        if (canMove)
        {
            velocity += Time.deltaTime * 0.5F;
            // print(velocity);
        }
        else
        {
            velocity = 0;
        }
    }

    public void SetMoveAnimation(bool active)
    {
        canMove = active;
    }
}
