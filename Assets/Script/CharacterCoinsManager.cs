using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCoinsManager : MonoBehaviour
{
	private static int diamondAmount = 0;

	[SerializeField] private Text coinText;

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("money"))
		{
			Debug.Log("amount:" + diamondAmount);
			Destroy(collision.gameObject);

			coinText.text = "COIN:" + diamondAmount;
		}
	}
}
