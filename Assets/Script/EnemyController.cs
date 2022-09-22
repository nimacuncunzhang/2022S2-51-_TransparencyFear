using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float left;
	public float right;
	public float moveSpeed;
	private CharacterController enemyController;
	public float gravity;
	
	AniSprite aniplay;
	
	private Vector3 velocity = Vector3.zero;
	

	// Use this for initialization
	void Start ()
	{
		enemyController = GetComponent<CharacterController>();
		aniplay = GetComponent("AniSprite") as AniSprite;
	}
	
	public enum Direction
    {
		goleft,
		goright		
    }
	
	// Update is called once per frame
	public Direction d1 = Direction.goleft;
	void Update () 
	{
		GameObject obj = GameObject.FindWithTag("Player");
		PlayerController playerControl = obj.GetComponent<PlayerController>();
		if (enemyController.isGrounded && playerControl.IsAlive == true )
		{
			if (transform.position.x < left)
			{
				d1 = Direction.goright;
			}
			
			if (transform.position.x > right)
			{
				d1 = Direction.goleft;
			}
			
			switch (d1)
			{
			case Direction.goleft:		
				
				velocity = new Vector3(-1, 0, 0);
				aniplay.aniSprite(10, 10, true);			
				velocity *= moveSpeed;
				break;
			case Direction.goright:				
				velocity = new Vector3(1, 0, 0);
				aniplay.aniSprite(10, 10, false);
				velocity *= moveSpeed;
				break;
			}					
		}
		else
		{
			velocity.x = 0;		
		}
		velocity.y -= gravity*Time.deltaTime;
		enemyController.Move(velocity*Time.deltaTime);
	}	
}
