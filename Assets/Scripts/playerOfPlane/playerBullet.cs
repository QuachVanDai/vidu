using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    public static playerBullet instance;
    public float speed;
    private Rigidbody2D mybody;
    public float dame=5;
    public  AudioSource AudioSource;
    public  AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
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
    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(0f,speed);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "enemyfly")
        {
            smallPlane.instance.hp -= dame;
            if (smallPlane.instance.hp <=0f)
            {
                Destroy(target.gameObject);
            }
            Destroy(gameObject);
        }
        if (target.tag == "bossPlane")
        {
            bossPlane.instance.hp -= dame;
           
            if (bossPlane.instance.hp <= 0f)
            {
                AudioSource.PlayOneShot(audioClip);
                Score.score1 += 5;
                UiManager.instancen.scoreUi.text = Score.score1.ToString();
                Destroy(target.gameObject);
                Spawner.instance.StartCoroutine(Spawner.instance.SpownerEnemy());
                
            }
            Destroy(gameObject);
        }
        if (target.tag == "Bordertop")
        {
            Destroy(gameObject);

        }
    }
}
