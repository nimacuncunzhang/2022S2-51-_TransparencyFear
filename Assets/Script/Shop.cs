using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void _Shop()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
	}
}
