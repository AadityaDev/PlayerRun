using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    private float xMin = -19f;
    private float xMax = 19.9f;
    private float zMin = 8.7f;
    private float zMax = 46f;
    public GameObject boundary;
    public float tilt;
    public float dodge;
    public float smoothing;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;

    private float currentSpeed;
    private float targetManeuver;

    public float speed;

    public float accelerationTime =2f;
    public float maxSpeed = 1f;
    private Vector3 movement;
    private float timeLeft;
    private GameObject player;

    void Start()
    {
        //currentSpeed = GetComponent<Rigidbody>().velocity.z*10000;
        //StartCoroutine(Evade());
        player = GameObject.FindWithTag("Player"); 
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            float xDiff = player.transform.position.x - GetComponent<Rigidbody>().position.x;
            float zDiff = player.transform.position.z - GetComponent<Rigidbody>().position.z;
            if(xDiff == 2f || zDiff == 2f  ){
                movement = new Vector3(Random.Range(xDiff, xMax), 0.27f, Random.Range(zDiff, zMax));
            }else{
                movement = new Vector3(Random.Range(xMin, xMax), 0.27f, Random.Range(zMin, zMax));
            }
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(movement * maxSpeed);
    }
}
