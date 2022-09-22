using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	public Texture2D textureYouWin;
	
	private float myTime = 0;
	private bool IsNext = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	void OnGUI()
	{
		if (IsNext)
		{
			GUI.DrawTexture(new Rect(Screen.width/2-textureYouWin.width/2,
									 Screen.height/2-textureYouWin.height/2,
									 textureYouWin.width,
									 textureYouWin.height),textureYouWin,ScaleMode.ScaleToFit,true,0);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
		myTime += Time.deltaTime;
		
		if (myTime>=5)
			{ IsNext = true; }
		
		if (Input.GetButton("Jump")&&IsNext)
		{
			IsNext = false;
			int index = Application.loadedLevel;
			
			Application.LoadLevel(++index%3);
		}
	}
}
