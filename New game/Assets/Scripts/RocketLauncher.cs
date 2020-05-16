using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class RocketLauncher : MonoBehaviour  
{
    public bool playerControlled = true;                                        // Is this rocket launcher controlled by the player? 
    public float fireInterval = 3.0f;                                           // How many seconds between shots? 

    private float fireTimer = 0;                                                // Keep track of when we can fire again 

    public GameObject rocketPrefab;                                             // Reference to Rocket prefab so we spawn it 
    public GameObject spawnPoint;                                               // Reference to the rocket spawn point
    public Vector3 spawnOffset;                                                 // A position offset for where the rocket is spawned so we dont spawn inside the gun 
    


    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireInterval;                                               // When the game starts we are ready to shoot
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;                                            // Advance the timer 

            if (fireTimer >= fireInterval)                                      // Have we waited long enough to shoot? 
        {
            if (playerControlled && Input.GetButtonDown ("Fire1"))              // Rocket is player controlled adn fire button pressed 
            {
                Fire();                                                         // Fire a rocket 
            }
        }
    }

    public void Fire() 
    {
        Instantiate(rocketPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation); 

        fireTimer = 0;                                                           // Reset fire timer 
    }


}
