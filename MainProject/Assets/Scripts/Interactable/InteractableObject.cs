//
// Script name: InteractableObject.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class InteractableObject : MonoBehaviour, IInteractable
{
    #region Variables
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public virtual void Interact()
    {
        Debug.Log("I am a wall");
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}