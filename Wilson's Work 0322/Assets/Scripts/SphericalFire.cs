using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalFire : MonoBehaviour
{

	public float fireTime;
	public float radius = 0.5f;
	Transform RandomSphericalTrans;
	public string bulletTag = null;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("Fire", fireTime, fireTime);
		Debug.Log ("sFire Start");
	}


	/*Transform GenarateRandomSphericalPoint (int pointCount)
	{

		Transform trans = new Transform ();
		float x;
		float y;
		float z;

		x = Random.Range (0.0f, 360.0f);
		y = Random.Range (0.0f, 360.0f);
		z = Random.Range (0.0f, 360.0f);

		trans.localEulerAngles = new Vector3 (x, y, z);
		trans.localPosition = Quaternion.Euler (x, y, z) * Vector3.forward * 0.5f;
		return trans;

	}*/






	// Update is called once per frame
	void Fire ()
	{
		/*GameObject obj = GeneralObjectPooling.current.GetPooledObject ();

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);*/
		RandomShpericalFire (200);
		Debug.Log ("sFire Fire");

	}


	void RandomShpericalFire (int pointCount)
	{
		Debug.Log ("sFire sFire" + bulletTag);

		for (int i = 0; i < pointCount; i++) {
			GameObject obj = ObjectPooler.SharedInstance.GetPooledObject (bulletTag);

			if (obj == null) {
				Debug.Log ("pooled object is null");
				return;
			}

			float x;
			float y;
			float z;

			x = Random.Range (0.0f, 360.0f);
			y = Random.Range (0.0f, 360.0f);
			z = Random.Range (0.0f, 360.0f);




			obj.transform.localEulerAngles = new Vector3 (x, y, z);
			obj.transform.localPosition = transform.position + Quaternion.Euler (x, y, z) * Vector3.forward * radius;
			obj.SetActive (true);
		}
	}

}
