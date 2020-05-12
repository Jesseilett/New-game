using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIScore : MonoBehaviour
{
    public Text _scoreLabel = null;
    private int _score = 0;

    public int GetScore()
    {
        return _score; 
    }
    public void AddScore(int value)
    {
        _score += value;
        _scoreLabel.text = _score.ToString(); 
    }
}

   

