using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ 
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.5f,1,0.5f,1,0.5f,1);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 25f) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameManager.obj.gameOver = true;
        }
    }

}
