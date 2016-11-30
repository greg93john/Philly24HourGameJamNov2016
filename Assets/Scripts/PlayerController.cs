using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    // public variables
    public float movementSpeed, playEdgePadding;

    //private variables
    private float currentMovementInput, xMin, xMax;
    private bool facingRight, inPlay;
    private Vector3 moveDirection, theScale;
    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        InitializePrivateVariables();
	}

    // Update is called once per frame
    void Update() {
        currentMovementInput = 0f;

        if (inPlay) {
            currentMovementInput = (Input.GetAxis("Horizontal") * movementSpeed);
            MovePlayer(currentMovementInput);
        }

        HandleAnimations(currentMovementInput, inPlay);
    }



    public void PlayerHasLost() {
        inPlay = false;
        myAnimator.SetBool("PlayState", inPlay);
    }

    public void PlayerIsCrushed() {
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
        levelManager.LoadNextLevelDelay(4f);
        Destroy(gameObject);
        Debug.Log("You got crushed! Damn!");
    }

    public void GoToGameOverScreen() {
        Debug.Log("Going to GameOverScreen");
        LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
        levelManager.LoadNextLevelDelay(2f);
    }

    void MovePlayer (float horInput) {
        moveDirection.x = horInput * Time.deltaTime;

        if (moveDirection.x < 0 && facingRight) {
            FlipCharacterScale();
        } else if(moveDirection.x > 0 && !facingRight) {
            FlipCharacterScale();
        }

        transform.Translate(moveDirection);

        float xNew = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xNew, transform.position.y, transform.position.z);
    }

    void FlipCharacterScale() {
        facingRight = !facingRight;

        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void HandleAnimations (float horInput, bool playState) {
        myAnimator.SetFloat("HorSpeed", Mathf.Abs(horInput));
    }

    // private variable initializer
    void InitializePrivateVariables () {
        currentMovementInput = 0f;
        facingRight = true;
        inPlay = true;
        myAnimator = GetComponent<Animator>();
        moveDirection = new Vector3(0, 0, 0);
        theScale = transform.localScale;

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,(transform.position.z - Camera.main.transform.position.z)));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, (transform.position.z - Camera.main.transform.position.z)));
        xMin = leftMost.x + playEdgePadding;
        xMax = rightMost.x - playEdgePadding;
    }
}