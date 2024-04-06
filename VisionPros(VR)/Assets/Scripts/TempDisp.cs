using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempDisp : MonoBehaviour
{
    public TextMeshProUGUI temperatureText; // Reference to the UI text displaying temperature
    public float initialTemperature = 37f; // Initial temperature
    public float finalTemperature; // Final temperature
    public float duration = 5f; // Duration in seconds for the temperature change

    public float currentTemperature; // Current temperature value
    private Coroutine temperatureChangeCoroutine; // Reference to the coroutine for temperature change
    public AudioClip beepSound;
    private AudioSource beepSource;
    public bool isSnapped = false;
    public bool isDoneCalibrating = false;

    private void Start()
    {
        currentTemperature = initialTemperature;
        finalTemperature = Random.Range(37f, 41f);
        beepSource = GetComponent<AudioSource>();
        beepSound = Resources.Load<AudioClip>("TempBeep");
        UpdateTemperatureDisplay();
    }

    public void StartTemperatureChange()
    {
        if (gameObject.activeInHierarchy && isSnapped)
        {
            if (temperatureChangeCoroutine != null)
            {
                StopCoroutine(temperatureChangeCoroutine);
            }
            temperatureChangeCoroutine = StartCoroutine(ChangeTemperatureOverTime());
        }
    }

    private IEnumerator ChangeTemperatureOverTime()
    {
        float startTime = Time.time;
        while (currentTemperature < finalTemperature - 0.4)
        {
            float randomIncrement = Random.Range(0.1f, 0.5f);
            currentTemperature += randomIncrement;
            UpdateTemperatureDisplay();
            yield return new WaitForSeconds(1f);
        }

        currentTemperature = finalTemperature; // Ensure final temperature is exact
        isDoneCalibrating = true;
        UpdateTemperatureDisplay();
        if (beepSound == null)
        {
            Debug.LogError("beepSound is null");
        }
        else
        {
            beepSource.PlayOneShot(beepSound, 1.0f);
        }
        isSnapped = false;
    }

    public void UpdateTemperatureDisplay()
    {
        temperatureText.text = currentTemperature.ToString("F1") + "°C";
    }

    public void SetBeepSound(AudioClip clip)
    {
        beepSound = clip;
        if (beepSource == null)
        {
            beepSource = gameObject.AddComponent<AudioSource>();
        }
        beepSource.clip = beepSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnapZone"))
        {
            isSnapped = true;
            StartTemperatureChange();
        }
    }
}