using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Planet : CelestialBody {

    
    public float orbitDistance = 2f;
    public float speedRotational = 0.4f;


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = GetPosition(Time.time * speedRotational);
    }

    private Vector3 GetPosition(float angle)
    {
        return new Vector3(orbitDistance * Mathf.Sin(angle), 0, orbitDistance * Mathf.Cos(angle));
    }


}
