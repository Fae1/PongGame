using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hitInfo) {
		if(hitInfo.name == "Ball")
        {
            string wallName = transform.name;//Por que é utilizado transform? É um método de qual objeto? Seria o wall?
            GetComponent<AudioSource>().Play();
            new GameManager().Score(wallName);//It`s shows an error relative to word "new"
            hitInfo.gameObject.SendMessage("ResetBall");
        }
	}
}
