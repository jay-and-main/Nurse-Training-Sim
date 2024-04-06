using System.Collections;
using UnityEngine;

public class NurseAudio : MonoBehaviour
{
    public AudioClip welcomeClip;
    public AudioClip checkTempAudioClip;
    public AudioClip checkOxygenAudioClip;
    public AudioClip StartIVAudioClip;
    public AudioClip performIVAudioClip;
    private AudioSource nurseAudioSource;
    public TempDisp tempDisp;
    public OxiDisp oxiDisp;
    public bool tempVoiceDone = false;
    public bool oxiVoiceDone = false;

    void Start()
    {
        nurseAudioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySecondClipAfterDelay());
    }

    void Update()
    {
        if (tempDisp.isDoneCalibrating && !tempVoiceDone)
        {
            tempVoiceDone = true;
            nurseAudioSource.PlayOneShot(checkOxygenAudioClip);
        }
        if (oxiDisp.oxyIsDoneCalibrating && !oxiVoiceDone)
        {
            oxiVoiceDone = true;
            StartCoroutine(PlayIVClipAfterDelay());
        }
    }
    IEnumerator PlaySecondClipAfterDelay()
    {
        nurseAudioSource.PlayOneShot(welcomeClip);
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        nurseAudioSource.PlayOneShot(checkTempAudioClip);
    }

    IEnumerator PlayIVClipAfterDelay()
    {
            nurseAudioSource.PlayOneShot(StartIVAudioClip);
            yield return new WaitForSeconds(10); // Wait for 3 seconds
            nurseAudioSource.PlayOneShot(performIVAudioClip);
    }
}
