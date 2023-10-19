using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField]
    GameObject shootingItem;



    void Start()
    {

    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     updateItem();
        // }
    }

    void updateItem()
    {
        var item = Instantiate(shootingItem);
        item.transform.forward = transform.forward;
    }
}

