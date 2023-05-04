using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instancen;
    public float speed;
    private Rigidbody2D mybody;
    public AudioSource AudioSource;
    public AudioClip dieClip;
    public bool kt ;
    public float hp;
    public float dame = 5;
    public static int score1 = 0;
    void Awake()
    {
        MakeInstances();
        mybody = GetComponent<Rigidbody2D>();
        kt = true;
        UiManager.instancen.bestScore.text = PlayerPrefs.GetInt("bestScore", 0).ToString();
    }
    void MakeInstances()
    {
        if (instancen == null)
        {
            instancen = this;
        }
    }
    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "die")
        {
            hp -= dame;
            if (hp <=0 && kt==true)
            {
                kt= false;
                AudioSource.PlayOneShot(dieClip);
                score1++;
                UiManager.instancen.scoreUi.text = score1.ToString();
                int bestScore = PlayerPrefs.GetInt("bestScore", 0);
                if (bestScore < score1)
                {
                    bestScore = score1;
                    PlayerPrefs.SetInt("bestScore", bestScore);
                }
                UiManager.instancen.bestScore.text = bestScore.ToString();
            }
        }
    }
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(0f, -speed);
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
    
}
