﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiCommander : MonoBehaviour
{
    private float timeElapsed;

    public float interval = 1000f;
    public Transform sushiPrefab;
    public Transform trackUL;
    public Transform trackLL;
    public Transform trackUR;
    public Transform trackLR;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > interval)
        {
            var newSushi = Instantiate(sushiPrefab);
            Sushi nS = newSushi.GetComponent<Sushi>();
            nS.isInstance = true;
            nS.trackUL = trackUL;
            nS.trackLL = trackLL;
            nS.trackLR = trackLR;
            nS.trackUR = trackUR;

            timeElapsed = 0;
        }

    }
}
