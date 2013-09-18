using UnityEngine;
using System.Collections;

public class TranslateToCube : MonoBehaviour {
	public FaceTrackNoIRClientDll FTinput;
	public Transform Target;
	public float PositionSpeed=0.001f;
	Vector3 startPos = Vector3.zero;
	public float RotationSpeed=60F;
	// Use this for initialization
	void Start () {
	FTinput = this.GetComponent<FaceTrackNoIRClientDll>();
	Target = GameObject.FindGameObjectWithTag("Player").transform;	
	startPos = Target.position;
	}
	
	// Update is called once per frame
	void Update () {
	if(Target)
		{
		Target.position =startPos + new Vector3(-FTinput.X*PositionSpeed,FTinput.Y*PositionSpeed,-FTinput.Z*PositionSpeed);
		
		Target.rotation = Quaternion.Euler(-FTinput.Pitch*RotationSpeed,-FTinput.Yaw*RotationSpeed,FTinput.Roll*RotationSpeed);
		}
	else return;
	}
}
