using UnityEngine;
using System.Collections;

public class CopyCamera : MonoSingleton<CopyCamera> 
{
	public Transform CameraTf { get { return Camera.main.transform; } }
	
	void Update()
	{
		transform.position = CameraTf.position;
		transform.rotation = CameraTf.rotation;
		transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y,0);
	}
}
