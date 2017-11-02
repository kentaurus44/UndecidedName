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
    private PlayereStaticInputController.eDirection m_Facing;

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
        Vector3 futurePosition = transform.position + m_Direction * m_Velocity * Time.deltaTime;

        RaycastHit[] hits = Physics.BoxCastAll(transform.position, m_BoxCollider.size / 4f, new Vector3(m_Direction.x, 0f, 0f).normalized, Quaternion.identity, m_BoxCollider.size.x / 4f + 5f, LayerMask.NameToLayer("UI"));

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform.gameObject != gameObject)
            {
                if (futurePosition.x > transform.position.x)
                {
                    futurePosition.x = hits[i].point.x - m_BoxCollider.size.x / 2f;
                }
                else if (futurePosition.x < transform.position.x)
                {
                    futurePosition.x = hits[i].point.x + m_BoxCollider.size.x / 2f;
                }
                break;
            }
        }

        hits = Physics.BoxCastAll(transform.position, m_BoxCollider.size / 4f, new Vector3(0f, m_Direction.y, 0f).normalized, Quaternion.identity, m_BoxCollider.size.y / 4f + 5f, LayerMask.NameToLayer("UI"));

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform.gameObject != gameObject)
            {
                if (futurePosition.y > transform.position.y)
                {
                    futurePosition.y = hits[i].point.y - m_BoxCollider.size.y / 2f;
                }
                else if (futurePosition.y < transform.position.y)
                {
                    futurePosition.y = hits[i].point.y + m_BoxCollider.size.y / 2f;
                }
                break;
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
            distance = m_BoxCollider.size.x / 2f;
        }
        else
        {
            distance = m_BoxCollider.size.y / 2f;
        }
        distance += 1f;

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