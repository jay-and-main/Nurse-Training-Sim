using System.Collections;
using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class SubtitlesLogic : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Reference to the TextMeshProUGUI for display
    public string introText = "Welcome to nurse simulation"; // The intro text to display
    public string tempString = "Check the patient's temperature using the thermometer"; // The text to display for "Check the patient's temperature"
    public string oxiString = "Check the patient's oxygen level and heart rate using the oxymeter"; // The text to display for "Check the patient's oxygen level"
    public string ivString = "Start the IV insertion using the syringe"; // The text to display for "Start the IV drip"

    public float displayStart = 2f; // Time to start displaying the intro text
    public float displayDuration = 5f; // Duration to display the intro text
    public TempDisp tempDisp; // Reference to the TempDisp script
    public OxiDisp oxiDisp; // Reference to the OxiDisp script
    public bool oxiTextDone = false; // Flag to check if oxygen text is done
    public bool ivTextDone = false; // Flag to check if IV text is done

    // Start is called before the first frame update
    void Start()
    {
        displayText.text = ""; // Clear the text initially
        StartCoroutine(DisplayIntroText());
    }

    private IEnumerator DisplayIntroText()
    {
        yield return new WaitForSeconds(displayStart);
        displayText.text = introText; // Show the intro text
        yield return new WaitForSeconds(displayDuration);
        displayText.text = tempString; // Clear the text
        yield return new WaitForSeconds(displayDuration);
        displayText.text = ""; // Clear the text
    }

    void Update()
    {
        if (tempDisp.isDoneCalibrating && !oxiTextDone)
        {
            oxiTextDone = true;
            StartCoroutine(DisplayOxiText());
        }
        if (oxiDisp.oxyIsDoneCalibrating && !ivTextDone)
        {
            ivTextDone = true;
            StartCoroutine(DisplayIVText());
        }
    }
    private IEnumerator DisplayOxiText()
    {
        tempDisp.isDoneCalibrating = false;
        displayText.text = oxiString;
        yield return new WaitForSeconds(displayDuration);
        displayText.text = ""; // Clear the text
    }
    private IEnumerator DisplayIVText()
    {
        oxiDisp.oxyIsDoneCalibrating = false;
        displayText.text = ivString;
        yield return new WaitForSeconds(displayDuration);
        displayText.text = ""; // Clear the text
    }
}