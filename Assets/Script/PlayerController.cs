using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.MovePlayer += OnMove;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(Vector3 dir)
    {
        print("working boy");
    }
}
