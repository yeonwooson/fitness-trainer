using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPinchDetector : MonoBehaviour
{
    [SerializeField] private OVRHand hand;

    private bool _hasPinched;
    private bool _isIndexFingerPinching;
    private float _pinchStrength;
    private OVRHand.TrackingConfidence _confidence;

    void Update() => CheckPinch(hand);

    void CheckPinch(OVRHand hand)
    {
        _pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        _isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        _confidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        if (!_hasPinched && _isIndexFingerPinching && _confidence == OVRHand.TrackingConfidence.High)
        {
            _hasPinched = true;
        }
        else if (_hasPinched && !_isIndexFingerPinching)
        {
            _hasPinched = false;
        }
    }
}
