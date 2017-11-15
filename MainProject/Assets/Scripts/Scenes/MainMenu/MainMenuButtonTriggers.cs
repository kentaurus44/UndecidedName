using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonTriggers : MonoBehaviour
{
    public void GoPlay()
    {
        FlowManager.Instance.GoTo(Scenes.GAME_SCENE);
    }
}
