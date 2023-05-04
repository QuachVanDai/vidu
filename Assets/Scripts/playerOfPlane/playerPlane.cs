using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class playerPlane : MonoBehaviour
{
    public Rigidbody2D mybody;
    public static playerPlane instance;
    public float speed,checkSpeed;
    public AudioSource AudioSource;
    public AudioClip shootClip, dieClip;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    public GameObject Plane;
    private bool canshoot = true;
    public Slider SliderHealth;
    public float maxHealth, currentHelth;
    Animator myAni;

    // Start is called before the first frame update
    private void Start()
    {
       
        SliderHealth.maxValue = maxHealth;
        SliderHealth.value = currentHelth;
        myAni = GetComponent<Animator>();
    }
    void Awake()
    {
        MakeInstances();
        mybody = GetComponent<Rigidbody2D>();
       
    }
    void MakeInstances()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void planMove()
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * speed;
        float yAxis = Input.GetAxisRaw("Vertical") * speed;
        myAni.SetFloat("checkspeed", xAxis);
        Debug.Log(xAxis);
        mybody.velocity = new Vector2(xAxis, yAxis);

    }
     void Update()
    {
            if (canshoot == true) StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        planMove();
    }
    IEnumerator Shoot()
    {
        AudioSource.PlayOneShot(shootClip);
        canshoot = false;
        Vector3 tem = transform.position;
        tem.y += 0.6f;
        Instantiate(Bullet, tem, Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        canshoot = true;
    }
}
