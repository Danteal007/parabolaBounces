using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    public string initDir = Directory.GetCurrentDirectory() + "\\Assets\\Resources\\ball_path";
    public string[] ballpath = new string[] { ".json", "2.json", "3.json", "4.json" };

    public BallPath[] path = new BallPath[4];

    public GameObject[] balls;

    public Slider slider; 

    public bool allFilesReaded = false;

    public int activeBallIndex = 0;

    public float activeBallSpeed;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            StreamReader str = new StreamReader(initDir+ballpath[i], Encoding.Default);
            while (!str.EndOfStream)
            {
                string st = str.ReadToEnd();
                path[i] = (BallPath)JsonUtility.FromJson(st, typeof(BallPath)); 
            } 
        }
        allFilesReaded = true;
        foreach (GameObject ball in balls)
        {
            ball.GetComponent<Ball>().Ready();
        }
        
    }
    
    void Update()
    {
        balls[activeBallIndex].GetComponent<Ball>().speed = slider.value;
        activeBallSpeed = balls[activeBallIndex].GetComponent<Ball>().speed;//transform.position = new Vector3(balls[activeBallIndex].transform.position.x - 8f, balls[activeBallIndex].transform.position.y + 3f, balls[activeBallIndex].transform.position.z + 3.5f);
    }
}

public class BallPath
{
    public float[] x;
    public float[] y;
    public float[] z;
}
