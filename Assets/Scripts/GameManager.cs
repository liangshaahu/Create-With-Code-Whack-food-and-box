using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool gameOver;
    public Button restartButton;
    public GameObject titleScreen;

    private float spawnRate = 1.0f;
    private int score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
            
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficultyRate)
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        spawnRate /= difficultyRate;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        gameOver = false;
        restartButton.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
    }
}
