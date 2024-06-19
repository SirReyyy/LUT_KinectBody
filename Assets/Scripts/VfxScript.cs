using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Vfx : MonoBehaviour
{
    [Tooltip("Camera used for screen-to-world calculations. This is usually the main camera.")]
    public Camera screenCamera;

    [Tooltip("List of the model gradients.")]
    public List<Gradient> gradientList;

    private ModelGestureListener gestureListener;
    public VisualEffect vfxParticle;

    private int maxGradient = 0;
    private int gradient = 0;



    void Start()
    {
        // by default set the main-camera to be screen-camera
        if (screenCamera == null)
        {
            screenCamera = Camera.main;
        }

        // vfxParticle = GetComponent<VisualEffect>();
        maxGradient = gradientList.Count;
        gradient = 0;

        // get the gestures listener
        gestureListener = ModelGestureListener.Instance;
    }


    private void Update()
    {
        if (!gestureListener)
            return;

        if (gestureListener)
        {
            if (gestureListener.IsSwipeLeft())
                GradientLeft();
            else if (gestureListener.IsSwipeRight())
                GradientRight();
        }
    }


    private void GradientLeft()
    {
        // gradient = (gradient + 1) % maxGradient;

        Debug.Log("Left");
        Debug.Log(vfxParticle.name);
    }

    private void GradientRight()
    {
        // gradient = (gradient + 1) % maxGradient;

        Debug.Log("Right");
    }

} //-- class end


/*
Project: 
Made by: 
*/

