using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject mainCamera;
    public Slider slider;
    BallPath path;
    public int pathIndex = 0;
    public int dir = 1;
    public int ballNumber;
    public float speed = 1;
    public bool isMouseClicked = false;

    private float firstClick = 0;

    void Update()
    {
        if (isMouseClicked)
        {
            StartCoroutine(Move(pathIndex));
        }
        if(transform.position == new Vector3(path.x[pathIndex], path.y[pathIndex], path.z[pathIndex]))
        {
            pathIndex += dir;
        }
        if(pathIndex > path.x.Length - 1)
        {
            pathIndex = path.x.Length - 1;
        }
        if(pathIndex < 0)
        {
            pathIndex = 0;
        }
        switch (dir)
        {
            case 1:
                if (transform.position == new Vector3(path.x[path.x.Length-1], path.y[path.x.Length - 1], path.z[path.x.Length - 1]))
                {
                    dir = -dir;
                    isMouseClicked = false;
                }
                break;
            case -1:
                if (transform.position == new Vector3(path.x[0], path.y[0], path.z[0]))
                {
                    GetComponent<TrailRenderer>().Clear();
                    dir = -dir;
                    isMouseClicked = false;
                }
                break;
        }
    }

    public IEnumerator Move(int i)
    {
        Debug.Log("Moving started");
        if (mainCamera.GetComponent<MainCamera>().activeBallIndex == ballNumber)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(path.x[i], path.y[i], path.z[i]), Time.deltaTime * speed * 5);
        }
        while(transform.position != new Vector3(path.x[i], path.y[i], path.z[i]))
        {
            Debug.Log("Moving");
            yield return null;
        }
        Debug.Log(pathIndex);
        
    }

    public void Ready()
    {
        path = mainCamera.GetComponent<MainCamera>().path[ballNumber];
        transform.position = new Vector3(path.x[0], path.y[0], path.z[0]);
        GetComponent<TrailRenderer>().Clear();
    }

    private void OnMouseDown()
    {
        if (Time.time - firstClick < 0.5f) {
            isMouseClicked = false;
            transform.position = new Vector3(path.x[0], path.y[0], path.z[0]);
            dir = 1;
            firstClick = 0;
            GetComponent<TrailRenderer>().Clear();
        }
        else
        {
            isMouseClicked = true;
            firstClick = Time.time;
        }
        
    }

}
