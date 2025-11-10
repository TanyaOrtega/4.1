using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int bestScore;
    public int currentScore;

    public int currentLevel = 0;
    //modificación para volver al Menú
    public int totalLevels = 3;

    public static GameManager singleton;



    void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            //Agregado para el Menú de vuelta
            DontDestroyOnLoad(gameObject);
        }

        else if (singleton !=this)
        {
            Destroy(gameObject);
          
        }

        bestScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void NextLevel()
    {
        currentLevel++;
        //Agregado
        if (currentLevel >= totalLevels)
        {
            Debug.Log("Todos los niveles completados, Volviendo al menú...");
            ReturnToMenu();
        }
        else
        {
            FindObjectOfType<BallController>().ResetBall();
            FindObjectOfType<HelixController>().LoadStage(currentLevel);
            Debug.Log("Pasamos de nivel");
        }
    }

    public void Restartlevel()
    {
        Debug.Log("Restart");
        singleton.currentScore = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentLevel);
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        if (currentScore>bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore",currentScore);
        }
    }

    //Agregado
    public void ReturnToMenu()
    {
        currentLevel = 0;
        currentScore = 0;

        SceneManager.LoadScene("MainMenu");
    }


   
}
