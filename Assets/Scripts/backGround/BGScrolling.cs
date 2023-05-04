using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float speed;
    private Material mater;
    private Vector2 offet = Vector2.zero;
    void Awake()
    {
        mater = GetComponent<Renderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        offet = mater.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offet.y += speed * Time.deltaTime;
        mater.SetTextureOffset("_MainTex",offet);
    }
}
