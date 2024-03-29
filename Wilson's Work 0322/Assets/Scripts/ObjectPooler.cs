﻿/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
	public GameObject objectToPool;
	public int amountToPool;
	public bool canExpand;
}

public class ObjectPooler : MonoBehaviour
{


	public static ObjectPooler SharedInstance;
	public List<GameObject> pooledObjects;
	public List<ObjectPoolItem> itemsToPool;



	void Awake ()
	{
		SharedInstance = this;
	}
	// Use this for initialization
	void Start ()
	{
		pooledObjects = new List<GameObject> ();
		foreach (ObjectPoolItem item in itemsToPool) {
			for (int i = 0; i < item.amountToPool; i++) {
				GameObject obj = (GameObject)Instantiate (item.objectToPool);
				obj.SetActive (false);
				pooledObjects.Add (obj);
			}
		}
	}

	public GameObject GetPooledObject (string tag)
	{
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy && pooledObjects [i].tag == tag) {
				return pooledObjects [i];
			}
		}
		foreach (ObjectPoolItem item in itemsToPool) {
			if (item.objectToPool.tag == tag) {
				if (item.canExpand) {
					GameObject obj = (GameObject)Instantiate (item.objectToPool);
					obj.SetActive (false);
					pooledObjects.Add (obj);
					return obj;
				}
			}
		}
		return null;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
*/


using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
	public GameObject objectToPool;
	public string poolName;
	public int amountToPool;
	public bool shouldExpand = true;
}

public class ObjectPooler : MonoBehaviour
{
	public const string DefaultRootObjectPoolName = "Pooled Objects";

	public static ObjectPooler SharedInstance;
	public string rootPoolName = DefaultRootObjectPoolName;
	public List<GameObject> pooledObjects;
	public List<ObjectPoolItem> itemsToPool;

	void Awake ()
	{
		SharedInstance = this;
	}

	private void Start ()
	{
		if (string.IsNullOrEmpty (rootPoolName))
			rootPoolName = DefaultRootObjectPoolName;

		GetParentPoolObject (rootPoolName);

		pooledObjects = new List<GameObject> ();
		foreach (var item in itemsToPool) {
			for (int i = 0; i < item.amountToPool; i++) {
				CreatePooledObject (item);
			}
		}
	}

	private GameObject GetParentPoolObject (string objectPoolName)
	{
		// Use the root object pool name if no name was specified
		if (string.IsNullOrEmpty (objectPoolName))
			objectPoolName = rootPoolName;

		GameObject parentObject = GameObject.Find (objectPoolName);

		// Create the parent object if necessary
		if (parentObject == null) {
			parentObject = new GameObject ();
			parentObject.name = objectPoolName;

			// Add sub pools to the root object pool if necessary
			if (objectPoolName != rootPoolName)
				parentObject.transform.parent = GameObject.Find (rootPoolName).transform;
		}

		return parentObject;
	}

	public GameObject GetPooledObject (string tag)
	{
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy && pooledObjects [i].tag == tag) {
				return pooledObjects [i];
			}
		}
		foreach (ObjectPoolItem item in itemsToPool) {
			if (item.objectToPool.tag == tag) {
				if (item.shouldExpand) {
					
					return CreatePooledObject (item);
				}
			}
		}
		return null;
	}

	private GameObject CreatePooledObject (ObjectPoolItem item)
	{
		GameObject obj = Instantiate<GameObject> (item.objectToPool);

		// Get the parent for this pooled object and assign the new object to it
		var parentPoolObject = GetParentPoolObject (item.poolName);
		obj.transform.parent = parentPoolObject.transform;

		obj.SetActive (false);
		pooledObjects.Add (obj);
		return obj;
	}
}