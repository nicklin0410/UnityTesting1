using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
	public float fireDelay = 0;
	public float fireRate = 0;
	public string bulletTag;
	// Give bullet prefab a tag and type in the name of tag on inspecter








	void _Fire ()
	{

		GameObject obj = ObjectPooler.SharedInstance.GetPooledObject (bulletTag);

		if (obj == null)
			return;
		
		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
				

	}

	public void FireRepeating ()
	{
		InvokeRepeating ("_Fire", fireDelay, fireRate);

	}

	public void Fire ()
	{
		Invoke ("_Fire", fireDelay);

	}
}
