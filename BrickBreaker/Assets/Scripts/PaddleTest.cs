using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaddleTest : MonoBehaviour {

    public DOTweenPath bat;
    public List<Vector3> points;
    public List<GameObject> PointsObjects;
    public bool isMovingForward;

    public Ball ball;
    private Vector3 StartPosition;
    void Start()
    {
        bat = this.GetComponent<DOTweenPath>();
        StartPosition = this.transform.position;
        points = bat.wps;
        PontsCreater();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.hasStarted == true)
        {
            Movement();
            RotationContoller();
        }
       

        //if (points[0] == this.transform.position)
        //{
        //    if (isMovingForward)
        //    {
        //        Debug.Log("rotale forward");
        //    }
        //    else
        //    {
        //        Debug.Log("rotate backword");
        //    }
        //}

        
    }


    void Movement()
    {
        //forward
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (StartPosition == this.transform.position)
            {
                bat.DORestart();
            }
            bat.DOPlayForward();
            isMovingForward = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            bat.DOPause();
        }


        //Backward
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (StartPosition == this.transform.position)
            {
                bat.DOComplete();
            }
            bat.DOPlayBackwards();
            isMovingForward = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            bat.DOPause();
        }
    }
    void PontsCreater()
    {
        int i = 0;
        foreach (Vector3 point in points)
        {
            GameObject temp = new GameObject("Point" + i);
            temp.transform.position = point;
            BoxCollider2D tempCollider=temp.AddComponent<BoxCollider2D>();
            tempCollider.isTrigger = true;
            temp.layer = LayerMask.NameToLayer("PointCollision");
            Debug.Log(temp.layer);
            temp.AddComponent<Point>();
            PointsObjects.Add(temp);
            i++;
        }
    }

    void RotationContoller()
    {
        if (isMovingForward)
        {
            if (PointsObjects[0].GetComponent<Point>().triggered == true)
            {

                transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (PointsObjects[1].GetComponent<Point>().triggered == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else if (PointsObjects[2].GetComponent<Point>().triggered == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else if (PointsObjects[3].GetComponent<Point>().triggered == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            if (PointsObjects[0].GetComponent<Point>().triggered == true)
            {

                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (PointsObjects[1].GetComponent<Point>().triggered == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (PointsObjects[2].GetComponent<Point>().triggered == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else if (PointsObjects[3].GetComponent<Point>().triggered == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
        }
    }
}
