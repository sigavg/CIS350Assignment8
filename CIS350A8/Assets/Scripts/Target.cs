/* Luke Lesimple
 * Prototype 5
 * Spawns Objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gameMan;

    public int pointValue;

    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);

        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        gameMan = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(- maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameMan.gameActive)
        {
            gameMan.UpdateScore(pointValue);

            Instantiate(explosion, transform.position, explosion.transform.rotation);

            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameMan.GameOver();
        }
    }


}
