using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var uimObj = UIM.obj;
            uimObj.goldCount++;
            UIM.obj.scoreText.text = "" + uimObj.goldCount;

            //for playing sound
            collision.gameObject.GetComponent<Player>().coinASource.Play();

            Vector3 pos = new Vector3(collision.gameObject.transform.localPosition.x,
                collision.gameObject.transform.localPosition.y - -0.9005f,
                collision.gameObject.transform.localPosition.z);
            Instantiate(GameManager.obj.collectedEffect, pos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
