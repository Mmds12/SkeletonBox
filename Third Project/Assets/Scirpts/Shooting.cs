using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    KeyCode leftMouseButton = KeyCode.Mouse0;
    KeyCode rightMouseButton = KeyCode.Mouse1;

    public TextMeshProUGUI CurrentAmmoText;
    public TextMeshProUGUI MaxAmmoText;
    public TextMeshProUGUI theSlash;

    public GameObject bulletObject;
    public Transform bulletSpawn;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    public BuyGrenade BuyGrenade;

    public int shootingCooldown = 40;
    public int bulletSpeed = 4400;
    private int counter = 0;

    public float magazine = 30f;
    public float fullMagazine = 90f;
    public float currentAmmo;
    public float reloadingTime = 1f;
    private float tempAmmo;

    public bool emptyMagazine = false;
    public bool isReloading = false;
    public static bool isPistol = false;



    void Start()
    {
        if (!BuyGrenade.isGrenade)
        {
            currentAmmo = magazine;
            CurrentAmmoText.text = magazine.ToString();
        }
    }
    void Update()
    {
        if(isPistol)
        {
            CurrentAmmoText.enabled = false;
            MaxAmmoText.enabled = false;
            theSlash.fontSize = 55;
            theSlash.text = "\u221E";
        }
        else
        {
            CurrentAmmoText.enabled = true;
            MaxAmmoText.enabled = true;
            theSlash.fontSize = 36;
            theSlash.text = "/";
        }

        if (!BuyGrenade.isGrenade && !isPistol)
        {

            if (isReloading)
                return;

            if ((currentAmmo == 0 || Input.GetKey("r") && currentAmmo != magazine) && emptyMagazine == false && !GameManager.isPaused)
            {
                StartCoroutine(Reload());

                tempAmmo = magazine - currentAmmo;
                if (tempAmmo >= fullMagazine)
                {
                    currentAmmo += fullMagazine;
                    fullMagazine = 0;
                    emptyMagazine = true;
                    MaxAmmoText.text = fullMagazine.ToString();
                    CurrentAmmoText.text = currentAmmo.ToString();
                }
                else if (fullMagazine != 0)
                {
                    fullMagazine -= tempAmmo;
                    currentAmmo = magazine;
                    MaxAmmoText.text = fullMagazine.ToString();
                    CurrentAmmoText.text = currentAmmo.ToString();
                }

                return;
            }

            if (Input.GetKey(leftMouseButton) && counter >= shootingCooldown && !GameManager.isPaused)
            {
                if (currentAmmo > 0 && fullMagazine >= 0)
                {
                    currentAmmo--;
                    CurrentAmmoText.text = currentAmmo.ToString();
                    Shoot();
                    animator.SetBool("isShooted", true);
                    counter = 0;
                }
            }
            else
                animator.SetBool("isShooted", false);

        }

        if (counter > 200000)
            counter = 0;

        counter++;

        if(Input.GetKey(leftMouseButton) && counter >= shootingCooldown && isPistol && !GameManager.isPaused)
        {
            Shoot();
            animator.SetBool("isShooted", true);
            counter = 0;
        }
        else 
            animator.SetBool("isShooted", false);

        if (Input.GetKeyDown(rightMouseButton))
            animator.SetBool("isAiming", true);

        else if (Input.GetKeyUp(rightMouseButton))
            animator.SetBool("isAiming", false);

    }

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadingTime - .25f);

        currentAmmo = magazine;

        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        isReloading = false;
    }
    
    void Shoot()
    {
        muzzleFlash.Play();

        GameObject bullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        Destroy(bullet, 2);
    }
}
