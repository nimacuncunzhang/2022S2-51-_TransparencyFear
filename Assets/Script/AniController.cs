using UnityEngine;
using System.Collections;

public class AniController : MonoBehaviour
{
	AniSprite aniPlay;	
	public Material runMaterial;
	public Material idleMaterial;
	public Material dieMaterial;
	public Material celeMaterial;
	public Material jumpMaterial;
	
	// Use this for initialization
	void Start () 
	{
		aniPlay = GetComponent("AniSprite") as AniSprite;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis("Horizontal") < 0)
		{
			GetComponent<Renderer>().material = runMaterial;
			aniPlay.aniSprite(10,10,true);
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			GetComponent<Renderer>().material = runMaterial;
			aniPlay.aniSprite(10,10,false);
		}
		else if (Input.GetAxis("Vertical") < 0)
		{
			GetComponent<Renderer>().material = dieMaterial;
			aniPlay.aniSprite(12,12,false);
		}
		else if (Input.GetAxis("Vertical") > 0)
		{
			GetComponent<Renderer>().material = celeMaterial;
			aniPlay.aniSprite(11,11,false);
		}
		else if (Input.GetButton("Jump"))
		{
			GetComponent<Renderer>().material = jumpMaterial;
			aniPlay.aniSprite(11,11,false);
		}
		else
		{
			GetComponent<Renderer>().material = idleMaterial;
			aniPlay.aniSprite(1,1,true);
		}
	}
}
