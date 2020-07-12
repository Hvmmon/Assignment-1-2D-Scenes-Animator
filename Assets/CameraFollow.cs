﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        // Store current camera's position with variable temp
        Vector3 temp = transform.position;

        // Set camera's position equal to player's position
        temp.x = playerTransform.position.x;

        transform.position = temp;

    }
}
