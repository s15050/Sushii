﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsControl : MonoBehaviour
{
    public GameObject stunStars;
    public Sprite starsOne, starsTwo;
    private float timeElapsed = 0.0f;
    private static bool stunned;
    public float stun_duration = 10f;
    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("DUPA1");
        if (!stunned)
        {
            Debug.Log("DUPA2");
            NormalControl();
            stunStars.GetComponent<SpriteRenderer>().enabled = false;
        }
        else {

            Debug.Log("DUPA3");
            transform.rotation = Quaternion.Euler(0, 0, -120f);

            timeElapsed += Time.deltaTime;
            Debug.Log(timeElapsed);
            stunStars.GetComponent<SpriteRenderer>().enabled = true;
            stunStars.GetComponent<SpriteRenderer>().sprite = starsOne;
            stunStars.GetComponent<SpriteRenderer>().sprite = starsTwo;
        }
        
            
        if (timeElapsed > stun_duration)
            {
                stunned = false;
                timeElapsed = 0.0f;
            }
    }

    public void NormalControl() {
        float left = Input.GetAxis("Horizontal"); //Dodatnie - lewo, Ujemne - prawo
        float up = Input.GetAxis("Vertical"); //Dodatnie - góra, Ujemne - dół
        if (left > 0.3)
        {
            if (up > 0.5)
                this.transform.rotation = Quaternion.Euler(0, 0, -55f);
            else if (up < -0.3)
                this.transform.rotation = Quaternion.Euler(0, 0, -120f);
            else
                transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
        else if (left < -0.3)
        {
            if (up > 0.3)
                transform.rotation = Quaternion.Euler(0, 0, 55f);
            else if (up < -0.3)
                transform.rotation = Quaternion.Euler(0, 0, 120f);
            else
                transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else transform.rotation = Quaternion.Euler(0, 0, -20f);
    }
    public static void Stun() {
        stunned = true;
    }
}
