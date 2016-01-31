using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	static T sm_instance;

	public static T Instance
	{
		get
		{
			if (sm_applicationIsQuitting) 
			{
				Debug.LogWarning(string.Format("[MonoSingleton] Instance '{0}' already destroyed on application quit. Won't create again - returning null.", typeof(T)));
				return null;
			}

			if(sm_instance == null)
			{
				sm_instance = FindObjectOfType<T>();

				if(sm_instance == null)
				{
					GameObject go = new GameObject(string.Format("_{0}_", typeof(T)));
					sm_instance = go.AddComponent<T>();
					Debug.Log(string.Format("[MonoSingleton] An instance of {0} was created.", typeof(T)));
				}
			}

			return sm_instance;
		}
	}

	static bool sm_applicationIsQuitting = false;
	/// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy()
	{
		sm_applicationIsQuitting = true;
	}
}
