using System.Linq;
using TMPro;
using UnityEngine;

public class BuyWeapon : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject weapon;
    public WeaponSwithcing weaponSwithcing;
    public TextMeshProUGUI textMeshPro;

    private bool inRange = false;
    private int cost;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if(Enemy.money >= cost)
            {
                Shooting.isPistol = false;
                changeWeapon();
                buyTheWeapon();
                Enemy.money -= cost;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name.Contains("AK47"))
        {
            cost = 2000;
        }
        if (gameObject.name.Contains("B44"))
        {
            cost = 1500;
        }
        if (gameObject.name.Contains("Sniper"))
        {
            cost = 1800;
        }
        if (gameObject.name.Contains("Smg"))
        {
            cost = 1200;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            textMeshPro.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            textMeshPro.gameObject.SetActive(false);
        }
    }

    void changeWeapon()
    {
        foreach(Transform weaponTransform in cameraTransform)
        {
            weaponTransform.gameObject.SetActive(false);
        }
        weapon.SetActive(true);
        weaponSwithcing.haveWeapon = true;
        int i = 0;
        foreach(Transform wn in weaponSwithcing.transform)
        {
            if (wn.name.Equals(weapon.name))
            {
                weaponSwithcing.weaponNum = i;
                weaponSwithcing.selectedWeapon = i;
            }
            i++;
        }
    }

    void buyTheWeapon()
    {
        Shooting[] weapons = weaponSwithcing.shooting;
        Shooting w;

        if (weaponSwithcing.weaponNum == 0)
        {
            w = weapons.ElementAt(0);
            w.magazine = 30f;
            w.fullMagazine = 90f;
            w.currentAmmo = w.magazine;
            w.CurrentAmmoText.text = w.currentAmmo.ToString();
            w.MaxAmmoText.text = w.fullMagazine.ToString();
        }

        else if (weaponSwithcing.weaponNum == 1)
        {
            w = weapons.ElementAt(1);
            w.magazine = 12f;
            w.fullMagazine = 24f;
            w.currentAmmo = w.magazine;
            w.CurrentAmmoText.text = w.currentAmmo.ToString();
            w.MaxAmmoText.text = w.fullMagazine.ToString();
        }

        else if (weaponSwithcing.weaponNum == 2)
        {
            w = weapons.ElementAt(2);
            w.magazine = 30f;
            w.fullMagazine = 90f;
            w.currentAmmo = w.magazine;
            w.CurrentAmmoText.text = w.currentAmmo.ToString();
            w.MaxAmmoText.text = w.fullMagazine.ToString();
        }

        else if (weaponSwithcing.weaponNum == 3)
        {
            w = weapons.ElementAt(3);
            w.magazine = 6f;
            w.fullMagazine = 18f;
            w.currentAmmo = w.magazine;
            w.CurrentAmmoText.text = w.currentAmmo.ToString();
            w.MaxAmmoText.text = w.fullMagazine.ToString();
        }

        else if (weaponSwithcing.weaponNum == 4)
        {
            w = weapons.ElementAt(4);
            w.magazine = 30f;
            w.fullMagazine = 90f;
            w.currentAmmo = w.magazine;
            w.CurrentAmmoText.text = w.currentAmmo.ToString();
            w.MaxAmmoText.text = w.fullMagazine.ToString();
        }
    }
}