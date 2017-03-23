using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlTest : MonoBehaviour
{
	Animator ani;
	TurretFire turretFire;
	public float fireDelay = 0.5f;
	public float fireRate = 2f;
	public string bulletTag = null;
	// Give bullet prefab a tag and type in the name of tag on inspecter
	// Use this for initialization
	void Start ()
	{
		ani = GetComponent <Animator> ();
		turretFire = GetComponentInChildren <TurretFire> ();
		turretFire.fireDelay = fireDelay;
		turretFire.fireRate = fireRate;
		turretFire.bulletTag = bulletTag;
		//fireDelay = turretFire.fireDelay;
		//fireRate = turretFire.fireRate;
		//bulletTag = turretFire.bulletTag;

	}



	void AttactTest ()
	{
		ani.SetTrigger ("Melee Attack");
		turretFire.Fire ();
	}





	void Update ()
	{
		if (Input.GetKeyDown ("space")) {
			Debug.Log ("space key pressed");
			AttactTest ();
		}
	}
}
