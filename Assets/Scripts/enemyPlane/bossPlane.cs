using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class bossPlane : MonoBehaviour
{
    public static bossPlane instance;
    public float speed ,hp;
    public float time;
    bool kt = true, canshoot;
    private Rigidbody2D mybody;
    [SerializeField]
    private GameObject BulletBoss;
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void FixedUpdate()
    {
        if (transform.position.y <= 6 )
        {
            
            if (time > 1f && kt==true)
            {
                time = 0;
                mybody.velocity = new Vector2(Random.Range(-speed,speed), Random.Range(0, speed));
                 StartCoroutine(Shoot());
            }
            if(transform.position.x < -6)
            {
                mybody.velocity = new Vector2(+speed, 0);
                kt = false;
            }
           else if (transform.position.x > 6 )
            {
                mybody.velocity = new Vector2(-speed, 0);
                kt=false;
            }
            else
            {
                kt = true;
                time += Time.deltaTime;
            }
        }
        else if (transform.position.y <= 0)
        {
            mybody.velocity = new Vector2(0, speed);
        }
        else
        {
            mybody.velocity = new Vector2(0f, -speed);
        }
       /* mybody.velocity = new Vector2(x,y);*/
    }
    IEnumerator Shoot()
    {
        Vector3 tem = transform.position;
        tem.y += 0.6f;
        Instantiate(BulletBoss, tem, Quaternion.identity);
        yield return new WaitForSeconds(0);
    }

}
