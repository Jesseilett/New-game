using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class MutantMovement : MonoBehaviour
{
    public float m_CloseDistance = 3f;             // The mutant will stop moving towards the player once it  it reaches the distance 

    private GameObject m_Player;                   // A reference to the Player gameobject 
    private NavMeshAgent m_NavAgent; 
    private Rigidbody m_RigidBody;

    private bool m_Follow;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player"); 
        m_NavAgent = GetComponent<NavMeshAgent>(); 
        m_RigidBody = GetComponent<Rigidbody>(); 
        m_Follow = false; 
    }

    private void OnEnable()
    {
        m_RigidBody.isKinematic = false; 
    }

    private void OnDisable()
    {
        m_RigidBody.isKinematic = true; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            m_Follow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            m_Follow = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody.isKinematic = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Follow == false) return; 

        float distance = (m_Player.transform.position - transform.position).magnitude; 

        if (distance > m_CloseDistance)
        {
            m_NavAgent.SetDestination(m_Player.transform.position);
            m_NavAgent.isStopped = false; 
        }
        else
        {
            m_NavAgent.isStopped = true; 
        }
    }
}
