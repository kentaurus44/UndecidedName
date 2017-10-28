//
// Script name: PlayerController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : SubjectObserver
{
    #region Variables
    private Dictionary<PlayereStaticInputController.eDirection, Vector3> DIRECTION_CONVERT = new Dictionary<PlayereStaticInputController.eDirection, Vector3>()
    {
        {PlayereStaticInputController.eDirection.NORTH, Vector3.up },
        {PlayereStaticInputController.eDirection.NORTH_EAST, (Vector3.up + Vector3.right).normalized },
        {PlayereStaticInputController.eDirection.EAST, Vector3.right },
        {PlayereStaticInputController.eDirection.SOUTH_EAST, (Vector3.down + Vector3.right).normalized},
        {PlayereStaticInputController.eDirection.SOUTH, Vector3.down },
        {PlayereStaticInputController.eDirection.SOUTH_WEST, (Vector3.left + Vector3.down).normalized },
        {PlayereStaticInputController.eDirection.WEST, Vector3.left},
        {PlayereStaticInputController.eDirection.NORTH_WEST, (Vector3.left + Vector3.up).normalized }

    };

    [SerializeField] protected float m_Velocity = 50f;
    [SerializeField] protected BoxCollider m_BoxCollider;
	private Vector3 m_Direction;

    public BoxCollider BoxCollider
    {
        get { return m_BoxCollider; }
    }
    #endregion

    #region Unity API
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (m_Direction.normalized * 150f));
    }
    #endregion

    #region Public
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void Move()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = new Vector3(0f, m_Direction.y, 0f).normalized;
        bool isHittingVertical = Physics.Raycast(ray, m_BoxCollider.size.y / 2f, LayerMask.NameToLayer("UI"));
        if (isHittingVertical)
        {
            m_Direction.y = 0f;
        }

        ray.direction = new Vector3(m_Direction.x, 0f, 0f).normalized;
        bool isHittingHorizontal = Physics.Raycast(ray, m_BoxCollider.size.y / 2f, LayerMask.NameToLayer("UI"));
        if (isHittingHorizontal)
        {
            m_Direction.x = 0f;
        }

        transform.position += m_Direction * m_Velocity * Time.deltaTime;
    }

    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
	{
		base.OnNotify(subject, args);
        if (args[0] is sNotification)
        {
            if (subject is PlayereStaticInputController)
            {
                sNotification sNotify = (sNotification)args[0];

                if (sNotify.args.Length > 0)
                {
                    if (sNotify.args[0] is PlayereStaticInputController.eDirection)
                    {
                        PlayereStaticInputController.eDirection eDir = (PlayereStaticInputController.eDirection)sNotify.args[0];
                        m_Direction = DIRECTION_CONVERT[eDir];
                        Move();
                    }
                }
            }
        }
    }
	#endregion
}