using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 4f;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2; //const of 6.283
        float rawSignWave = Mathf.Sin(cycles * tau); // updates between -1 and 1

        movementFactor = (rawSignWave + 1f) / 2f; // recalculate to be between 0 and 1 so we don't start in the middle

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
