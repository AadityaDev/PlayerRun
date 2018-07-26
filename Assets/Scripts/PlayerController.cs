using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody player;
	// Use this for initialization

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public bool endGame = false; 

	void Start () {
        player = GetComponent<Rigidbody>();

        latestDirectionChangeTime = 0f;
	}

	private void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //player.AddForce(movement*speed);
        if(Input.GetKey(KeyCode.W)){
            player.transform.position += Vector3.up * speed *Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * speed * Time.deltaTime;

        }
	}

	// Update is called once per frame
	void Update () {
        ////if the changeTime was reached, calculate a new movement vector
        //if (Time.time - latestDirectionChangeTime > directionChangeTime)
        //{
        //    latestDirectionChangeTime = Time.time;
        //    calcuateNewMovementVector();
        //}

        ////move enemy: 
        //transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        //transform.position.y + (movementPerSecond.y * Time.deltaTime));
	}

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag.Equals("Player")){
            endGame = true;
        }
	}

}
