using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject Bricks;
    public float Speed = 20;
    public float increaseSpeedBy = 5;
    public float SpeedIncrementInterval=10;
    public bool IsBrickRotating = false;

    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate GameManagerself-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

        Bricks = GameObject.FindGameObjectWithTag("LevelBricks");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBrickRotating)
        {
            BricksRotation();
        }

    }
    public void BricksRotation()
    {
        Bricks.transform.Rotate(new Vector3(0, 0, 1) * Speed * Time.deltaTime);
    
    }

    public void RotateBricks()
    {
        if (!IsBrickRotating)
        {
            IsBrickRotating = true;
            // Debug.Log("rotationCalled");
            // InvokeRepeating("BricksRotation", 0f, 0.1f);
        }
        else
        {
            Speed += increaseSpeedBy;
        }


    }

}
