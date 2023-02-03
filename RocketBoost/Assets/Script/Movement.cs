using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] AudioClip engine;
    [SerializeField] ParticleSystem mainBooster, leftBooster, rightBooster;


    Rigidbody rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*speed*Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engine);
            }
            if (!mainBooster.isPlaying)
            {
                mainBooster.Play();
            }
            
        }
        else
        {
            audioSource.Stop();
            mainBooster.Stop();
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
           
            RotationAplly(rotSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
           
            RotationAplly(-rotSpeed);
        }
        else
        {
            rightBooster.Stop();
            leftBooster.Stop();
        }
    }
    void RotationAplly(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
