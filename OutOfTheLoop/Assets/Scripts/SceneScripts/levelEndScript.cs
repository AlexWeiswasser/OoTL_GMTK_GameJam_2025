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

    public float timer = 0f;
    private bool levelOver = false;

    private TextMeshProUGUI levelTimer;

    void Update()
    {
        if(!levelOver)
            timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Do whatever is needed when the level is over, like particles or annimation and end with loading the next level
        if (collision.gameObject.CompareTag("Player"))
        {
            levelTimer = GameObject.Find("TimerUI").GetComponent<TextMeshProUGUI>();
            levelTimer.text = timer.ToString();

            levelOver = true;
            levelWinParticles.Play();
            cheering.Play();
        }
    }

    public void loadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }

   
}
