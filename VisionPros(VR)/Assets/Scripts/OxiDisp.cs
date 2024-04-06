using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxiDisp : MonoBehaviour
{
    public TextMeshProUGUI oxygenText; // Reference to the UI text displaying oxygen level
    public float initialOxygen = 98f; // Initial oxygen level
    public float finalOxygen; // Final oxygen level
    public float duration = 5f; // Duration in seconds for the oxygen level change

    public float currentOxygen; // Current oxygen level value
    private Coroutine oxygenChangeCoroutine; // Reference to the coroutine for oxygen level change
    public bool isSnapped = false;
    public bool oxyIsDoneCalibrating = false;

    private void Start()
    {
        currentOxygen = initialOxygen;
        finalOxygen = Random.Range(95f, 100f);
        UpdateOxygenDisplay();
    }

    public void StartOxygenChange()
    {
        if (gameObject.activeInHierarchy && isSnapped)
        {
            if (oxygenChangeCoroutine != null)
            {
                StopCoroutine(oxygenChangeCoroutine);
            }
            oxygenChangeCoroutine = StartCoroutine(ChangeOxygenOverTime());
        }
    }

    private IEnumerator ChangeOxygenOverTime()
    {
        float startTime = Time.time;
        while (currentOxygen < finalOxygen - 0.4)
        {
            float randomIncrement = Random.Range(0.1f, 0.5f);
            currentOxygen += randomIncrement;
            UpdateOxygenDisplay();
            yield return new WaitForSeconds(1f);
        }

        currentOxygen = finalOxygen; // Ensure final oxygen level is exact
        oxyIsDoneCalibrating = true;
        UpdateOxygenDisplay();
        isSnapped = false;
    }

    public void UpdateOxygenDisplay()
    {
        oxygenText.text = currentOxygen.ToString("F1") + "%";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnapZone1"))
        {
            isSnapped = true;
            StartOxygenChange();
        }
    }
}