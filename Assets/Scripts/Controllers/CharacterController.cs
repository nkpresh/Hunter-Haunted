using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace CustomController
{
    public class CharacterController : MonoBehaviour
    {
        public GameObject playerObj;

        [SerializeField]
        float rotateSpeed;
        Rigidbody rb;

        float velocity;

        [SerializeField]
        CharacterType characterType;

        [SerializeField]
        Slider healthBar;

        public CharacterBackend characterBackend;

        AttackManager attackManager;

        // public CharacterBaseState currentState;
        // public CharacterBaseState moveState;
        // public CharacterBaseState idleState;
        // public CharacterBaseState attackState;
        void Start()
        {
            HandleInputs();

            Init();
            healthBar.value = characterBackend.currentHp / characterBackend.maxHp;

        }

        void Init()
        {
            characterBackend = new CharacterBackend(this)
            {
                currentHp = 100,
                maxHp = 100
            };
            attackManager = new AttackManager(this, 100, 0);
            // moveState = new MoveState();
            // idleState = new IdleState();
            // attackState = new AttackState();
            // currentState = idleState;
            rb = GetComponent<Rigidbody>();
        }

        void HandleInputs()
        {
            CustomInputManager.OnMove += (x, y) =>
                        {
                            MovePlayer(new Vector2(x, y));
                        };
            CustomInputManager.OnDownwardAttack += (attackType) =>
            {

                Attack(attackType);
            };
        }

        public void Attack(AttackType attackType)
        {
            // attackState.EnterState(this, () =>
            // {

            // });
            attackManager.Attack(attackType, () =>
            {
                print("working attack");
                // currentState.OnExitState(this, idleState);
            });
        }

        public void TakeDamage(float amount)
        {
            characterBackend.ReduceHealth(amount);
            healthBar.value = characterBackend.currentHp / characterBackend.maxHp;
        }
        // public void SwitchState(CharacterBaseState nextState)
        // {
        //     currentState.OnExitState(this, nextState);
        // }

        void MovePlayer(Vector2 InputAxis)
        {
            print("working");
            // var animator = playerObj.GetComponent<Animator>();
            float vChange = Time.deltaTime * velocity;
            float dirZ = InputAxis.y;
            float dirX = InputAxis.x;
            Vector3 direction = new Vector3(dirX, 0, -dirZ);
            direction.Normalize();
            rb.velocity = direction * vChange;
            // animator.SetBool("Moving", active);
            SetRotation(direction);
        }

        public void SetRotation(Vector3 dir)
        {
            Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
            playerObj.transform.rotation = Quaternion.RotateTowards(playerObj.transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }

        private void Update()
        {
            // RotatePlayerToEmeny();
            // currentState.UpdateState(this);
        }


    }
}

