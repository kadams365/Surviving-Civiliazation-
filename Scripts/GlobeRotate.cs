﻿using UnityEngine;

public class GlobeRotate : MonoBehaviour
{

    public float speed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
