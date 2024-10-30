using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Figure1MovementScript : MonoBehaviour
{
    public GameObject figure1;
    public GameObject figure2;
    public Vector3[] route = new Vector3[]
    {
        new Vector3(5,0,0),
        new Vector3(10,0,0)
    };
    private bool _forward = true;
    private bool _nextRunner = false;
    private float _passDistance;
    [SerializeField] private float speed = 0.001f;

    void Update()
    {
        _passDistance = Vector2.Distance(figure1.transform.position, figure2.transform.position);
        if (_forward)
        {
            figure1.transform.position = Vector3.MoveTowards(figure1.transform.position, route[0], speed);
           
            if (_passDistance <= 0.5 && _forward == true)
            {
                _nextRunner = true;
            }
            if (_nextRunner == true)
            {
                figure2.transform.position = Vector3.MoveTowards(figure2.transform.position, route[1], speed);
                if (figure2.transform.position == route[1])
                {
                    _forward = !_forward;
                }
            }
        }
        else
        {
            figure2.transform.position = Vector3.MoveTowards(figure2.transform.position, route[0], speed);
            if (_passDistance <= 0.5 && _forward == false)
            {
                _nextRunner = false;
            }
            if (_nextRunner == false)
            {
                //Debug.Log("+");
                Vector3 start = new Vector3(0, 0, 0);
                figure1.transform.position = Vector3.MoveTowards(figure1.transform.position, start, speed);
                if (figure1.transform.position == start)
                {
                    _forward = !_forward;
                }
            }
        }
    }
}
