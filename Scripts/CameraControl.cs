using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour
{

    public float x_offset;

    List<GameObject> players;

    // Use this for initialization
    void Start()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        Vector2 cam_start = AvgPosition(players);
        transform.position = new Vector3(cam_start.x, cam_start.y, -1.0f);      //set initial position for the camera
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cam_move = AvgPosition(players);
        transform.position = new Vector3(cam_move.x, cam_move.y, FindZoom(players));
    }

    // Helper function, takes list of game objects and returns average of all positions
    Vector2 AvgPosition(List<GameObject> A)
    {
        Vector2 sum = new Vector2(0.0f, 0.0f);
        for (int i = 0; i < A.Count; i++)
        {
            sum += new Vector2(((GameObject)A[i]).transform.position.x, ((GameObject)A[i]).transform.position.y);
        }
        return sum / A.Count;
    }

    float FindZoom(List<GameObject> A)
    {
        float curr_dist = 0.0f;
        float max_dist = 0.0f;
        for (int i = 0; i < A.Count; i++)
        {
            for (int j = 0; j < A.Count; j++)
            {
                if (i != j)
                {
                    curr_dist = Distance((GameObject)A[i], (GameObject)A[j]);
                    if (curr_dist > max_dist)
                        max_dist = curr_dist;
                }
            }
        }
        return Mathf.Clamp(-1.9f * max_dist, -200.0f, -40.0f);
    }

    //helper function that finds the 2d distance between two gameobjects
    float Distance(GameObject a, GameObject b)
    {
        float avg_x = (a.transform.position.x - b.transform.position.x) / 2;
        float avg_y = (a.transform.position.y - b.transform.position.y) / 2;
        return (Mathf.Pow(Mathf.Pow(avg_x, 2) + Mathf.Pow(avg_y, 2), 0.5f));
    }
}