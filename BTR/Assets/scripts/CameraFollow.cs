using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
	[Header("Object to follow")]
	// This is the object that the camera will follow
	Transform target;
    public float alejamiento = -10f;

	private Vector3 lerpedPosition;
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // FixedUpdate is called every frame, when the physics are calculated
    void FixedUpdate()
	{
		if(target != null)
		{
			// Find the right position between the camera and the object
			lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10f);
            lerpedPosition.z = alejamiento;
		}
	}



	// LateUpdate is called after all other objects have moved
	void LateUpdate ()
	{
		if(target != null)
		{
			// Move the camera in the position found previously
			transform.position = lerpedPosition;
		}
	}
}
