using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Models;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace CustomController
{
    public class CharacterController : MonoBehaviour
    {
        // public GameObject playerObj;

        [SerializeField]
        float rotateSpeed;
        [SerializeField]
        CharacterType characterType;
        [SerializeField]
        Slider healthBar;
        [SerializeField]
        float moveSpeed;

        public AnimationStateController animationController;
        public CharacterBackend characterBackend;
        Rigidbody rb;
        CharacterController target;
        AttackManager attackManager;
        bool canRotate;


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
            target = BattleManager.Instance.enemyCollection[0];

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
            CustomInputManager.OnBackwardAttack += (attackType) =>
            {

                Attack(attackType);
            };
            CustomInputManager.OnRoundAttack += (attackType) =>
            {
                Attack(attackType);
            };
        }

        public void Attack(AttackType attackType)
        {
            attackManager.Attack(attackType, target, () =>
            {
                canRotate = true;
            });
        }

        public void TakeDamage(float amount)
        {
            characterBackend.ReduceHealth(amount);
            healthBar.value = characterBackend.currentHp / characterBackend.maxHp;
        }

        void MovePlayer(Vector2 InputAxis)
        {
            float dirZ = InputAxis.y;
            float dirX = InputAxis.x;
            Vector3 dir = new Vector3(dirX, 0, -dirZ);
            Vector3 displacement = transform.position + dir * moveSpeed * Time.deltaTime;
            transform.position = displacement;
            SetRotation(dir);
            print(dir.magnitude);
            animationController.Move(dir.magnitude > 0.03);
        }

        public void SetRotation(Vector3 dir)
        {
            Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
        private void Update()
        {
            if (canRotate)
            {
                Vector3 enemyDir = (target.transform.position - transform.position).normalized;
                if (enemyDir == Vector3.zero) return;
                var dotProd = Vector3.Dot(transform.forward, enemyDir);
                SetRotation(enemyDir);
                if (dotProd == 1 || dotProd == 0)
                {
                    canRotate = false;
                }
            }
        }
    }
}

