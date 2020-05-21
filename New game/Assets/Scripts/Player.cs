using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Player : MonoBehaviour
{
    public float PlayerHealth = 100f;
    public GameManager gm;
    public GameObject healthUI; 
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.GetComponent<Text>().text = "Health:" + PlayerHealth; 
        
            if (PlayerHealth <= 0) 
            {
                gm.LoseGame; 
            }


       
    }
}
