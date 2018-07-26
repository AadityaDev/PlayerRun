using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int enemiesCount;
    //private List<GameObject> enemies;
    public GameObject enemy;
    private Vector3 pos;

	void Start () {
        for (int i = 0; i < enemiesCount;i++){
            pos = new Vector3(Random.RandomRange(-7.3f, 16.5f), 0.27f, Random.RandomRange(7.9f, 46f));
            Instantiate(enemy,pos,Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
