using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    protected float m_moveSpeed = 2.0f;

    protected virtual void Update()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
        Vector3 targetPos = transform.position + move;
        Move(targetPos);
    }

    protected virtual void Move(Vector3 targetPos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * m_moveSpeed);
    }
}