//
// Script name: InventoryDisplay.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class InventoryDisplay : MonoBehaviour
{
    #region Variables
    [SerializeField] protected Text m_Text;
    
    [Multiline]
    [SerializeField] protected string m_DefaultText;
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public void Display(InventoryItem item)
    {
        m_Text.text = item.name;
    }

    public void Reset()
    {
        m_Text.text = m_DefaultText;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}