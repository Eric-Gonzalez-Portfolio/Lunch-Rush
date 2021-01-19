using UnityEngine;
using System.Collections;

public class DoorControlRandom : MonoBehaviour
{

	[HideInInspector] public GameObject door;

    //public GameObject player;

    //public GameObject toggle;

    public float randomNum;

    public float doorTransTime;

    public bool doorIsOpen;

    public Collider2D doorOpenRandomizer;

    // Use this for initialization
    void Start()
    {
        //doorOpenRandomizer = GetComponent<>
        //doorOpenRandomizer.isTrigger = true;
        doorIsOpen = false;
        randomNum = Random.Range(0, 10);
        doorTransTime = 0;

		door = gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        randomNum = Random.Range(0, 10);

        /*if (randomNum > 0)
        {
            randomNum -= Time.deltaTime;
        }*/

        if (randomNum > Random.Range(0, 200) && doorIsOpen == false && doorTransTime <= 0)
        {
            door.GetComponent<BoxCollider2D>().isTrigger = false;
            door.GetComponent<CircleCollider2D>().isTrigger = false;
            //toggle.GetComponent<SpriteRenderer>().enabled = true;

            //GetComponent<Animator>().GetCurrentAnimatorStateInfo().IsName("");
            GetComponent<Animator>().SetBool("closeDoor", false);
            door.GetComponent<Animator>().SetTrigger("openDoor");

            doorIsOpen = true;
            doorTransTime = 2;
        }

        if (randomNum > Random.Range(0, 200) && doorIsOpen == true && doorTransTime <= 0)
        {
            door.GetComponent<BoxCollider2D>().isTrigger = true;
            door.GetComponent<CircleCollider2D>().isTrigger = true;
            //toggle.GetComponent<SpriteRenderer>().enabled = false;

            GetComponent<Animator>().SetBool("openDoor", false);
            door.GetComponent<Animator>().SetTrigger("closeDoor");

            doorIsOpen = false;
            doorTransTime = 2;
        }

        if (doorTransTime > 0)
        {
            doorTransTime -= Time.deltaTime;
        }

    }

    /*void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(randomNum < Random.Range(0, 15))
            {
                door.GetComponent<BoxCollider2D>().isTrigger = false;
                door.GetComponent<CircleCollider2D>().isTrigger = false;
                toggle.GetComponent<SpriteRenderer>().enabled = true;
                door.GetComponent<Animator>().SetTrigger("openDoor");
            }
            //door.GetComponent<BoxCollider2D>().enabled = true;
        }

    }*/
}
