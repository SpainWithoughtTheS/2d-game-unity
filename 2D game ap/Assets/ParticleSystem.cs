using UnityEngine;

public class CameraTransitionParticle : MonoBehaviour
{
    public ParticleSystem particleSystemObject; // Reference to the ParticleSystem component

    private CameraTransition cameraTransition; // Reference to the CameraTransition script

    void Start()
    {
        // Get the CameraTransition script attached to the main camera
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            cameraTransition = mainCamera.GetComponent<CameraTransition>();
        }

        // Ensure that the particle system is initially stopped
        if (particleSystemObject != null)
        {
            particleSystemObject.Stop();
        }
    }

    void Update()
    {
        // Check if the camera transition script is valid and transition is occurring
        if (cameraTransition != null && cameraTransition.IsTransitioning)
        {
            // Activate the particle system if it's not already playing
            if (particleSystemObject != null && !particleSystemObject.isPlaying)
            {
                particleSystemObject.Play();
            }
        }
        else
        {
            // Deactivate the particle system if it's playing
            if (particleSystemObject != null && particleSystemObject.isPlaying)
            {
                particleSystemObject.Stop();
            }
        }
    }
}

// Placeholder CameraTransition class
public class CameraTransition : MonoBehaviour
{
    // Placeholder property to indicate if transitioning
    public bool IsTransitioning { get; private set; }

    // Placeholder implementation for camera transition logic
    // You can replace this with actual camera transition logic
}
