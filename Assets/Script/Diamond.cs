using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour 
{
	public AudioClip audioClpGet;
	
	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		SinMove();	
	}
	
	//make a noise
	void PlaySound()
	{
		GetComponent<AudioSource>().clip = audioClpGet;
		GetComponent<AudioSource>().Play();
		new WaitForSeconds(5);
	}

	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			PlaySound();
            Destroy(gameObject.GetComponent<Renderer>());
			Destroy(gameObject.GetComponent<Collider>());
			Destroy(gameObject,audioClpGet.length);
		}
	}
	
	
	public float MoveRange;
	public float MoveSpeed;
	// Sin move
	void SinMove()
	{
		float yOffset = Mathf.Sin(Time.time*MoveSpeed)*MoveRange/100;
		transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
	}
	
}
