using System.Linq;
using TMPro;
using UnityEngine;

public class BuyAmmo : MonoBehaviour
{
    private bool inRange = false;
    public WeaponSwithcing weaponSwitching;
    public Shooting[] Shooting;
    public TextMeshProUGUI textMeshPro;
    

    // AK, Pistol, B44, Sniper, Smg
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && inRange && Enemy.money >= 200)
        {
            refullAmmo();
            Enemy.money -= 200;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
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

    void refullAmmo()
    {
        int s = weaponSwitching.selectedWeapon;
        Shooting weapon = Shooting[s];

        if (s == 0 || s == 2 || s == 4)
        {
            weapon.fullMagazine = 90f;
            weapon.MaxAmmoText.text = weapon.fullMagazine.ToString();
        }
        else if (s == 1)
        {
            weapon.fullMagazine = 24f;
            weapon.MaxAmmoText.text = 24f.ToString();
        }
        else if(s == 3)
        {
            weapon.fullMagazine = 18;
            weapon.MaxAmmoText.text = 18f.ToString();
        }
        weapon.emptyMagazine = false;
    }
}