using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

    public GameObject door;

    public GameObject player;

    public GameObject toggle;

    public float randomNum;

    public Collider2D doorOpenRandomizer;

	// Use this for initialization
	void Start () {
        //doorOpenRandomizer = GetComponent<>
        //doorOpenRandomizer.isTrigger = true;

    }
	
	// Update is called once per frame
	void Update () {
        randomNum = Random.Range(0, 10);
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(randomNum < Random.Range(0, 15))
            {
                door.GetComponent<BoxCollider2D>().isTrigger = false;
                door.GetComponent<CircleCollider2D>().isTrigger = false;
                toggle.GetComponent<SpriteRenderer>().enabled = true;
            }
            //door.GetComponent<BoxCollider2D>().enabled = true;
        }

    }
}
