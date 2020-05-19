using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // The time in seconds before the shell is removed 
    public float m_MaxLifeTime = 1f;
    // The amount of damage done if the explosion is centred on a tank 
    public float m_MaxDamage = 34f;
    // The maximum distance away from the explosion tanks can be and are still affected 
    public float m_ExplosionRadius = 5;
    // The amount of force added to a tank at the centre of the explosion 
    public float m_ExplosionForce = 100f;

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();

        if (targetRigidbody != null)
        {
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            HealthBars targetHealth = targetRigidbody.GetComponent<HealthBars>();

            if (targetHealth != null)
            {
                float damage = CalculateDamage(targetRigidbody.position);

                targetHealth.TakeDamage(damage);

                Destroy(gameObject);

            }
        }
    }
            private float CalculateDamage(Vector3 targetPosition)
            {
                Vector3 explosionToTarget = targetPosition - transform.position;
                float explosionDistance = explosionToTarget.magnitude;
                float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
                float damage = relativeDistance * m_MaxDamage;
                damage = Mathf.Max(0f, damage);

                return damage; 
            }

        
    
}


