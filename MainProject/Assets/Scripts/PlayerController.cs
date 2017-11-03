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
    private const float RAYCAST_MOVING_BUFFER = 5f;
    private const float RAYCAST_INTERACT_BUFFER = 5f;
    private static readonly Dictionary<PlayereStaticInputController.eDirection, Vector3> DIRECTION_CONVERT = new Dictionary<PlayereStaticInputController.eDirection, Vector3>()
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
    private Vector3 m_RayDirection;
    private PlayereStaticInputController.eDirection m_Facing;

    public BoxCollider BoxCollider
    {
        get { return m_BoxCollider; }
    }

    public Vector3 Extent
    {
        get { return m_BoxCollider.size / 2f; }
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
        Vector3 futurePosition = transform.position + m_Direction * m_Velocity * Time.deltaTime;

        m_RayDirection.x = m_Direction.x;
        m_RayDirection.y = 0f;
        m_RayDirection.z = 0f;
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, Extent / 2f, m_RayDirection.normalized, Quaternion.identity, Extent.x / 2f + RAYCAST_MOVING_BUFFER, LayerMask.NameToLayer("UI"));

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform.gameObject != gameObject)
            {
                if (futurePosition.x > transform.position.x)
                {
                    futurePosition.x = hits[i].point.x - Extent.x;
                }
                else if (futurePosition.x < transform.position.x)
                {
                    futurePosition.x = hits[i].point.x + Extent.x;
                }
                break; // breaking because we only care about the first one hit
            }
        }

        m_RayDirection.x = 0f;
        m_RayDirection.y = m_Direction.y;
        m_RayDirection.z = 0f;
        hits = Physics.BoxCastAll(transform.position, Extent / 2f, m_RayDirection.normalized, Quaternion.identity, Extent.y / 2f + RAYCAST_MOVING_BUFFER, LayerMask.NameToLayer("UI"));

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform.gameObject != gameObject)
            {
                if (futurePosition.y > transform.position.y)
                {
                    futurePosition.y = hits[i].point.y - Extent.y;
                }
                else if (futurePosition.y < transform.position.y)
                {
                    futurePosition.y = hits[i].point.y + Extent.y;
                }
                break; // breaking because we only care about the first one hit
            }
        }

        transform.position = futurePosition;
    }

    private void Interact()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = DIRECTION_CONVERT[m_Facing];
        float distance;

        if (m_Facing == PlayereStaticInputController.eDirection.EAST || m_Facing == PlayereStaticInputController.eDirection.WEST)
        {
            distance = Extent.x;
        }
        else
        {
            distance = Extent.y;
        }
        distance += RAYCAST_INTERACT_BUFFER;

        RaycastHit[] hits = Physics.RaycastAll(ray, distance);

        RaycastHit hit;
        IInteractable interactable = null;
        for (int i = 0; i < hits.Length; ++i)
        {
            hit = hits[i];
            interactable = hit.transform.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
	{
		base.OnNotify(subject, args);
        if (args[0] is sNotification)
        {
            sNotification sNotify = (sNotification)args[0];

            if (sNotify.args.Length > 0)
            {
                if (subject is PlayereStaticInputController)
                {
                    if (sNotify.args[0] is PlayereStaticInputController.eDirection)
                    {
                        PlayereStaticInputController.eDirection eDir = (PlayereStaticInputController.eDirection)sNotify.args[0];
                        m_Direction = DIRECTION_CONVERT[eDir];
                        m_Facing = (PlayereStaticInputController.eDirection)sNotify.args[2];
                        Move();
                    }
                }
                else if (subject is PlayerActionController)
                {
                    if (sNotify.key.CompareTo(PlayerActionController.ON_ACTION_PERFORMED) == 0 && 
                        sNotify.args[0] is PlayerActionController.eAction)
                    {
                        PlayerActionController.eAction eAction = (PlayerActionController.eAction)sNotify.args[0];

                        switch (eAction)
                        {
                            case PlayerActionController.eAction.INTERACT:
                                Interact();
                                break;
                        }

                    }
                }
            }
        }
    }
	#endregion
}