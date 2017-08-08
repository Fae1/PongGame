using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
    private Rigidbody2D rigi;
    public float ballSpeed = 100;
    
    private void Awake()// Porque foi necesssário?
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    private IEnumerator Start () {
        yield return new WaitForSeconds(2);
        GoBall();
        //Invoke("GoBall",2); Yield simplificado, estudar em outra oportunidade
    }

    private void Update()
    {
        Vector2 vec2D = rigi.velocity;
        float xVel = vec2D.x;
        if(xVel < 16 && xVel> -18 && xVel !=0)
        {
            if(xVel > 0)
            {
                vec2D.x = 20;
            }else
            {
                vec2D.x = -20;
            }
            //Debug.Log("Velocity Before " + xVel);
            //Debug.Log("Velocity After " + vec2D.x);
        }
        rigi.velocity = vec2D;
    }

    private void GoBall()
    {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= 0.5)
        {
            rigi.AddForce(new Vector2(ballSpeed, 10));
        }
        else
        {
            rigi.AddForce(new Vector2(-1 * ballSpeed, -10));
        }
    }
    //Use this for reset ball
    private IEnumerator ResetBall()
    {
        Vector2 vec2D = rigi.velocity;
        vec2D.y = 0;
        vec2D.x = 0;
        rigi.velocity = vec2D;
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector2(0, 0);
        GoBall();
    }
    //Use this like an bumped object identifier
    public void OnCollisionEnter2D (Collision2D colInfo) {
        if (colInfo.collider.tag == "Player")
        {
            Vector2 velY = rigi.velocity;
            Debug.Log("Local RigidBody Y vel: " + velY.y + "\nColliderInfo relativeVelocity: " + colInfo.rigidbody.velocity.y);//Rigidbody x rigidbody2d?
            velY.y = velY.y/2 + colInfo.rigidbody.velocity.y/2;
            rigi.velocity= velY;
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);/*Why? Awser: Pitch serves to change the sound tone*/
            GetComponent<AudioSource>().Play();
            /*Vector3 velY = rigi.velocity;????
            Debug.Log("Local RigidBody Y vel: " + velY.y + "\nColliderInfo relativeVelocity: " + colInfo.collider.attachedRigidbody.velocity.y);
            velY.y = velY.y/2 + colInfo.collider.attachedRigidbody.velocity.y/3;
            rigi.velocity= velY;*/
        }
    }
}
