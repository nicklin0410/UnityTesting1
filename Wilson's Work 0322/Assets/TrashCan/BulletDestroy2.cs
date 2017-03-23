using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy2 : MonoBehaviour
{
	public float lifeTime;
	// Use this for initialization
	//Rigidbody rb;

	void Start ()
	{
		//rb = GetComponent<Rigidbody> ();
	}

	void OnEnable ()
	{
		Invoke ("Destroy", lifeTime);
	}

	void Destroy ()
	{
		gameObject.SetActive (false);
		//rb.velocity = Vector3.zero;
		//rb.angularVelocity = Vector3.zero; 
	}

	void OnDisable ()
	{
		CancelInvoke ();
	}
}
