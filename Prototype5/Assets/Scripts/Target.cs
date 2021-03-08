using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(12,16), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10,10), Random.Range(-10,10), Random.Range(-10,10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4), -1);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void c() 
    {
        if(gameManager.GameStatus()) {
            Destroy(gameObject);
            Instantiate(particle, transform.position, particle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad")) {
            gameManager.GameOver();
            gameManager.EndGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
