using System.Collections;
using System.Linq;
using UnityEngine;

public class WeaponSwithcing : MonoBehaviour
{
    public int selectedWeapon = 1;
    public bool haveWeapon = false;
    public int weaponNum;

    public Shooting[] shooting;

    private bool getPistol = false;
    private bool callOnceForPistol = true;

    void Start()
    {
        switchWeapon();
        Shooting.isPistol = true;
    }

    void Update()
    {

        if (shooting.ElementAt(weaponNum).isReloading == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && haveWeapon)
            {
                selectedWeapon = weaponNum;
                getPistol = true;
                Shooting.isPistol = false;
                switchWeapon();
                shooting.ElementAt(selectedWeapon).theSlash.fontSize = 36;
                shooting.ElementAt(selectedWeapon).theSlash.text = "/";
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && !haveWeapon)
            {
                selectedWeapon = 10;
                Shooting.isPistol = false;
                shooting.ElementAt(weaponNum).theSlash.enabled = false;
                shooting.ElementAt(weaponNum).CurrentAmmoText.enabled = false;
                shooting.ElementAt(weaponNum).MaxAmmoText.enabled = false;
                switchWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || callOnceForPistol)
            {
                getPistol = true;
                Shooting.isPistol = true;
                callOnceForPistol = false;

                selectedWeapon = 1;
                switchWeapon();
                shooting.ElementAt(selectedWeapon).theSlash.fontSize = 55;
                shooting.ElementAt(selectedWeapon).theSlash.text = "\u221E";
            }
        }
    }
    public void switchWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon && getPistol)
            {
                weapon.gameObject.SetActive(true);
                getPistol = false;
                shooting.ElementAt(selectedWeapon).MaxAmmoText.text = shooting.ElementAt(selectedWeapon).fullMagazine.ToString();
                shooting.ElementAt(selectedWeapon).CurrentAmmoText.text = shooting.ElementAt(selectedWeapon).currentAmmo.ToString();
            }

            else if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }

            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
