using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustIncrease : MonoBehaviour
{
    public GameController gameController;
    public Rigidbody2D player;

    private Rigidbody2D pointer;

    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = player.velocity.magnitude;

        if (velocity > 0)
        {

            float max = gameController.HeatThreshold;


            float percent = player.velocity.magnitude / max;

            percent = Math.Min(percent, 1);

            float grade = percent * 90;

            pointer.rotation = grade;
        }
        else
        {
            if (pointer.rotation > 0)
            {
                pointer.rotation -= 1;
            }
            else
            {
                pointer.rotation = 0;
            }
        }
    }
}
