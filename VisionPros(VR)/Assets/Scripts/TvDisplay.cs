using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class TvDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI displayText;
    public TempDisp tempDisp; // Reference to the TempDisp script
    public OxiDisp oxiDisp; // Reference to the OxiDisp script
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = "Temperature: " + tempDisp.currentTemperature.ToString("F1") + "°C\n" +
                          "Oxygen Level: " + oxiDisp.currentOxygen.ToString("F1") + "%";
    }
}
