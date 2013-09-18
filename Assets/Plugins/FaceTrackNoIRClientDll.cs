using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class FaceTrackNoIRClientDll  : MonoBehaviour {
       
       [StructLayout(LayoutKind.Sequential)]
       public struct FaceTrackData
       {
           public int dataid;
           public int camwidth, camheight;
           public Single Yaw, Pitch, Roll, X, Y, Z;
           public Single RawYaw, RawPitch, RawRoll;
           public Single RawX, RawY, RawZ;
           public Single x1, y1, x2, y2, x3, y3, x4, y4;          
       }

       [DllImport("FaceTrackNoIRClient")]
       public static extern bool FTGetData(ref FaceTrackData data);

       [DllImport("FaceTrackNoIRClient")]
       public static extern string FTGetDllVersion();

       [DllImport("FaceTrackNoIRClient")]
       public static extern void FTReportID(Int32 name);

       [DllImport("FaceTrackNoIRClient")]
       public static extern string FTProvider();
	
	
    public float Yaw=0F;
	public float Pitch=0F;
	public float Roll=0F;
    public float X=0F;
	public float Y=0F;
	public float Z=0F;
	
	public float RawYaw=0F;
	public float RawPitch=0F;
	public float RawRoll=0F;
    public float RawX=0F;
	public float RawY=0F;
	public float RawZ=0F;
	
	private float x1=0F;
	private float y1=0F;
	private float x2=0F;
	private float y2=0F;
	private float x3=0F;
	private float y3=0F;
	private float x4=0F;
	private float y4=0F;
	
       
	 void Update()
{
		FaceTrackNoIRClientDll.FaceTrackData FaceTrackData;
	 	FaceTrackData =  new FaceTrackNoIRClientDll.FaceTrackData();
               if (!FaceTrackNoIRClientDll.FTGetData(ref FaceTrackData))
               {
                   Debug.Log ("FaceTrackNoIR don't recognize any head.");
                   return;
               }
		
	
	
                
        FaceTrackNoIRClientDll.FTGetData(ref FaceTrackData); 
		
        Yaw = FaceTrackData.Yaw;
		Pitch = FaceTrackData.Pitch;
		Roll = FaceTrackData.Roll;
		X = FaceTrackData.X;
		Y = FaceTrackData.Y;
		Z = FaceTrackData.Z;
		
		RawYaw=FaceTrackData.RawYaw;
		RawPitch=FaceTrackData.RawPitch;
		RawRoll=FaceTrackData.RawRoll;
		
     	RawX=FaceTrackData.RawX;
		RawY=FaceTrackData.RawY;
		RawZ=FaceTrackData.RawZ;
	
		x1=FaceTrackData.x1;
		y1=FaceTrackData.y1;
		x2=FaceTrackData.x2;
		y2=FaceTrackData.y2;
		x3=FaceTrackData.x3;
		y3=FaceTrackData.y3;
		x4=FaceTrackData.x4;
		y4=FaceTrackData.y4;
	
   }
 }

 