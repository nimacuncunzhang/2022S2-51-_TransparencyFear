using UnityEngine;
using System.Collections;

public class AniSprite : MonoBehaviour
{
	private Vector2 size;
	private Vector2 offset;
	public void aniSprite(int columSize, int framePerSecond, bool MoveDirection)
	{
		int index = (int)(Time.time * framePerSecond);
		index%=columSize;
		
		if (MoveDirection)
		{
			size = new Vector2(1.0f/columSize, 1);
			offset = new Vector2(index * size.x, 0);
		}
		
		else
		{
			size = new Vector2(-1.0f/columSize, 1);
			offset = new Vector2(-index * size.x, 0);
		}
		
		GetComponent<Renderer>().material.mainTextureScale = size;
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
