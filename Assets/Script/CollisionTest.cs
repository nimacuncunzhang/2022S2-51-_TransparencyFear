using UnityEngine;
using System.Collections;

public class CollisionTest : MonoBehaviour 
{	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (needTest )
//		{
//			GameObject []objs = GameObject.FindGameObjectsWithTag("Enemy");
//			foreach (GameObject obj in objs)
//			{
//				EnemyController controller = obj.GetComponent<EnemyController>();
//				if (controller.d1 == EnemyController.Direction.goleft)
//				{
//					controller.d1 = EnemyController.Direction.goright;
//				}
//				else
//				{
//					controller.d1 = EnemyController.Direction.goleft;
//				}
//			}
//			needTest = false;
//		}		
//		waitFrames --;
//		if (waitFrames == 0)
//		{
//			needTest = true;
//			waitFrames = 100;
//		}
	
	}
	
//	int waitFrames = 10;
//	bool needTest = true;
	
	void OnTriggerEnter(Collider Info)
	{
		if (Info.tag == "Player")
		{
			GameObject obj = GameObject.FindWithTag("Player");
			PlayerController controller = obj.GetComponent<PlayerController>();
			controller.IsAlive = false;
		}
	}
}
