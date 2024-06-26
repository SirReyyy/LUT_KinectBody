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

    private ModelGestureListener modelGestureListener;
    public VisualEffect vfxParticle;

    private int maxGradient = 0;
    private int gradientIndex = 0;
    public float transitionDuration = 2.0f;

    private int nextGradientIndex = 0;
    private float transitionTimer = 0.0f;
    private bool isTransitioning = false;

    private bool changeWithGesture = true;
    private float vfxBuff = 0;


    void Start() {
        // by default set the main-camera to be screen-camera
        if (screenCamera == null) {
            screenCamera = Camera.main;
        }

        // vfxParticle = GetComponent<VisualEffect>();
        maxGradient = gradientList.Count;
        if (vfxParticle != null && gradientList.Count > 0) {
            vfxParticle.SetGradient("Gradient", gradientList[gradientIndex]);
        }

        // get the gestures listener
        modelGestureListener = ModelGestureListener.Instance;
    } //-- Start end


    void Update() {
        if (!modelGestureListener)
            return;

        if(!isTransitioning) {
            if (changeWithGesture && modelGestureListener) {
                if (modelGestureListener.IsSwipeLeft())
                    GradientLeft();
                else if (modelGestureListener.IsSwipeRight())
                    GradientRight();
            }

        } else {
            if(vfxBuff > 0) {
                vfxBuff -= Time.deltaTime;
            } else {
                isTransitioning = false;
            }
        }

        /*
        // Handle gradient transition
        if (isTransitioning)
        {
            transitionTimer += Time.deltaTime;
            float progress = Mathf.Clamp01(transitionTimer / transitionDuration);

            // Lerp between the current gradient and the next gradient
            Gradient lerpedGradient = LerpGradient(gradientList[gradientIndex], gradientList[nextGradientIndex], progress);
            vfxParticle.SetGradient("Gradient", lerpedGradient);

            // Check if transition is complete
            if (progress >= 10.0f)
            {
                isTransitioning = false;
                gradientIndex = nextGradientIndex;
                transitionTimer = 0.0f;
            }
        }
        */
    }


    private void GradientLeft()
    {
        gradientIndex--;
        if (gradientIndex < 0)
            gradientIndex = gradientList.Count - 1;
        UpdateGradient();
    }

    private void GradientRight()
    {
        gradientIndex++;
        if (gradientIndex >= gradientList.Count)
            gradientIndex = 0;
        UpdateGradient();
    }

    void UpdateGradient()
    {
        vfxParticle.SetGradient("Gradient", gradientList[gradientIndex]);
    }



    /*
    private void GradientLeft() {
        nextGradientIndex = gradientIndex - 1;
        if (nextGradientIndex < 0)
            nextGradientIndex = gradientList.Count - 1; // Wrap around to the last gradient
        StartTransition();
    }

    private void GradientRight() {
        nextGradientIndex = (gradientIndex + 1) % gradientList.Count; // Wrap around to the first gradient
        StartTransition();
    }


    void StartTransition()
    {
        isTransitioning = true;
        transitionTimer = 0.0f;
    }

    Gradient LerpGradient(Gradient from, Gradient to, float t)
    {
        Gradient result = new Gradient();

        // Lerp between each color key
        GradientColorKey[] colorKeys = new GradientColorKey[from.colorKeys.Length];
        for (int i = 0; i < from.colorKeys.Length; i++)
        {
            colorKeys[i].color = Color.Lerp(from.colorKeys[i].color, to.colorKeys[i].color, t);
            colorKeys[i].time = Mathf.Lerp(from.colorKeys[i].time, to.colorKeys[i].time, t);
        }
        result.SetKeys(colorKeys, from.alphaKeys);

        return result;
    }
    */


} //-- class end


/*
Project: 
Made by: 
*/

