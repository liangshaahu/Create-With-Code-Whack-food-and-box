using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explorsion;

    private Rigidbody targetRb;
    private GameManager gameManagerSC;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float rangePosX = 4f;
    private float rangePosY = -2f;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPos();
        gameManagerSC = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-rangePosX, rangePosX), rangePosY);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManagerSC.UpdateScore(pointValue);
        Instantiate(explorsion, transform.position, transform.rotation);
        if (gameObject.CompareTag("Bad"))
        {
            gameManagerSC.gameOverText.gameObject.SetActive(true);
            gameManagerSC.scoreText.gameObject.SetActive(false);
            gameManagerSC.gameOver = true;
            gameManagerSC.restartButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
       
    }


}
