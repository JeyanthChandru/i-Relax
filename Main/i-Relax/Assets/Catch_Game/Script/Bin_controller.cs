﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TETCSharpClient;
using TETCSharpClient.Data;
using Assets.Scripts;

public class Bin_controller : MonoBehaviour, IGazeListener {

    public Camera cam;

    private float maxWidth;
    private bool canControl;
    private GazeDataValidator gazeUtils;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - hatWidth;
        canControl = false;
        gazeUtils = new GazeDataValidator(30);
        GazeManager.Instance.AddGazeListener(this);

    }

    public void OnApplicationQuit()
    {
        GazeManager.Instance.CalibrationAbort();
        GazeManager.Instance.RemoveGazeListener(this);
        GazeManager.Instance.Deactivate();
    }

    public void OnGazeUpdate(GazeData gazeData)
    {
        //Add frame to GazeData cache handler
        gazeUtils.Update(gazeData);
    }

    // Update is called once per physics timestep
    void FixedUpdate()
    {
        Point2D gazeCoords = gazeUtils.GetLastValidSmoothedGazeCoordinates();

        if (canControl && null != gazeCoords)
        {
            Point2D gp = UnityGazeUtils.getGazeCoordsToUnityWindowCoords(gazeCoords);
            Vector3 screenPoint = new Vector3((float)gp.X, (float)gp.Y, cam.nearClipPlane + .1f);
            Vector3 rawPosition = cam.ScreenToWorldPoint(screenPoint);
            Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
            GetComponent<Rigidbody2D>().MovePosition(targetPosition);
        }
    }

    public void ToggleControl(bool toggle)
    {
        canControl = toggle;
    }
}
