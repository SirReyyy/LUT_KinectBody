using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ModelScript : MonoBehaviour
{
    [Tooltip("Camera used for screen-to-world calculations. This is usually the main camera.")]
    public Camera screenCamera;

    [Tooltip("List of the model gradients.")]
    public List<Gradient> gradientList;

    private ModelGestureListener gestureListener;
    public VisualEffect vfxParticle;

    private int maxGradient = 0;
    private int gradient = 0;

    private bool isChanging = false;
    private bool changeWithGesture = true;
    private float vfxBuff = 0;


    void Start() {
        // by default set the main-camera to be screen-camera
        if (screenCamera == null) {
            screenCamera = Camera.main;
        }

        // vfxParticle = GetComponent<VisualEffect>();
        maxGradient = gradientList.Count;
        gradient = 0;

        // get the gestures listener
        gestureListener = ModelGestureListener.Instance;
    }


    private void Update() {
        if(!gestureListener)
            return;

        if(!isChanging) {
            if (changeWithGesture && gestureListener) {
                if (gestureListener.IsSwipeLeft())
                    GradientLeft();
                else if (gestureListener.IsSwipeRight())
                    GradientRight();
            }
        } else {
            if(vfxBuff > 0) {
                vfxBuff -= Time.deltaTime;
            } else {
                isChanging = false;
            }
        }
    }


    private void GradientLeft() {
        // gradient = (gradient + 1) % maxGradient;
        
        isChanging = true;
        vfxBuff = 5.0f;

        Debug.Log("Left");
    }

    private void GradientRight()
    {
        // gradient = (gradient + 1) % maxGradient;
        
        isChanging = true;
        vfxBuff = 5.0f;

        Debug.Log("Right");
    }

} //-- class end


/*
Project: 
Made by: 
*/

