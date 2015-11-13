using UnityEngine;
using System.Collections;

public class ShadowFax : MonoBehaviour {

	//public GameObject player;


	void Update ()
	{
		
	}
	
	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.GetComponent<Renderer>().material.color.a;
		
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = transform.GetComponent<Renderer>().material.color;
			newColor.a = Mathf.Lerp(alpha,aValue,t);
			transform.GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			StartCoroutine(FadeTo(0.0f, 1.0f));
		}
	}
}


