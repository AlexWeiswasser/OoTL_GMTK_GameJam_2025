using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class levelEndScript : MonoBehaviour
{

    public ParticleSystem levelWinParticles;
    public string SceneName;
    [SerializeField] private AudioSource cheering;

    private GameObject levelEndUI;

    bool alreadyWon = false;

	private void Start()
	{
		levelEndUI = GameObject.Find("LevelEndUI");
        levelEndUI.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        levelEndUI.SetActive(true);

        //Do whatever is needed when the level is over, like particles or annimation and end with loading the next level
        if (collision.gameObject.CompareTag("Player") && !alreadyWon)
        {
            levelWinParticles.Play();
            cheering.Play();
            alreadyWon = true;
        }
    }

    public void loadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }

   
}
