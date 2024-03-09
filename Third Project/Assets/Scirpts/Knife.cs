using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public TextMeshProUGUI currentAmmo;
    public TextMeshProUGUI maxAmmo;
    public TextMeshProUGUI slash;
    public Animator animator;

    public bool isKnife = false;


    KeyCode leftMouseButton = KeyCode.Mouse0;

    void Update()
    {
        // ************ EQUIP THE KNIFE ***********
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponsOff();
            currentAmmo.gameObject.SetActive(false);
            maxAmmo.gameObject.SetActive(false);
            slash.text = "\u221E";
            isKnife = true;
        }

        // ************ equip another weapon *****************
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentAmmo.gameObject.SetActive(true);
            maxAmmo.gameObject.SetActive(true);
            slash.text = "/";
            isKnife = false;
        }

        // ****** shoot with knife **********
        if (Input.GetKeyDown(leftMouseButton) && isKnife)
        {
            StartCoroutine(playAnimation());
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && isKnife)
        {
            StartCoroutine(playAnimation2());
        }

    }

    IEnumerator playAnimation()
    {
        animator.SetBool("firstAnim", true);
        yield return new WaitForSeconds(.37f);
        animator.SetBool("firstAnim", false);
    }

    IEnumerator playAnimation2()
    {
        animator.SetBool("secondAnim", true);
        yield return new WaitForSeconds(1.71f);
        animator.SetBool("secondAnim", false);
    }

    // *********** take off the weapons ************
    void weaponsOff()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
            i++;
        }
        transform.GetChild(6).gameObject.SetActive(true);
    }

}
