using UnityEngine;
using UnityEngine.UI;

public class RecognitionProgressCircle : MonoBehaviour
{
    [SerializeField]
    private Image progressCircleImage;

    [SerializeField]
    private PlayerRecognition playerRecognition;

    private float progress;

	void Update () {
        progress = playerRecognition.RecognitionCount;
        progress = (progress / 10) + 0.3f;
        if (progress != 0.3f)
            progressCircleImage.fillAmount = Mathf.Lerp(progressCircleImage.fillAmount, progress, 0.25f);
        else
            progressCircleImage.fillAmount = 0;
	}
}