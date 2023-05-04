using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyScore : MonoBehaviour
{
    public float speed=4;
    private Rigidbody2D mybody;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
