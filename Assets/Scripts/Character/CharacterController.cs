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
        [SerializeField]
        GameObject playerObj;

        [SerializeField]
        float rotateSpeed;
        Rigidbody rb;

        float velocity;

        [SerializeField]
        CharacterType characterType;

        [SerializeField]
        Slider healthBar;

        CharacterBackend characterBackend;

        [HideInInspector]
        public CharacterController Target;

        public CharacterBaseState currentState;
        public CharacterBaseState moveState;
        public CharacterBaseState idleState;
        public CharacterBaseState attackState;
        void Start()
        {
            characterBackend = new CharacterBackend(this)
            {
                currentHp = 100,
                maxHp = 100,
                attack = 15,
                kick = 7
            };
            HandleInputs();
            moveState = new MoveState();
            idleState = new IdleState();
            attackState = new AttackState();
            currentState = idleState;

            healthBar.value = characterBackend.currentHp / characterBackend.maxHp;

            rb = GetComponent<Rigidbody>();
            // FindTarget();
            Target = BattleManager.Instance.enemyCollection[0];
        }

        void HandleInputs()
        {
            CustomInputManager.OnMove += (x, y) =>
                        {
                            MovePlayer(new Vector2(x, y));
                        };
            CustomInputManager.OnDownwardAttack += () =>
            {
                SwitchState(attackState);
            };
        }
        public void Attack()
        {
            OnAttack(Target);
        }
        public void OnAttack(CharacterController enemy)
        {
            enemy.TakeDamage(10);
        }

        public void TakeDamage(float amount)
        {
            AttackData attack = new AttackData(AttackType.UpwardAttack, amount);
            characterBackend.ReduceHealth(attack);
            healthBar.value = characterBackend.currentHp / characterBackend.maxHp;
        }
        public void SwitchState(CharacterBaseState nextState)
        {
            currentState.OnExitState(this, nextState);
        }

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

        public void RotatePlayerToEmeny()
        {
            var dotProd = Vector3.Dot(playerObj.transform.forward.normalized, Target.transform.forward.normalized);
            print(dotProd);
            if (Math.Abs(dotProd) != 1)
            {
                SetRotation(-Target.transform.forward);
            }
        }
        private void Update()
        {
            RotatePlayerToEmeny();
        }
    }
}

