using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public CelestialBodyData celestialBodyData;
    public int CelestialBodyOrder;
    
    void OnMouseDown()
    {
        CameraManager.instance.NewCelestialBodyToTarget(this.gameObject, transform.localScale.x);
        UIManager.instance.ChangeCelestialBody(celestialBodyData);
        UIManager.instance.ShowUI(CelestialBodyOrder);

    }
}
