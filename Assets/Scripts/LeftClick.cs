using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftClick : MonoBehaviour
{
    public GameObject mainCamera;
    public Slider slider;

    private MainCamera mCamera;

    private void Start()
    {
        mCamera = mainCamera.GetComponent<MainCamera>();
    }
    public void OnMouseDown()
    {
        Debug.Log("Left Click");
        if(mCamera.activeBallIndex > 0)
        {
            mCamera.activeBallIndex--;
        }
        else
        {
            mCamera.activeBallIndex = 3;
        }
        slider.value = mCamera.balls[mCamera.activeBallIndex].GetComponent<Ball>().speed;
    }
   
}
