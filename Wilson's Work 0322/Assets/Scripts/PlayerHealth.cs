using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public static bool playerisDead;
	Animator anim;

	//BoxCollider boxCollider;



	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
		UIManager.UpdateScore (currentHealth);
		playerisDead = false;
	}




	public void TakeDamage (int amount)
	{
		// If the enemy is dead...
		if (playerisDead)
				// ... no need to take damage so exit the function.
				return;
			
		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;
		UIManager.UpdateScore (currentHealth);
		// If the current health is less than or equal to zero...
		if (currentHealth <= 0) {
			// ... the enemy is dead.
			Death ();

		}

	}

	void Death ()
	{
		if (playerisDead) {
			return;
		}

		// The enemy is dead.
		playerisDead = true;

		// Turn the collider into a trigger so shots can pass through it.
		//boxCollider.isTrigger = true;

		// Tell the animator that the enemy is dead.
		//anim.SetTrigger ("Dead");


		GameObject obj = ObjectPooler.SharedInstance.GetPooledObject ("Boom");

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);

		this.gameObject.SetActive (false);


	}



}