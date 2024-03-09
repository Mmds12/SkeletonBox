using TMPro;
using UnityEngine;

public class BuyGrenade : MonoBehaviour
{
    public Transform weapons;
    public TextMeshProUGUI currentAmmo;
    public TextMeshProUGUI maxAmmo;
    public TextMeshProUGUI textMeshPro;

    public float current = 1f;
    public float max = 0f;
    public bool isGrenade = false;
    public bool hasGrenade = false;


    private int limit = 6;
    private bool inRange = false;


    void Update()
    {

        if (current == 0 && max <= 0)
        {
            hasGrenade = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isGrenade = true;
            weaponsOff();
            weapons.GetChild(5).gameObject.SetActive(true);
        }

        if (isGrenade)
        {

            if (current == 0 && max > 0)
            {
                current++;
                max--;
            }

            if (Input.GetKeyDown(KeyCode.E) && inRange && Enemy.money >= 200)
            {
                Enemy.money -= 200;

                hasGrenade = true;

                if (current == 0)
                {
                    max++;
                }

                if (max < limit && current != 0)
                {
                    max++;
                }

                currentAmmo.text = current.ToString();
                maxAmmo.text = max.ToString();

            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            isGrenade = false;
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

    void weaponsOff()
    {
        int i = 0;
        foreach (Transform weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
