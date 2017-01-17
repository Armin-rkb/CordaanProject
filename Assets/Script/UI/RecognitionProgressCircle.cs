using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecognitionProgressCircle : MonoBehaviour
{
    [SerializeField]
    private Image progressCircleImage;

    [SerializeField]
    private DebugRecognition playerRecognition;

    private float progres;

	void Update () {
        progres = playerRecognition.RecognitionCount;
        progres = (progres / 10) + 0.3f;
        if (progres != 0.3f)
            progressCircleImage.fillAmount = Mathf.Lerp(progressCircleImage.fillAmount, progres, 0.25f);
        else
            progressCircleImage.fillAmount = 0;
	}
}