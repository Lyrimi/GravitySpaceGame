using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GavityManager : MonoBehaviour
{
    InputAction PointAction;

    [SerializeField] private float GravityStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PointAction = InputSystem.actions.FindAction("Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the graivty

        Vector2 point = PointAction.ReadValue<Vector2>();

        Vector2 ScreenPoint = Camera.main.ScreenToWorldPoint(point);

        Vector2 Gravity = ScreenPoint.normalized;

        Physics2D.gravity = Gravity * GravityStrength;
    }
}
