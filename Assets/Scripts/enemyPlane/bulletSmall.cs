using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSmall : MonoBehaviour
{
    public float speed;
    private Rigidbody2D mybody;
    public float dame = 10;
    // Start is called before the first frame update
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(0f,-speed);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
       if (target.tag == "Player")
        {
            playerPlane.instance.AudioSource.PlayOneShot(playerPlane.instance.dieClip);
            playerPlane.instance.SliderHealth.value = playerPlane.instance.currentHelth;
            playerPlane.instance.currentHelth -= dame;
            if(playerPlane.instance.currentHelth <= 0f)
            {
                GamePlayController.instance.planeDieShowPanel();
            }
            Destroy(gameObject);
        }
            if (target.tag == "Borderbottom")
        {
            Destroy(gameObject);
        }
    }
}
