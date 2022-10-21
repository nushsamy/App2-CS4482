using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWall : MonoBehaviour
{
    private GameObject obstacleWall;

    // Start is called before the first frame update
    void Start()
    {
        obstacleWall = GameObject.FindGameObjectWithTag("BlockedWall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            obstacleWall.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            obstacleWall.SetActive(true);
        }
    }
}
