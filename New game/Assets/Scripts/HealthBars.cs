using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine; 

public class HealthBars : MonoBehaviour
{
    public float m_StartingHealth = 100f;

    public float m_CurrentHealth; 
    public bool m_Dead; 

    public m_gm; 

    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI(); 
    }

    private void SetHealthUI()
    {

    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        SetHealthUI();

        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath(); 
        }
    }

    private void OnDeath()
    {
        m_Dead = true;

        gameObject.SetActive(false); 
    }

    private void Start()
    {
        gm = GameObject.FindGameObjectsWithTag("GameController").GetComponent<GameManager>(); 
    }
}
