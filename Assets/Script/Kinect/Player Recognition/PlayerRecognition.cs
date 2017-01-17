using UnityEngine;
using UnityEngine.UI;
using Kinect;
using System.Collections;

public class PlayerRecognition : MonoBehaviour
{
    [SerializeField]
    private KinectPointController kinectPointController;
    [SerializeField]
    private SkeletonWrapper skeletonWrapper;

    [SerializeField]
    private float playerLength;
    [SerializeField]
    private float cameraDistance;

    [SerializeField]
    private int recognitionCount;

    [SerializeField]
    private Text playerNameText;
    [SerializeField]
    private Text playerLengthText;
    
    private string activeUser;

    [SerializeField]
    private bool debugMode;

    void Start()
    {
        StartCoroutine(CheckBoneDistance());
    }

    IEnumerator CheckBoneDistance()
    {
        while (true)
        {
            for (int i = 0; i < kinectPointController.sw.trackedPlayers.Length; i++)
            {
                NuiSkeletonPositionTrackingState[,] boneState = new NuiSkeletonPositionTrackingState[2, (int)NuiSkeletonPositionIndex.Count];
                boneState = kinectPointController.sw.boneState;
                // This returns: Tracked and NotTracked. The first number of the array is the player number and the second is the bone number.
                // Check if the hip center, head and both feet are being tracked.
                if (boneState[0, 0] == NuiSkeletonPositionTrackingState.Tracked &&
                    boneState[0, 3] == NuiSkeletonPositionTrackingState.Tracked &&
                    boneState[0, 15] == NuiSkeletonPositionTrackingState.Tracked &&
                    boneState[0, 19] == NuiSkeletonPositionTrackingState.Tracked)
                {
                    Debug.Assert(!debugMode, "Player bones are being tracked!");

                    // Calculation to get the center of our feet.
                    Vector3 footDifference = (kinectPointController.Foot_Left.transform.position + kinectPointController.Foot_Right.transform.position) / 2;

                    // Getting an average distance of the camera and our player.
                    cameraDistance = (footDifference.z +
                        kinectPointController.Head.transform.position.z +
                        kinectPointController.Hip_Center.transform.position.z) / 6;

                    // Getting the distance between the feet, hip and head.
                    playerLength = Vector3.Distance(footDifference, kinectPointController.Hip_Center.transform.position) +
                        Vector3.Distance(kinectPointController.Hip_Center.transform.position, kinectPointController.Head.transform.position);

                    // Calculating our average heigth.                    
                    playerLength = cameraDistance / playerLength;

                    // Making sure we get the absolute value of the player heigth.
                    playerLength = Mathf.Abs(playerLength);
                    Debug.Assert(!debugMode, "Length: " + playerLength);

                    // Checking for the user: Raymon.
                    if (playerLength >= 1.79f && playerLength <= 1.80f)
                        CheckUser(NameData.raymon);

                    // Checking for the user: Armin.
                    else if (playerLength >= 1.74f && playerLength <= 1.76f)
                        CheckUser(NameData.armin);

                    // This is statement is used when the length of the user isnt recognized in our database.
                    else
                        CheckUser(NameData.unregistered);

                    playerLengthText.text = "Player is: " + playerLength + "m";

                    // Transition To the memory screen when we are sure who the player is.
                    if (recognitionCount >= 6)
                        TransitionToMemories();
                }

                // Check if the hip center, head and both feet are not being tracked.
                else if (boneState[i, 0] == NuiSkeletonPositionTrackingState.NotTracked ||
                    boneState[i, 3] == NuiSkeletonPositionTrackingState.NotTracked ||
                    boneState[i, 15] == NuiSkeletonPositionTrackingState.NotTracked ||
                    boneState[i, 19] == NuiSkeletonPositionTrackingState.NotTracked)
                {
                    Debug.Assert(!debugMode, "Not every bone is being tracked. Cant recognize the player.");
                    playerNameText.text = "Our user is Not Found";
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    void CheckUser(string userName)
    {
        print(recognitionCount);
        // If this is the first time the user is recognized we need to reset the recognitionCount and set the activeUser.
        if (activeUser != userName)
        {
            activeUser = userName;
            recognitionCount = 0;
        }

        // As long as we are the same user we should add the recognitionCount with 1.
        else if (activeUser == userName)
        {
            playerNameText.text = "Our user is " + userName;

            if (userName != NameData.unregistered)
                recognitionCount++;
        }
    }

    void TransitionToMemories()
    {
        playerNameText.text = "MEMORY SCENE!!!";
        StopAllCoroutines();
    }
}
