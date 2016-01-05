using UnityEngine;
using System.Collections;

public class FaceTrackMovment : MonoBehaviour {

    [SerializeField]
    UDPReceive receiver = null;

    Transform startPos = null;

    [SerializeField]
    float reductionPositionFactor = 1;

    [SerializeField]
    float reductionRotationFactor = 1;


    void Start ()
    {
        startPos = transform;
	}
	
	void Update ()
    {
        transform.position = new Vector3(receiver.xPos * reductionPositionFactor, receiver.yPos * reductionPositionFactor, -receiver.zPos * reductionPositionFactor );
        transform.rotation = Quaternion.Euler(-receiver.pitch * reductionRotationFactor, -receiver.yaw * reductionRotationFactor, receiver.roll * reductionRotationFactor);
    }
}
