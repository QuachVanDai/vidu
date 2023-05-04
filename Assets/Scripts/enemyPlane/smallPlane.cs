using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallPlane : MonoBehaviour
{
    public float speed;
    private Rigidbody2D mybody;
    [SerializeField]
    private GameObject Bullet;
    public float dame = 20;
    public float hp;
    public static smallPlane instance;
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
    private void Start()
    {
        StartCoroutine(EnmyShoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity =  new Vector2(0f,-speed);
    }
    IEnumerator EnmyShoot()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,1f));
        Vector3 tem = transform.position;
        tem.y -= 0.5f;
        Instantiate(Bullet, tem, Quaternion.identity);
        StartCoroutine(EnmyShoot());
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        
        if (target.tag == "Player")
        {
            playerPlane.instance.AudioSource.PlayOneShot(playerPlane.instance.dieClip);
            playerPlane.instance.currentHelth -= dame;
            playerPlane.instance.SliderHealth.value = playerPlane.instance.currentHelth;
            if (playerPlane.instance.currentHelth <= 0f)
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
