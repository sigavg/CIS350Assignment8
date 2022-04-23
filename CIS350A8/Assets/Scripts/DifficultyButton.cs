/* Luke Lesimple
 * Prototype 5
 * controls difficulty selection
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;

    private GameManager gameMan;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(SetDifficulty);

        gameMan = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");

        gameMan.StartGame(difficulty);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
