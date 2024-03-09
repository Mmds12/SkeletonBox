using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenade;
    public BuyGrenade BuyGrenade;

    public float thrwoForce = 20f;

    void Update()
    {

        if (BuyGrenade.isGrenade && BuyGrenade.hasGrenade)
        {

            if (Input.GetMouseButtonDown(0) && BuyGrenade.isGrenade && BuyGrenade.hasGrenade)
            {
                throwGrenade();
                BuyGrenade.current = 0;
                if (BuyGrenade.max > 0)
                {
                    BuyGrenade.current = 1;
                    BuyGrenade.max--;
                }
            }
            BuyGrenade.currentAmmo.text = BuyGrenade.current.ToString();
            BuyGrenade.maxAmmo.text = BuyGrenade.max.ToString();

        }
    }

    void throwGrenade()
    {
        GameObject grenade1 = Instantiate(grenade, transform.position, transform.rotation);
        Rigidbody rb = grenade1.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrwoForce, ForceMode.VelocityChange);
    }
}
