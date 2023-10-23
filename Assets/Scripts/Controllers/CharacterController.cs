using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Models;
using TMPro;
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

        public AnimationStateController animationController;
        public CharacterBackend characterBackend;

        Rigidbody rb;

        [SerializeField]
        float velocity;

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
            canRotate = true;
            attackManager.Attack(attackType, target);
        }

        public void TakeDamage(float amount)
        {
            characterBackend.ReduceHealth(amount);
            healthBar.value = characterBackend.currentHp / characterBackend.maxHp;
        }

        void MovePlayer(Vector2 InputAxis)
        {
            //float vChange = Time.deltaTime * velocity;
            float dirZ = InputAxis.y;
            float dirX = InputAxis.x;
            Vector3 direction = new Vector3(dirX, 0, -dirZ) * Time.deltaTime * velocity;
            print(direction);
            rb.AddForce(direction);
            // canRotate = true;
            // SetRotation(direction);
        }

        public void SetAttackRotation(Vector3 dir)
        {
            var dotProd = Vector3.Dot(transform.forward.normalized, dir.normalized);

            if (dotProd != 0)
            {
                SetRotation(-dir);
            }
            else
            {
                canRotate = false;
            }
        }

        public void SetRotation(Vector3 dir)
        {
            Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
        private void Update()
        {
            // if (canRotate)
            // {
            //     SetRotation(target.transform.forward);
            // }
        }


    }
}

