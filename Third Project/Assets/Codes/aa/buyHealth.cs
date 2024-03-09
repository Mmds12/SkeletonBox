using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyHealth : MonoBehaviour
{
    private bool isPlayer = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer)
        {
            PlayerDeath.playerHP = 100;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayer = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayer = false;
    }
}
