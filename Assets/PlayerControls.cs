using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    private Rigidbody2D rigi;
    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10;

    private void Awake()//Qual o nome desta técnica? Porque foi necesssária?
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKey(moveUp))
        {
            rigi.velocity = new Vector3(0, speed, 0);
        }
        else if (Input.GetKey(moveDown))
        {
            rigi.velocity = new Vector3(0, speed *-1, 0);
        }
        else
        {
            rigi.velocity = new Vector3(0, 0, 0);
        }

        //rigi.velocity = new Vector3(0, 0, 0);

    }
}
