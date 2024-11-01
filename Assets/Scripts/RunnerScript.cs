using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RunnerScript : MonoBehaviour
{
    public GameObject firstRunner;
    public GameObject secondRunner;
    public GameObject thirdRunner;
    public GameObject quaterRunner;
    public GameObject baton1;
    public GameObject baton2;
    public GameObject baton3;
    public GameObject baton4;

    public Vector3[] waypoints = new Vector3[]
    {
       new  Vector3(0.419999987f,0,4.03999996f),
       new  Vector3(9.68999958f,0f,-9.61999989f),
       new  Vector3(-8.35000038f,0f,-6.44000006f),
       new  Vector3(-8.05000019f,0,-10.1800003f),
       new  Vector3(-17.1499996f,0f,3.6400001f),
       new  Vector3(-7.26000023f,0,11.9300003f),
       new  Vector3(-8.9024353f,0f,13.8566561f),
       new  Vector3(26.1000004f,0,11.9300003f)
    };

    private bool _waypoint1 = true;
    private bool _waypoint2 = false;
    private bool _waypoint3 = false;
    private bool _waypoint4 = false;
    private bool _waypoint5 = false;
    private bool _waypoint6 = false;
    private bool _waypoint7 = false;

    private bool _forward = true;
    private bool _firstRunner = true;
    private bool _secondRunner = false;
    private bool _thirdRunner = false;
    private bool _quaterRunner = false;

    [SerializeField] float speed = 0.0001f;
    [SerializeField] float distance;

    private void Update()
    {
        FirstRunner();
        SecondRunner();
        ThirdRunner();
        QuaterRunner();
    }
    public void FirstRunner()
    {
        if (_forward && _firstRunner == true && _waypoint1 == true)
        {            
            firstRunner.transform.position = Vector3.MoveTowards(firstRunner.transform.position, waypoints[1], speed);
            baton1.SetActive(true);
            if (firstRunner.transform.position == waypoints[1])
            {
                _waypoint1 = !_waypoint1;
                _waypoint2 = !_waypoint2;
                firstRunner.transform.LookAt(secondRunner.transform.position);
            }

        }
        else if (_forward == false && _firstRunner == true && _waypoint2 == true)
        {
            firstRunner.transform.position = Vector3.MoveTowards(firstRunner.transform.position, waypoints[1], speed);
            if (firstRunner.transform.position == waypoints[1])
            {
                _waypoint1 = !_waypoint1;
                _waypoint2 = !_waypoint2;
                firstRunner.transform.LookAt(waypoints[0]);
            }
        }
        if (_forward && _firstRunner == true && _waypoint2 == true)
        {
            distance = Vector3.Distance(firstRunner.transform.position, secondRunner.transform.position);
            //firstRunner.transform.LookAt(secondRunner.transform.position);
            firstRunner.transform.position = Vector3.MoveTowards(firstRunner.transform.position, secondRunner.transform.position, speed);
            if (distance < 1)
            {
                baton1.SetActive(false);
                baton2.SetActive(true);
                _waypoint2 = !_waypoint2;
                _firstRunner = !_firstRunner;
                _secondRunner = !_secondRunner;
                _waypoint3 = !_waypoint3;
                secondRunner.transform.LookAt(waypoints[3]);
            }
        }
        else if (_forward == false && _firstRunner == true && _waypoint1 == true)
        {
            distance = Vector3.Distance(firstRunner.transform.position, waypoints[0]);
            firstRunner.transform.position = Vector3.MoveTowards(firstRunner.transform.position, waypoints[0], speed);
            if (distance < 1)
            {
                _forward = !_forward;
                firstRunner.transform.LookAt(waypoints[1]);
            }
        }
    }
    public void SecondRunner()
    {
        if (_forward && _secondRunner == true && _waypoint3 == true)
        {
            //firstRunner.transform.LookAt(waypoints[1]);
            secondRunner.transform.position = Vector3.MoveTowards(secondRunner.transform.position, waypoints[3], speed);
            if (secondRunner.transform.position == waypoints[3])
            {
                _waypoint3 = !_waypoint3;
                _waypoint4 = !_waypoint4;
                secondRunner.transform.LookAt(thirdRunner.transform.position);
            }
        }
        else if (_forward == false && _secondRunner == true && _waypoint3 == true)
        {
            distance = Vector3.Distance(secondRunner.transform.position, firstRunner.transform.position);
            secondRunner.transform.position = Vector3.MoveTowards(secondRunner.transform.position, firstRunner.transform.position, speed);
            if (distance < 1)
            {
                baton2.SetActive(false);
                baton1.SetActive(true);
                _waypoint3 = !_waypoint3;
                _secondRunner = !_secondRunner;
                _firstRunner = !_firstRunner;
                _waypoint2 = !_waypoint2;
                firstRunner.transform.LookAt(waypoints[1]);
            }
        }
        if (_forward && secondRunner == true && _waypoint4 == true)
        {
            distance = Vector3.Distance(secondRunner.transform.position, thirdRunner.transform.position);
            secondRunner.transform.position = Vector3.MoveTowards(secondRunner.transform.position, thirdRunner.transform.position, speed);
            if (distance < 1)
            {
                baton2.SetActive(false);
                baton3.SetActive(true);
                _waypoint4 = !_waypoint4;
                _secondRunner = !_secondRunner;
                _thirdRunner = !_thirdRunner;
                _waypoint5 = !_waypoint5;
                thirdRunner.transform.LookAt(waypoints[5]);
            }
        }
        else if (_forward == false && secondRunner == true && _waypoint4 == true)
        {
            secondRunner.transform.position = Vector3.MoveTowards(secondRunner.transform.position, waypoints[3], speed);
            if (secondRunner.transform.position == waypoints[3])
            {
                _waypoint3 = !_waypoint3;
                _waypoint4 = !_waypoint4;
                secondRunner.transform.LookAt(firstRunner.transform.position);
            }
        }
    }
    public void ThirdRunner()
    {
        if (_forward == true && _thirdRunner == true && _waypoint5 == true)
        {
            //firstRunner.transform.LookAt(waypoints[1]);
            thirdRunner.transform.position = Vector3.MoveTowards(thirdRunner.transform.position, waypoints[5], speed);
            if (thirdRunner.transform.position == waypoints[5])
            {
                _waypoint5 = !_waypoint5;
                _waypoint6 = !_waypoint6;
                thirdRunner.transform.LookAt(quaterRunner.transform.position);
            }
        }
        if (_forward && _thirdRunner == true && _waypoint6 == true)
        {
            distance = Vector3.Distance(thirdRunner.transform.position, quaterRunner.transform.position);
            //firstRunner.transform.LookAt(secondRunner.transform.position);
            thirdRunner.transform.position = Vector3.MoveTowards(thirdRunner.transform.position, quaterRunner.transform.position, speed);
            if (distance < 1)
            {
                baton3.SetActive(false);
                baton4.SetActive(true);
                _waypoint6 = !_waypoint6;
                _thirdRunner = !_thirdRunner;
                _quaterRunner = !_quaterRunner;
                _waypoint7 = !_waypoint7;
                quaterRunner.transform.LookAt(waypoints[7]);
            }
        }
        else if (_forward == false && _thirdRunner == true && _waypoint6 == true)
        {
            thirdRunner.transform.position = Vector3.MoveTowards(thirdRunner.transform.position, waypoints[5], speed);
            if (thirdRunner.transform.position == waypoints[5])
            {
                _waypoint6 = !_waypoint6;
                _waypoint5 = !_waypoint5;
                thirdRunner.transform.LookAt(secondRunner.transform.position);
            }
        }
        if (_forward == false && _thirdRunner == true && _waypoint5 == true)
        {
            distance = Vector3.Distance(thirdRunner.transform.position, secondRunner.transform.position);
            thirdRunner.transform.position = Vector3.MoveTowards(thirdRunner.transform.position, secondRunner.transform.position, speed);
            if (distance < 1)
            {
                baton3.SetActive(false);
                baton2.SetActive(true);
                _waypoint5 = !_waypoint5;
                _secondRunner = !_secondRunner;
                _thirdRunner = !_thirdRunner;
                _waypoint4 = !_waypoint4;
                secondRunner.transform.LookAt(waypoints[3]);

            }
        }
    }
    public void QuaterRunner()
    {
        if (_forward && _quaterRunner == true && _waypoint7 == true)
        {
            //firstRunner.transform.LookAt(waypoints[1]);
            quaterRunner.transform.position = Vector3.MoveTowards(quaterRunner.transform.position, waypoints[7], speed);
            if (quaterRunner.transform.position == waypoints[7])
            {
                quaterRunner.transform.LookAt(thirdRunner.transform.position);
                _forward = !_forward;
            }
        }
        else if (_forward == false && _quaterRunner == true && _waypoint7 == true)
        {
            distance = Vector3.Distance(quaterRunner.transform.position, thirdRunner.transform.position);
            quaterRunner.transform.position = Vector3.MoveTowards(quaterRunner.transform.position, thirdRunner.transform.position, speed);
            if (distance < 1)
            {
                baton4.SetActive(false);
                baton3.SetActive(true);
                _waypoint6 = !_waypoint6;
                _thirdRunner = !_thirdRunner;
                _quaterRunner = !_quaterRunner;
                _waypoint7 = !_waypoint7;
                thirdRunner.transform.LookAt(waypoints[5]);
            }
        }
    }
}
