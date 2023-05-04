using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var worldHeight = Camera.main.orthographicSize * 2f;
        var worldWidth = worldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(worldWidth, worldHeight, 0f);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
