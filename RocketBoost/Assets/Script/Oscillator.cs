using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementPos;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        {

        }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2;

        Vector3 offset = movementPos * movementFactor;
        transform.position = startingPos + offset;
    }
}
