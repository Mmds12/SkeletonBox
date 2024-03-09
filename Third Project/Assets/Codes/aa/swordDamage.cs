using UnityEngine;

public class swordDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            PlayerDeath.takeDamage(10);
    }
}
