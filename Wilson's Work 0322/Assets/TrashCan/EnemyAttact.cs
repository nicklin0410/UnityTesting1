using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttact	: MonoBehaviour
{

	public float fireDalay = .02f;
	public int bulletType = 1;
	string bulletTypeInput;

	// Use this for initialization
	void Start ()
	{
		
		bulletTypeInput = "bulletType" + bulletType.ToString ();
	}


	public void Attact ()
	{
		Invoke ("Fire", fireDalay);
	}
	// Update is called once per frame
	void Fire ()
	{
		GameObject obj = ObjectPooler.SharedInstance.GetPooledObject (bulletTypeInput);

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);


	}


}
