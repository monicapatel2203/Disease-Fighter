using UnityEngine;
using UnityEditor;
using System.Collections;

public class AddBoxCollider : ScriptableWizard 
{
	
	static Transform[] transforms;
	public float widthX= 0.7849f;
	public float heightY = 0.02f;
	public float depthZ = 2.5f;
	
	public float centerX = 0.0f;
	public float centerY = -0.1f;
	public float centerZ = 1.2f;
	
//	public float widthX= 0.5f;
//	public float heightY = 0.07f;
//	public float depthZ = 2.5f;
//	
//	public float centerX = 0.1f;
//	public float centerY = 0.0f;
//	public float centerZ = 1.2f;
	
	

	[MenuItem("Tools/Rahul/AddBoxColliders",false)]
	static void CreateWindow()
	{
		
		transforms= Selection.GetTransforms(SelectionMode.OnlyUserModifiable);
		ScriptableWizard.DisplayWizard("Add BoxCollider",typeof(AddBoxCollider),"Add");
		
	}
	
	void OnWizardCreate ()
	{
        foreach(Transform transform in transforms)
		{
	
//			if(transform.name.Equals("Plane114"))
//			{
//				continue;
//			}
			BoxCollider box = transform.gameObject.GetComponent(typeof(BoxCollider)) as BoxCollider;
			if(box == null)
			{
				transform.gameObject.AddComponent(typeof(BoxCollider));
				box = transform.gameObject.GetComponent(typeof(BoxCollider)) as BoxCollider;
			}
			
			
			box.size = new Vector3(widthX,heightY,depthZ);
			box.center = new Vector3(centerX,centerY,centerZ);
			
		}
	}
}
