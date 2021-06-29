using UnityEngine;
using UnityEditor;
using System.Collections;

public class RemoveComp : ScriptableWizard
{
	public AudioClip clip;
	static Transform[] transforms;
	
	[MenuItem("Tools/Anshuman/Remove AudioSource",false)]
	static void CreateWindow()
	{
		transforms= Selection.GetTransforms(SelectionMode.OnlyUserModifiable);
		ScriptableWizard.DisplayWizard("Remove Audio Source Component",typeof(RemoveComp),"Remove");
	}
	
	void OnWizardCreate ()
	{
        foreach(Transform transform in transforms)
		{
//			transform.gameObject.AddComponent(typeof(AudioSource));
			AudioSource source=transform.gameObject.GetComponent(typeof(AudioSource))as AudioSource;
			source.enabled = false;
		}
	}
	void OnWizardUpdate()
	{	
		
	}		
}
