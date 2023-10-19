using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingItem : MonoBehaviour
{

    [SerializeField]
    float force = 300;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force);
        print(transform.forward * force);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
