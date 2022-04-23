/* Luke Lesimple
 * Prototype 5
 * Game manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objs;

    private float SpawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI gameOverText;

    public bool gameActive;

    public Button restartButton;

    public GameObject titleScreen;

    public void StartGame(int difficulty)
    {
        SpawnRate /= difficulty;
        gameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = "Score:\n" + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameActive = false;
    }

    IEnumerator SpawnTarget()
    {
        while(gameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, objs.Count);
            Instantiate(objs[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
