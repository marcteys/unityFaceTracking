


private var csTracker : UDPReceive ;

private var verifOnce : boolean  = true;
	public var PositionSpeed : float=0.001;

		public var RotationSpeed : float= 5;
		
var Target :Transform;
   private var oriYaw : float;
	private var oriPitch: float;
	private var oriRoll: float;

    private var oriX: float;;
	private var oriY: float;
	private var oriZ: float;;

	private var oriRawYaw: float;
	private var oriRawPitch: float;
	private var oriRawRoll: float;
    private var oriRawX: float;;
	private var oriRawY: float;
	private var oriRawZ: float;
	
	private var startPos : Vector3 = Vector3.zero;


    public var X: float;
	public var Y: float;
	public var Z: float;


/*
    public var Yaw : float;
	public var Pitch: float;
	public var Roll: float;
    public var X: float;;
	public var Y: float;
	public var Z: float;;
	
	public var RawYaw: float;
	public var RawPitch: float;
	public var RawRoll: float;
    public var RawX: float;;
	public var RawY: float;
	public var RawZ: float;
*/

function Start () {
	csTracker = GameObject.Find("Test2").GetComponent("UDPReceive");
		startPos = Target.position;
}


function Update () {




/* RaZ */
	if(verifOnce && csTracker.Yaw !=0 )  {
		initVariables();
		verifOnce = false;

	} if (Input.GetKey ("up")) initVariables();
	
	
/* Update values */

X = csTracker.X - oriX  ;
	
	
	if(Target)
		{
		
	//	Target.position = ;
	Target.position =startPos + new Vector3(csTracker.X*PositionSpeed,csTracker.Y*PositionSpeed,-csTracker.Z*PositionSpeed);
		
		Target.rotation = Quaternion.Euler(-csTracker.Pitch*RotationSpeed,-csTracker.Yaw*RotationSpeed,csTracker.Roll*RotationSpeed);
		}
	else return;
	
	
	
	
	
}























function initVariables() {
	
	   oriYaw = csTracker.Yaw;
	 oriPitch= csTracker.Pitch;
	 oriRoll= csTracker.Roll;
	 
   	 oriX= csTracker.X;
	 oriY= csTracker.Y;
		oriZ= csTracker.Z;
	
	 oriRawYaw= csTracker.RawYaw;
	 oriRawPitch= csTracker.RawPitch;
	 oriRawRoll= csTracker.Roll;
    oriRawX= csTracker.RawX;
	 oriRawY= csTracker.RawY;
	oriRawZ= csTracker.RawZ;


}