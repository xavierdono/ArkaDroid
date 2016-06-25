﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	// Movement Speed
	public float speed = 100.0f;

	void Start ()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
	}

	float hitFactor (Vector2 ballPos, Vector2 racketPos,
	                float racketWidth)
	{
		// ascii art:
		//
		// 1  -0.5  0  0.5   1  <- x value
		// ===================  <- racket
		//
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		// Hit the Racket?
		if (col.gameObject.name == "racket") {
			// Calculate hit Factor
			float x = hitFactor (transform.position,
				         col.transform.position,
				         col.collider.bounds.size.x);

			// Calculate direction, set length to 1
			Vector2 dir = new Vector2 (x, 1).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}
	}
}
