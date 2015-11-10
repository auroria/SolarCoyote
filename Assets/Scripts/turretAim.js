var targetRange : float = 50.0;
var turnSpeed : float = 6.0;
var _parent : Transform;
//to store targetposition for demonstration purposes.
var targetPos : Vector3;

function LateUpdate(){

var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
var rayHit : RaycastHit;
var rotateTo : Quaternion;

//Aim at object under mouse (if closer than targetRange)
if(Physics.Raycast(ray, rayHit, 50) && rayHit.transform != _parent ){
	rotateTo = Quaternion.LookRotation(rayHit.transform.position - transform.position, transform.up);
	//this line for demonstration only
	targetPos = rayHit.transform.position;
}else{//  Mouse isn't over anything imporant-Aim a distant point.
     rotateTo = Quaternion.LookRotation(ray.GetPoint(targetRange) - transform.position, transform.up);
	 //this line for demonstration only
	targetPos = ray.GetPoint(targetRange);
}
transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, Time.deltaTime * turnSpeed);
}