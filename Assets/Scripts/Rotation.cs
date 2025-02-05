using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// symply rotate the object
/// </summary>
public class Rotation : MonoBehaviour {
    public float speed = 120.0f;

	void Update () {
        transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
