/* Luke Lesimple
 * Prototype 5
 * Game manager
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objs;

    private float SpawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = "Score:\n" + score;
    }

    IEnumerator SpawnTarget()
    {
        while(true)
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
