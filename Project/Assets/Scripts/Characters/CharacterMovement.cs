using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour 
{
	NavMeshAgent navMeshAgent;

	bool walking;

	float m_speed = 6f;

	Vector3 m_movement;

	Rigidbody m_rigidBody;

	Vector3 m_targetPosition;
	Vector3 m_hitPoint;

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(m_targetPosition, 0.25f);
	}

	void Start()
	{
		m_rigidBody = GetComponent<Rigidbody>();
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Update () 
	{
//		if(Input.GetKey(KeyCode.W))
//		{
//			transform.position += CopyCamera.Instance.transform.forward * Time.deltaTime * m_speed;
//		}
//
//		if(Input.GetKey(KeyCode.D))
//		{
//			transform.position += CopyCamera.Instance.transform.right * Time.deltaTime * m_speed;
//		}

		if(Input.GetMouseButton(1))
		{
			walking = true;
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
			{
				m_hitPoint = hit.point;
			}
		}
		else
		{
			navMeshAgent.ResetPath();
			walking = false;
		}

		MoveAndShoot();

//		float h = Input.GetAxisRaw("Horizontal");
//		float v = Input.GetAxisRaw("Vertical");
//		Move(h, v);
	}

	void MoveAndShoot()
	{
		if(!walking)
			return;

		navMeshAgent.destination = m_hitPoint;
		if (navMeshAgent.remainingDistance >= 0.1f) 
		{	
			navMeshAgent.Resume();
			walking = true;
		}
		
//		if (navMeshAgent.remainingDistance <= shootDistance) {
//			
//			transform.LookAt(targetedEnemy);
//			Vector3 dirToShoot = targetedEnemy.transform.position - transform.position;
//			if (Time.time > nextFire)
//			{
//				nextFire = Time.time + shootRate;
//				shootingScript.Shoot(dirToShoot);
//			}
//			navMeshAgent.Stop();
//			walking = false;
//		}
	}
}
