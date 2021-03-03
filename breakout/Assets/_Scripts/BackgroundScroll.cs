using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=32EIYs6Z18Q
public class BackgroundScroll : MonoBehaviour
{
    public float bgSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
}
