
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip engineThrust;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;

    Rigidbody rb;
    AudioSource audioSource;   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThursting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopParticles();
        }
    }

    void StartThursting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineThrust);
        }
        if (!mainEngineParticles.isPlaying)
        {
        mainEngineParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightEngineParticles.isPlaying)
        {
            rightEngineParticles.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftEngineParticles.isPlaying)
        {
            leftEngineParticles.Play();
        }
    }

    void StopParticles()
    {
        rightEngineParticles.Stop();
        leftEngineParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
