using UnityEngine;
using TMPro;

using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class FingerIndexCurlDetection : MonoBehaviour
{
    public GameObject visualMarker;
    public TMP_Text Value_text;
    public float threshold;

    private int _totalCount;
    private int _thumbValue;
    private int _indexValue;
    private int _middlebValue;
    private int _ringValue;
    private int _pinkyValue;

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

        _thumbValue = 0;
        _indexValue = 0;
        _middlebValue = 0;
        _ringValue = 0;
        _pinkyValue = 0;

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out pose))
        {
            if(HandPoseUtils.ThumbFingerCurl(Handedness.Left) < 0.5f)
            {            
                thumbObject.GetComponent<Renderer>().enabled = true;
                thumbObject.transform.position = pose.Position;
                _thumbValue = 1;
            }
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out pose))
        {
            if(HandPoseUtils.IndexFingerCurl(Handedness.Left) < 0.1f)
            {
                indexObject.GetComponent<Renderer>().enabled = true;
                indexObject.transform.position = pose.Position;
                _indexValue = 2;
            }
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out pose))
        {
            if(HandPoseUtils.MiddleFingerCurl(Handedness.Left) < 0.1f)
            {
                middleObject.GetComponent<Renderer>().enabled = true;
                middleObject.transform.position = pose.Position;
                _middlebValue = 4;
            }
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out pose))
        {
            if(HandPoseUtils.RingFingerCurl(Handedness.Left) < 0.1f)
            {
                ringObject.GetComponent<Renderer>().enabled = true;
                ringObject.transform.position = pose.Position;
                _ringValue = 8;
            }
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out pose))
        {
            if(HandPoseUtils.PinkyFingerCurl(Handedness.Left) < 0.1f)
            {
                pinkyObject.GetComponent<Renderer>().enabled = true;
                pinkyObject.transform.position = pose.Position;
                _pinkyValue = 16;
            }
        }

        _totalCount = _thumbValue + _indexValue + _middlebValue + _ringValue + _pinkyValue;
        Value_text.text = _totalCount.ToString();
    }
}