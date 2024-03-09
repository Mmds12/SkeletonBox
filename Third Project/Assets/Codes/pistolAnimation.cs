using System.Collections;
using UnityEngine;

public class pistolAnimation : MonoBehaviour
{
    public Animator animator;

    private bool isPistol = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            isPistol = true;
        }

        if (isPistol && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(playAnimation());
        }
    }

    IEnumerator playAnimation()
    {
        animator.SetBool("isPistol2", true);
        yield return new WaitForSeconds(3.7f);
        animator.SetBool("isPistol2", false);
    }
}
