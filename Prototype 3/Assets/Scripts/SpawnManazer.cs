﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManazer : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    void Start()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
