using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float gravity;
	public float moveSpeed;
	public float jumpSpeed;
	
	bool changeDirection = false;
	
	public Material runMaterial;
	public Material dieMaterial;
	public Material idleMaterial;
	public Material jumpMaterial;
	public Material celebrateMaterial;
	
	public AudioClip soundJump;
	public AudioClip soundDie;
	public float soundRate;
	public float soundDelay;
	
	public Vector3 velocity = Vector3.zero;
	private bool jumpEnable = false;
//	private float afterHitForceDown = 1.0f;
	private CharacterController controller;
	AniSprite aniplay;
	
	void PlaySound(AudioClip soundName,float soundDelay)
	{
		if (!GetComponent<AudioSource>().isPlaying && Time.time > soundDelay)
		{
			soundRate = Time.time + soundDelay;
						
			GetComponent<AudioSource>().clip = soundName;
			GetComponent<AudioSource>().Play();
		}
	}

	// Use this for initialization
	void Start () 
	{
		aniplay = GetComponent("AniSprite") as AniSprite;
		controller = GetComponent<CharacterController>();
	}
	
	public bool IsFinished = false;
	public bool IsAlive = true;
	public bool dieAnimPlayed = false;
	static int watiForFrames = 50;
	
	
	// Update is called once per frame
	void Update () 
	{
		if (IsAlive && controller.isGrounded && !IsFinished)	
		{
			velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0);			
			
			jumpEnable = false;
			
			if (velocity.x == 0)
			{
				transform.GetComponent<Renderer>().material = idleMaterial;
				aniplay.aniSprite(1, 1, true);
			}
			
			if (velocity.x < 0)			
			{
				transform.GetComponent<Renderer>().material = runMaterial;
				aniplay.aniSprite(10, 10, true);
				
				velocity *= moveSpeed;
			}
			
			if (velocity.x > 0)			
			{
				transform.GetComponent<Renderer>().material = runMaterial;
				aniplay.aniSprite(10, 10, false);
				
				velocity *= moveSpeed;
			}
			
			if (Input.GetButtonDown("Jump"))
			{
				velocity.y = jumpSpeed;
				PlaySound(soundJump, 0);
				jumpEnable = true;
			}
		}
		
		if (IsAlive && !controller.isGrounded && !IsFinished)
		{
			velocity.x = Input.GetAxis("Horizontal");
			
			if (changeDirection == false)
			{
				if (jumpEnable)
				{
					velocity.x *= moveSpeed;
					transform.GetComponent<Renderer>().material = jumpMaterial;
					aniplay.aniSprite(11, 11, true);
				}
			}
			
			if (changeDirection == true)
			{
				if (jumpEnable)
				{
					velocity.x *= moveSpeed;
					transform.GetComponent<Renderer>().material = jumpMaterial;
					aniplay.aniSprite(11, 11, false);
				}
			}
		}
		
		if (IsFinished)
		{
			if (changeDirection == false)
			{
				transform.GetComponent<Renderer>().material = celebrateMaterial;
				aniplay.aniSprite(11, 11, true);
			}
			
			if (changeDirection == true)
			{
				transform.GetComponent<Renderer>().material = celebrateMaterial;
				aniplay.aniSprite(11, 11, false);
			}
			velocity.x = 0;
		}
		
		if (!IsAlive)
		{			
			if (dieAnimPlayed == false)			
			{
				transform.GetComponent<Renderer>().material = dieMaterial;
				PlaySound(soundDie,0);
				
				if (changeDirection == false)
				{
					aniplay.aniSprite(12, 12, true);
				}
				else
				{
					aniplay.aniSprite(12, 12, false);
				}
				
				watiForFrames --;
				if (watiForFrames == 0)
				{
					dieAnimPlayed = true;	
					watiForFrames = 50;
				}			
			}
			velocity.x = 0;
		}
		
		if (velocity.x < 0)
			changeDirection = false;
		
		if (velocity.x > 0)
			changeDirection = true;
		
		velocity.y -= gravity*Time.deltaTime;
		controller.Move(velocity*Time.deltaTime);
	}
	
}
