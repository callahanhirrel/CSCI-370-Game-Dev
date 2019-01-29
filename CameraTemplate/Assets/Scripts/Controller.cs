using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private float speed;
    private bool start;
    private int points;
    public TextMesh textPoints;
    public TextMesh textTime;
    public float timeRemaining = 15f;

    void GameOver()
    {
        start = false;
        transform.position = new Vector3(-0.2f, 0.82f, -51.79f);
    }

    // Use this for initialization
    void Start () {
        speed = 8;
        start = false;
        points = 70;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            start = true;
        }

        if (start)
        {
            timeRemaining -= Time.deltaTime;
            textTime.text = "Time: " + timeRemaining.ToString();

            if (timeRemaining > 0)
            {
                transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f,
                            Input.GetAxis("Vertical") * Time.deltaTime * speed);
                // Input.GetAxis directly mapped to arrow keys and WASD
            }
            else
            {
                GameOver();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "cubes")
        {
            points -= 10;
            Destroy(collision.gameObject);
            textPoints.text = "Points: " + points.ToString();
            if (points <= 0)
            {
                GameOver();
            }
        } else if (collision.collider.name == "Wall3")
        {
            Win();
        }
    }

    void Win()
    {

    }
}
