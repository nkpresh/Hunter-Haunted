using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        float ZAxis = Input.GetAxis("Vertical");
        float XAxis = Input.GetAxis("Horizontal");

        if (ZAxis > 0 && XAxis > 0)
        {
            Vector3 MovementDir = new Vector3(XAxis, 0, ZAxis);
        }
    }
}
