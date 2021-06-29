//////////////////////////////////////////////////////////////
// CameraRelativeControlExt.js
// Penelope iPhone Tutorial - Extended
//
// This script is an edited and simplified version of CameraRelativeControl.js.
// You can download and check CameraRelativeControl.js script from Penelope tutarial. ( see : http://unity3d.com/support/resources/tutorials/penelope )
//////////////////////////////////////////////////////////////

// This script must be attached to a GameObject that has a CharacterController
//@script RequireComponent( CharacterController )

//var joystickCircle : JoystickCircle;
var rotX : float;
var rotY : float;
var cameraPivot : Transform; // The transform used for camera rotation
var hit : RaycastHit;
var panel1 :GameObject ;
var oldrotation :Quaternion;
var touchStart : Vector2;
//var screenPoint : Vector3;

					function Start()
					{
						rotX = 0;
						rotY = 0;
				
						var spawn = GameObject.Find( "PlayerSpawn" );
						// Application.targetFrameRate = 60;
						if ( spawn )
							transform.position = spawn.transform.position;	
					}
					

function Update()
{
	// var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//	 var ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);

	
//		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
//		{
//			if(Input.touches[0].deltaPosition.magnitude > 0.3f)
//			{		
//				
//	
//					if(Mathf.Abs(Input.touches[0].deltaPosition.x) > Mathf.Abs(Input.touches[0].deltaPosition.y))
//					{
//							if(Mathf.Abs(rotX + Time.deltaTime * 4.0f * Input.touches[0].deltaPosition.x) < 60)
//							{
//									cameraPivot.Rotate( 0, Time.deltaTime * 4.0f * Input.touches[0].deltaPosition.x, 0);
//									rotX += Time.deltaTime * 4.0f * Input.touches[0].deltaPosition.x;
//							}
//								//	oldrotation = cameraPivot.transform.rotation;
//					}
//					else
//					{
//							if(Mathf.Abs(rotY - Time.deltaTime * 4.0f * Input.touches[0].deltaPosition.y) < 15)
//							{
//								cameraPivot.Rotate( -Time.deltaTime * 4.0f * Input.touches[0].deltaPosition.y, 0, 0);
//								rotY -= Time.deltaTime * 4.0f * Input.touches[0].deltaPosition.y;
//							}
//					
//					}
//			}			
//		}
//				screenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
//				 if(Input.GetMouseButton (0))
//						cameraPivot.transform.Rotate(screenPoint.x,0,0);
			
			 if(Input.touchCount)
			 {
			  	switch(Input.touches[0].phase)
			 	 {
			 		  case TouchPhase.Began:
				 		  touchStart = Input.touches[0].position;
					      break;
					  case TouchPhase.Moved:
					  		rotX = -Mathf.Clamp((Input.touches[0].position.y - touchStart.y) / (Screen.height / 100), -1f, 1f);
					  		rotY = Mathf.Clamp((Input.touches[0].position.x - touchStart.x) / (Screen.width / 100), -1f, 1f);
					  		
					  		//Debug.Log(cameraPivot.localEulerAngles + " === " + rotX + " === " + rotY );
					  		
					  		
					  		if((cameraPivot.localEulerAngles.x + rotX <= 60 || cameraPivot.localEulerAngles.x + rotX >= 330) && cameraPivot.localEulerAngles.y + rotY <= 270 && cameraPivot.localEulerAngles.y + rotY >= 90)
					  		{
					  			cameraPivot.Rotate( rotX,rotY,0);	
					  			
					  		}
			/*		  		else
					  		{
					  		
//					  			if(!(cameraPivot.localEulerAngles.x + xRotation <= 60) && !(cameraPivot.localEulerAngles.x + xRotation >= -60) && !(cameraPivot.localEulerAngles.y + yRotation <= 270) && !(cameraPivot.localEulerAngles.y + yRotation >= 90))
//					  			{
//					  			}
								if(cameraPivot.localEulerAngles.x + rotX >= 60)
					  			{
					  				cameraPivot.Rotate(-1,rotY,0);
					  				Debug.Log("else60:"+cameraPivot.localEulerAngles);
					  			}
					  			else if(cameraPivot.localEulerAngles.x + rotX <= -60)
					  			{
					  				cameraPivot.Rotate(1,rotY,0);
					  				Debug.Log("else-60:"+cameraPivot.localEulerAngles);
					  			}
					  			
					  			if(cameraPivot.localEulerAngles.y + rotY >= 270)
					  			{
					  				cameraPivot.Rotate(rotX,-1,0);
					  				Debug.Log("else270:"+cameraPivot.localEulerAngles);
					  			}
					  			else if(cameraPivot.localEulerAngles.y + rotY <= 90)
					  			{
					  				cameraPivot.Rotate(rotX,1,0);
					  				Debug.Log("else90:"+cameraPivot.localEulerAngles);
					  			}
					  		}
				*/	  		
					  		
					  		
					  		
			    			//cameraPivot .Rotate( rotX,rotY,0);
			    			touchStart = Input.touches[0].position;
			    			cameraPivot.localEulerAngles = Vector3(cameraPivot.localEulerAngles.x,cameraPivot.localEulerAngles.y,0);
			    			break;
			  	 } 
			 }

}