using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class UIManager : MonoBehaviour
{
	public static Text HealthText;

	// Use this for initialization
	void Awake ()
	{
		HealthText = GetComponent<Text> ();

	}



	public static void UpdateScore (int currenHealth)
	{
		HealthText.text = "Health:" + currenHealth;
	}

}
