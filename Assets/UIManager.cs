using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text _score;
    private int _currentScore;
    void Start()
    {
        _currentScore = 0;
    }
    public void Score(int price)
    {
        _currentScore += price;
        _score.text = "Score: " + _currentScore;
    }
}
