//
// Script name: StaticInputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using TouchAction;
using System.Collections;


public class StaticInputController : DirectionalInputController
{
    #region Variables
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public override void Init()
    {
        base.Init();
        m_CenterPosition = transform.position;
    }
    #endregion

    #region Protected Methods
    protected override void SetAngle(Vector3 target)
    {
        base.SetAngle(target);
        m_TargetPosition = target;
    }
    #endregion

    #region Private Methods
    #endregion
}