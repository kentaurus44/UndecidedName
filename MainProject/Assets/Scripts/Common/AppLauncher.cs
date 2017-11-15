using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    protected void Awake()
    {
        InitCameraManager();
        InitFlowManager();
    }

    private void InitFlowManager()
    {
        FlowManager.Instance.Init();
        FlowManager.Instance.GoTo(Scenes.MAIN_MENU);
    }

    private void InitCameraManager()
    {
        CustomCamera.CameraManager.Instance.Init();
    }
}
