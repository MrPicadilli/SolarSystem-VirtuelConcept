using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
/// <summary>
/// In charge of the position update of the camera and the rotation
/// </summary>
public class CameraManager : MonoBehaviour
{
	public GameObject target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	// origin position of the camera to know where to zoom out
	public Vector3 originPosition;
	// origin rotation of the camera to know where to zoom out
	public Quaternion originRotation;
	public List<GameObject> celestialBodies;
	public bool isZooming; 
	public static CameraManager instance;
	public float distanceCamera;
	public float rotationSpeed;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(this);
	}
	private void Start()
	{
		originPosition = transform.position;
		originRotation = transform.rotation;
	}
	private void LateUpdate()
	{

		if (isZooming)
		{
			Zoom();
		}
		if (Input.GetMouseButtonDown(1) || isZooming == false)
		{
			UIManager.instance.HideUI();
			DeZoom();
		}
		
	}

	public void Zoom()
	{
		// position management
		Vector3 targetPosition = target.transform.position + Vector3.up * distanceCamera;
		this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

		// Rotation management
		Vector3 direction = target.transform.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
	}
	public void DeZoom()
	{

		isZooming = false;
		// tried to zoom out smoothly but didnt work properly
		/*
		Vector3 targetPosition = originPosition;
		//Vector3 targetPosition = target.TransformPoint(new Vector3(0f, 1f, 0f));
		this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		// Rotate the forward vector towards the target direction by one step
		Quaternion targetRotation = Quaternion.LookRotation(originRotation.eulerAngles);
		transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, Time.deltaTime * rotationSpeed);
		*/
		transform.position = originPosition;
		transform.rotation = originRotation;
	}
	/// <summary>
	/// navigate toward the exterior
	/// </summary>
	public void NextCelestialBody()
	{
		int idNextCelestialBody = target.GetComponent<CelestialBody>().CelestialBodyOrder + 1;
		foreach (GameObject celestialBody in celestialBodies)
		{
			if (idNextCelestialBody == celestialBody.GetComponent<CelestialBody>().CelestialBodyOrder)
			{
				NewCelestialBodyToTarget(celestialBody, celestialBody.transform.localScale.x);
				UIManager.instance.ChangeCelestialBody(celestialBody.GetComponent<CelestialBody>().celestialBodyData);
				UIManager.instance.ShowUI(idNextCelestialBody);
			}

		}
	}
	/// <summary>
	/// navigate toward the sun
	/// </summary>
	public void PreviousCelestialBody()
	{
		int idNextCelestialBody = target.GetComponent<CelestialBody>().CelestialBodyOrder - 1;
		foreach (GameObject celestialBody in celestialBodies)
		{
			if (idNextCelestialBody == celestialBody.GetComponent<CelestialBody>().CelestialBodyOrder)
			{
				NewCelestialBodyToTarget(celestialBody, celestialBody.transform.localScale.x);
				UIManager.instance.ChangeCelestialBody(celestialBody.GetComponent<CelestialBody>().celestialBodyData);
				UIManager.instance.ShowUI(idNextCelestialBody);
			}
		}
	}

	/// <summary>
	/// Change the target of the camera
	/// </summary>
	/// <param name="CelestialBodyToTarget"> target</param>
	/// <param name="scale"> scale to change the position of camera</param>
	public void NewCelestialBodyToTarget(GameObject CelestialBodyToTarget, float scale)
	{
		isZooming = true;
		target = CelestialBodyToTarget;
		distanceCamera = scale;

	}

}

