using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;
    public float minY, maxY;
    public int section;
    public  Vector2  mousePosRevToCenter;
    public Transform center;
    public Transform Orantation;
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
		
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
            CalculateMousePosRevToCenter();
            CalculateSection();
            iDontKnowWhatToCAll();
          // MoveWithMouse();
		} else {
            
            AutoPlay();
		}
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse () {
      //  Debug.Log(Input.mousePosition.x / Screen.width * 16 + ":" + Input.mousePosition.y / Screen.height * 12);
        Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}

    void MoveAlongXWithMouse()
    {
        //  Debug.Log(Input.mousePosition.x / Screen.width * 16 + ":" + Input.mousePosition.y / Screen.height * 12);
      // Orantation.rotation  == new Vector3(0,0,180);
        Vector3 paddlePos = new Vector3(0.5f, 12, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }
    void MoveAlongNXWithMouse()
    {
        //  Debug.Log(Input.mousePosition.x / Screen.width * 16 + ":" + Input.mousePosition.y / Screen.height * 12);
        Vector3 paddlePos = new Vector3(0.5f, 0.5f, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }
    void MoveAlongYWithMouse()
    {
        //  Debug.Log(Input.mousePosition.x / Screen.width * 16 + ":" + Input.mousePosition.y / Screen.height * 12);
        Vector3 paddlePos = new Vector3(16, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.y / Screen.height * 12;
        paddlePos.y = Mathf.Clamp(mousePosInBlocks, minY, maxY);
        this.transform.position = paddlePos;
    }
    void MoveAlongNYWithMouse()
    {
        //  Debug.Log(Input.mousePosition.x / Screen.width * 16 + ":" + Input.mousePosition.y / Screen.height * 12);
        Vector3 paddlePos = new Vector3(0, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.y / Screen.height * 12;
        paddlePos.y = Mathf.Clamp(mousePosInBlocks, minY, maxY);
        this.transform.position = paddlePos;
    }
    void CalculateMousePosRevToCenter()
    {
        mousePosRevToCenter.x=  Input.mousePosition.x / Screen.width * 16- center.position.x;
        mousePosRevToCenter.y =   Input.mousePosition.y / Screen.height * 12- center.position.y;
        Debug.Log(mousePosRevToCenter);

      

    }
    void CalculateSection()
    {
        if (mousePosRevToCenter.x > 0 && mousePosRevToCenter.y > 0)
        {
            section = 1;

        }
        else if (mousePosRevToCenter.x < 0 && mousePosRevToCenter.y > 0)
        {
            section = 2;
        }
        else if (mousePosRevToCenter.x < 0 && mousePosRevToCenter.y < 0)
        {
            section = 3;
        }
        else if (mousePosRevToCenter.x > 0 && mousePosRevToCenter.y < 0)
        {
            section = 4;
        }


    }
    bool isXGreaterThanY()
    {
        if (Mathf.Abs(mousePosRevToCenter.x) > Mathf.Abs(mousePosRevToCenter.y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void iDontKnowWhatToCAll()
    {
        if (section == 1)
        {
            if (isXGreaterThanY())
            {
                MoveAlongYWithMouse();
            }
            else
            {
                MoveAlongXWithMouse();
            }
        }
        else if (section == 2)
        {
            if (isXGreaterThanY())
            {
                MoveAlongNYWithMouse();
            }
            else
            {
                MoveAlongXWithMouse();
            }

        }
        else if (section == 3)
        {

            if (isXGreaterThanY())
            {
                MoveAlongNYWithMouse();
            }
            else
            {
                MoveAlongNXWithMouse();
            }
        }
        else if (section == 4)
        {
            if (isXGreaterThanY())
            {
                MoveAlongYWithMouse();
            }
            else
            {
                MoveAlongNXWithMouse();
            }
        }

    }
}
