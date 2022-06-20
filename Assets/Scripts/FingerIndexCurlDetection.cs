using UnityEngine;
using TMPro;

using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class FingerIndexCurlDetection : MonoBehaviour
{
    public GameObject visualMarker;
    public TMP_Text curlValues;
    public TMP_Text Value_text;
    public float threshold;

    GameObject thumbObject;
    GameObject indexObject;
    GameObject middleObject;
    GameObject ringObject;
    GameObject pinkyObject;
    GameObject wristObject;

    MixedRealityPose pose;

    private void Start()
    {
        thumbObject = Instantiate(visualMarker, this.transform);
        indexObject = Instantiate(visualMarker, this.transform);
        middleObject = Instantiate(visualMarker, this.transform);
        wristObject = Instantiate(visualMarker, this.transform);
        ringObject = Instantiate(visualMarker, this.transform);
        pinkyObject = Instantiate(visualMarker, this.transform);
    }

    private void Update()
    {
        thumbObject.GetComponent<Renderer>().enabled = false;
        indexObject.GetComponent<Renderer>().enabled = false;
        middleObject.GetComponent<Renderer>().enabled = false;
        wristObject.GetComponent<Renderer>().enabled = false;
        ringObject.GetComponent<Renderer>().enabled = false;
        pinkyObject.GetComponent<Renderer>().enabled = false;


        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out pose))
        {
            thumbObject.GetComponent<Renderer>().enabled = true;
            thumbObject.transform.position = pose.Position;
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out pose))
        {
            indexObject.GetComponent<Renderer>().enabled = true;
            indexObject.transform.position = pose.Position;
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out pose))
        {
            middleObject.GetComponent<Renderer>().enabled = true;
            middleObject.transform.position = pose.Position;
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out pose))
        {
            ringObject.GetComponent<Renderer>().enabled = true;
            ringObject.transform.position = pose.Position;
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out pose))
        {
            pinkyObject.GetComponent<Renderer>().enabled = true;
            pinkyObject.transform.position = pose.Position;
        }

        /*
        curlValues.text = "\n" + HandPoseUtils.ThumbFingerCurl(Handedness.Right) + "\n"
                + HandPoseUtils.IndexFingerCurl(Handedness.Right) + "\n"
                + HandPoseUtils.MiddleFingerCurl(Handedness.Right) + "\n"
                + HandPoseUtils.RingFingerCurl(Handedness.Right) + "\n"
                + HandPoseUtils.PinkyFingerCurl(Handedness.Right) + "\n";
        */
    }
}