using UnityEngine;
using UnityEngine.UI;
using Kinect = Windows.Kinect;
using System.Collections;
using System.Collections.Generic;

public class PlayerRecognition : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private SceneSwitch sceneSwitch;
    
    private float playerLength;
    private float cameraDistance;
    
    public int RecognitionCount
    {
        get { return recognitionCount; }
    }
    private int recognitionCount;
    [SerializeField]
    private int maxRecognitionCount;

    [SerializeField]
    private Text playerNameText;
    [SerializeField]
    private Text playerLengthText;

    [SerializeField]
    private bool debugMode;

    public GameObject PlayerBody
    {
        get { return playerBody; }
        set { playerBody = value; }
    }
    [SerializeField]
    private GameObject playerBody;

    [SerializeField]
    private List<GameObject> bodyJoints = new List<GameObject>();

    public void GetJoints()
    {
        // Adding all joints to the list.
        if (playerBody != null)
        {
            for (int i = 0; i < playerBody.transform.childCount; i++)
            {
                bodyJoints.Add(playerBody.transform.GetChild(i).gameObject);
            }

            StartCoroutine(CheckBoneDistance());
        }
    }
    
     
    IEnumerator CheckBoneDistance()
    {
        while (true)
        {
            // Check if the body had been removed during the scan.
            if (playerBody == null)
            {
                bodyJoints.Clear();
                playerNameText.text = "Our user is: Not found";
                StopAllCoroutines();
            }

                // Calculation to get the center of our feet.
                Vector3 footDifference = (bodyJoints[JointsData.FootLeft].transform.position + bodyJoints[JointsData.FootRight].transform.position) / 2;
                Vector3 hipCenter = bodyJoints[JointsData.HipLeft].transform.position + bodyJoints[JointsData.HipRight].transform.position / 2;

                // Getting an average distance of the camera and our player.
                cameraDistance = (footDifference.z +
                    bodyJoints[JointsData.Head].transform.position.z +
                    hipCenter.z) / 3;

            if (cameraDistance >= 21f && cameraDistance <= 23f)
            {
                // Getting the distance between the feet, hip and head.
                playerLength = Vector3.Distance(footDifference, hipCenter) +
                    Vector3.Distance(hipCenter, bodyJoints[JointsData.Head].transform.position);

                // Calculating our average heigth.                    
                playerLength = cameraDistance / playerLength;

                // Making sure we get the absolute value of the player heigth.
                playerLength = Mathf.Abs(playerLength);
                Debug.Assert(!debugMode, "Length: " + playerLength);

                // Checking for the user: Raymon.
                if (playerLength >= NameData.raymonMinLength && playerLength <= NameData.raymonMaxLength)
                    CheckUser(NameData.raymon);

                // Checking for the user: Armin.
                else if (playerLength >= NameData.arminMinLength && playerLength <= NameData.arminMaxLength)
                    CheckUser(NameData.armin);

                // This is statement is used when the length of the user isnt recognized in our database.
                else
                    CheckUser(NameData.unregistered);

                playerLengthText.text = "Player H: " + playerLength;

                // Transition To the memory screen when we are sure who the player is.
                if (recognitionCount >= maxRecognitionCount)
                    TransitionToMemories();
            }
            else if (cameraDistance < 21)
                playerNameText.text = "Please stand further away from the camera";

            else if (cameraDistance > 23)
                playerNameText.text = "Please stand closer to the camera";
            // Check if the hip center, head and both feet are not being tracked
            /*
            else if (state == Kinect.TrackingState.Inferred)
                    Debug.Assert(!debugMode, "Not every bone is being tracked. Cant recognize the player.");
              */
            yield return new WaitForSeconds(1);
        }
    }
    
    void CheckUser(string userName)
    {
        // If this is the first time the user is recognized we need to reset the recognitionCount and set the activeUser.
        if (playerData.ActiveUser != userName)
        {
            playerData.ActiveUser = userName;
            recognitionCount = 0;
        }

        // As long as we are the same user we should add the recognitionCount with 1.
        else if (playerData.ActiveUser == userName)
        {
            playerNameText.text = "Our user is: " + userName;
            
            if (userName != NameData.unregistered)
                recognitionCount++;
        }
    }

    void TransitionToMemories()
    {
        playerNameText.text = "MEMORY SCENE!!!";
        sceneSwitch.TransitionToScene("Scene1", true, false, 0);
        StopAllCoroutines();
    }
}
