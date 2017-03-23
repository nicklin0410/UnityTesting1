using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

	public float bulletSpeed = 10f;
	public float lifeTime;



	void OnEnable ()
	{
		
		Invoke ("Destroy", lifeTime);
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
		Destroy ();

	}




	void Destroy ()
	{
		gameObject.SetActive (false);
	}

	void OnDisable ()
	{
		CancelInvoke ();
	}
}
