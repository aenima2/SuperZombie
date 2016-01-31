using UnityEngine;
using System.Collections;

public class FighterBase : MovingObject 
{	
    protected override void Update()
	{
        base.Update();

		// fighting
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Punch();
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			Kick();
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			Block();
		}
	}

	// normal attacks
	// special attacks
	// combos



	void Punch()
	{
		Debug.Log("punch");
	}

	void Kick()
	{
		Debug.Log("kick");
	}

	void Block()
	{
		Debug.Log("block");
	}
}
