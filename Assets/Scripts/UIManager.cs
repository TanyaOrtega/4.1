using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TMP_Text currentScoreText;
    public TMP_Text bestScoreText;


    void Update()
    {
        currentScoreText.text = "Score: " + GameManager.singleton.currentScore;

        bestScoreText.text = "Best: " + GameManager.singleton.bestScore;
        
    }
}
