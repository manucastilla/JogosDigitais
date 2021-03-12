﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=zit45k6CUMk
public class Parallax : MonoBehaviour
{
    private float length, starpos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        starpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(starpos + dist, transform.position.y, transform.position.y);

        if (temp > starpos + length / 2)
        {
            starpos += length;
        }
        else if (temp < starpos - length / 2)
        {
            starpos -= length;
        }
    }
}
