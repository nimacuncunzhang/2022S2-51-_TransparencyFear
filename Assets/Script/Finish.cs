using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour 
{
	public Texture2D txtWin;
	public Texture2D txtLost;
	GameObject player;	
	PlayerController playerControl;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");	
		playerControl = player.GetComponent<PlayerController>();	
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		
		if  (GameObject.Find("Diamond") == null)
		{
			Finished = true;
		}
		if (Input.GetButtonDown("Jump")&&IsNext)
		{
			IsNext = false;
			int index = Application.loadedLevel;
			if(index == 6)
			{
				index = 0;
				Application.LoadLevel(index);
			}
			else
			{
                Application.LoadLevel(++index);
            }
        }
		if (Input.GetButtonDown("Jump") && playerControl.IsAlive == false)
		{
			playerControl.gameObject.transform.position = new Vector3(-7.44f, -2.75f, -0.01f);
			playerControl.IsAlive = true;
			playerControl.dieAnimPlayed = false;
			playerControl.velocity = Vector3.zero;
		}
	}
	
	bool Finished = false;
	bool IsNext = false;
	
	void OnGUI()
	{
		if (IsNext)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - txtWin.width/2, Screen.height/2 - txtWin.height/2, txtWin.width, txtWin.height), txtWin, ScaleMode.ScaleToFit, true, 0);
		}
		if (playerControl.IsAlive == false)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - txtWin.width/2, Screen.height/2 - txtWin.height/2, txtWin.width, txtWin.height), txtLost, ScaleMode.ScaleToFit, true, 0);
		}
	}
	
	bool IsPlayed = false;
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Finished)
		{
			IsNext = true;
			PlayerController playerScript = player.GetComponent<PlayerController>();
			playerScript.IsFinished = true;
			
			if (!GetComponent<AudioSource>().isPlaying && !IsPlayed)
			{
				GetComponent<AudioSource>().Play();
				IsPlayed = true;
			}
		}
	}
}
