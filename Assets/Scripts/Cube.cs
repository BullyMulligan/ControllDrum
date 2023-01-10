using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cube : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    private float _speed =100;

    private bool _cubeIsActive = true;
    private bool _cubeIsForward=true;
   
    //метод при нажатии кнопки старт
    public void PressButtonStart()
    {
        //если мотор не активен
        if (!_cubeIsActive && !_cubeIsForward)
        {
            SetSpeed(-_speed);
            _cubeIsActive = true;
            _cubeIsForward = false;
        }

        if (!_cubeIsActive && _cubeIsForward)
        {
            SetSpeed(_speed);
            _cubeIsActive = true;
            _cubeIsForward = true;
        }
        
    }
    //метод при нажатии кнопки назад
    public void PressButtonBack()
    {
        if (_cubeIsActive && _cubeIsForward)
        {
            SetSpeed(-_speed);
            _cubeIsForward = false;
            return;
        }

        if (_cubeIsActive && !_cubeIsForward)
        {
            SetSpeed(_speed);
            _cubeIsForward = true;
            return;
        }

        if (!_cubeIsActive)
        {
            if (_cubeIsForward)
            {
                _cubeIsForward = false;
            }
            else
            {
                _cubeIsForward = true;
            }
        }
    } 
    //при нажатии на кнопку стоп
    public void PressButtonStop()
    {
        SetSpeed(0);//скорость равна 0
        _cubeIsActive = false;//статус неактивный
    }
    
    private void SetSpeed(float speed)
    {
        var joinMotor = _hingeJoint.motor;
        joinMotor.targetVelocity = speed;
        _hingeJoint.motor = joinMotor;
    }
}