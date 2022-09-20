using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class soundManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public Slider Slider;


    private void Update()
    {
            AudioSource.volume = Slider.value;
    }

    
    private void finishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }

}
