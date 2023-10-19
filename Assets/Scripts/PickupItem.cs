using UnityEngine;
using UnityEngine.UIElements;

public class PickupItem : MonoBehaviour
{
    private Transform pickupPoint;
    private Transform player;

    public float pickupDistance;
    public float forceMulti;

    public bool readyToThrow;
    public bool itemIsPicked;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerCharacter").transform;
        pickupPoint = GameObject.Find("PickupPoint").transform;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && itemIsPicked && readyToThrow)
        {
            forceMulti += 300 * Time.deltaTime;
        }

        pickupDistance = Vector3.Distance(player.position, transform.position);

        if (pickupDistance < 5)
        {
            if (Input.GetKeyDown(KeyCode.E) && itemIsPicked == false && pickupPoint.childCount < 1)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Collider>().enabled = false;
                this.transform.position = pickupPoint.position;
                this.transform.parent = pickupPoint;
                itemIsPicked = true;
                forceMulti = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && itemIsPicked == true)
        {
            readyToThrow = true;

            if (forceMulti > 10)
            {
                rb.AddForce(player.transform.forward * forceMulti);
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                itemIsPicked = false;

                readyToThrow = false;
            }
            forceMulti = 0;
        }
    }
}