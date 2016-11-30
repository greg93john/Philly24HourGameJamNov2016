using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    // public variables
    public float standardVelocity;

    // private variables
    private int currentSize;
    private Rigidbody2D rb;
    private Vector3 ballToPlayerVector;
    private GameObject player;
    

	// Use this for initialization
	void Start () {
        InitializePrivateVariables();
        rb.AddForce(new Vector2(Random.Range(-5f, 5f), -standardVelocity));
	}
	
	// Update is called once per frame
	void Update () {
           
	}

    public int GetSizeOfThisObject() {
        return currentSize;
    }

    public void UpdateRegisteredSizeOfObject() {
        currentSize = (int)transform.localScale.x;
    }

    void InitializePrivateVariables () {
        // initialize holding boolian
        rb = GetComponent<Rigidbody2D>();
        currentSize = (int)transform.localScale.x;
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    public void LaunchBall(float yDirection) {
        Debug.Log("Launcing ball off player");
        rb.AddForce(new Vector2(Random.Range(-50f, 50f), standardVelocity * yDirection));
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == player && transform.localScale.x < 3f) {
            LaunchBall(2f);
        } else if (collision.gameObject == player && transform.localScale.x >= 3f) {
            PlayerController playerScript = player.GetComponent<PlayerController>();
            playerScript.PlayerIsCrushed();
            LaunchBall(-2f);
        }
    }
}
