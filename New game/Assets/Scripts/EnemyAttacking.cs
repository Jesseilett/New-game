using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public float enemyDamage = 10f;
    public float enemyDamageOverTime = 0.01f;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthBars>().m_CurrentHealth -= enemyDamage;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthBars>().m_CurrentHealth -= enemyDamageOverTime; 
        }

    }

}





