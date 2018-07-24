using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class Basket : MonoBehaviour {

	
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
	{
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -GameObject.Find("Main Camera").transform.position.z;
        mousePos2D.z = 10;
        //注意此时要想使用Camera.main 需要将Main camera的tag设为MainCamera
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
        //scoreText.text = "Score: " + score.ToString();
    }

    void OnCollisionEnter(Collision coll) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}
		ApplePicker.score += 100;
        Text scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Score: " + ApplePicker.score.ToString();
        if (ApplePicker.score > HighScore.highScore)
        {
            HighScore.highScore = ApplePicker.score;
        }
    }
}
