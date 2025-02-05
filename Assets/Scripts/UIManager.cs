using UnityEngine;
using System.Collections;
using TMPro;
using System;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{

    private float timeScale;

    public static string header = "Solar System";
    public static string info = "Mercury\nVenus\nEarth\nMars";

    public GUIStyle styleHeader;
    public static UIManager instance;
    public TextMeshProUGUI celestialBodyNameText;
    public TextMeshProUGUI celestialBodyDescriptionText;
    public GameObject DescriptionPanel;
    public GameObject PreviousCelestialBodyButton;
    public GameObject NextCelestialBodyButton;
    public CelestialBodyData currentCelestialBodyData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    private void Start()
    {
        HideUI();
    }
    public void ShowCelestialBodyInformation()
    {
        celestialBodyNameText.text = currentCelestialBodyData.nameCelestial;
        celestialBodyDescriptionText.text = currentCelestialBodyData.mass;
    }
    public void ChangeCelestialBody(CelestialBodyData actualCelestialBody)
    {
        currentCelestialBodyData = actualCelestialBody;
        ShowCelestialBodyInformation();
    }
    public void ShowUI(int idCelestialBody)
    {
        DescriptionPanel.SetActive(true);
        switch (idCelestialBody)
        {
            case <= 0:
                NextCelestialBodyButton.SetActive(true);
                PreviousCelestialBodyButton.SetActive(false);
                break;
            case >= 8:
                PreviousCelestialBodyButton.SetActive(true);
                NextCelestialBodyButton.SetActive(false);
                break;
            default:
                NextCelestialBodyButton.SetActive(true);
                PreviousCelestialBodyButton.SetActive(true);
                break;
        }




    }
    public void HideUI()
    {
        DescriptionPanel.SetActive(false);
        NextCelestialBodyButton.SetActive(false);
        PreviousCelestialBodyButton.SetActive(false);
    }

}
