using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crash,win;
    [SerializeField] ParticleSystem crashParticles,winParticles;

    AudioSource audioSource;

    bool isTrasitioning = false;
    bool isCollision = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCollision = !isCollision;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTrasitioning||isCollision)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
               
                SuccesSequance();
                break;

            default:
                
                CrashSequance();
                break;
        }
    }
    void SuccesSequance()
    {
       
        isTrasitioning = true;
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(win);
        winParticles.Play();
        Invoke("NextLevel", delay);
    }
    void CrashSequance()
    {
        isTrasitioning = true;
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        Invoke("ReloadLevel",delay);
    }
    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
    void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentIndex + 1;
        if (nextScene== SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
}
