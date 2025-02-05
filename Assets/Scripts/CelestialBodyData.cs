using UnityEngine;

[CreateAssetMenu(fileName = "CelestialBodyData", menuName = "Scriptable Objects/CelestialBodyData")]
public class CelestialBodyData : ScriptableObject
{
    public string nameCelestial;
    public string mass;
    public string diameter;
    public string gravitationalForce;
    public string distanceFromSun;
			
}