using System.Collections;
using UnityEngine;

public class ScoreOnClick : MonoBehaviour
{
    public GUIScore _score = null;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            _score.AddScore(1); 
        }
    }
}
