using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior_withAim : MonoBehaviour
{

	public float bulletSpeed = 10f;
	public float lifeTime;

	GameObject target;




	void OnEnable ()
	{
		if (!PlayerHealth.playerisDead) {
			target = GameObject.FindGameObjectWithTag ("Player");
			transform.LookAt (target.transform);
			Invoke ("Destroy", lifeTime);
		}

	}


	void Update ()
	{
		transform.position += transform.forward * bulletSpeed * Time.deltaTime;
	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("On Trigger Enter");

		if (other.tag == "Player") {
			PlayerHealth ph = other.GetComponent <PlayerHealth> ();
			ph.TakeDamage (20);
		}

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
