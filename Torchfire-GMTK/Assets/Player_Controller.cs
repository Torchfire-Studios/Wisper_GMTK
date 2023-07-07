using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Script made by Konner Pierce 
    // Code tutorial from https://www.youtube.com/watch?v=8ZxVBCvJDWk&ab_channel=Tarodev 
    // Modified further from github thread comments https://gist.github.com/Matthew-J-Spencer/32b69cfc71446a9af0d697be2cee585d 
    // Then modified further by me to fit and fix moving faster when pressing 2 keys down issue
    // Comments added by Chat GPT

    [SerializeField] private Rigidbody _rb; 
    [SerializeField] private float _speed = 5; // Movement speed of the player
    [SerializeField] private float _turnSpeed = 360; // Rotation speed of the player
    private Vector3 _input; // Input vector for movement
    [SerializeField] private Transform _model; // Reference to the player model's Transform

    private void Update()
    {
        GatherInput(); 
        Look(); // Rotate the player model based on the input direction
    }

    private void FixedUpdate()
    {
        Move(); 
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // Get input values for horizontal (left/right) and vertical (forward/backward) axes.
        // These values can range from -1 to 1 based on player input.
    }

    private void Look()
    {
        if (_input == Vector3.zero) return; // If no input, exit the method.

        Quaternion rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        // Calculate the rotation needed to face the input direction.
        // ToIso() converts the input vector to isometric space.

        _model.rotation = Quaternion.RotateTowards(_model.rotation, rot, _turnSpeed * Time.deltaTime);
        // Rotate the player model smoothly towards the desired rotation.
        // _turnSpeed determines the maximum rotation speed.
    }

    private void Move()
    {
        Vector3 movement = _input.normalized; // Normalize the input vector to ensure consistent movement speed.

        _rb.MovePosition(transform.position + movement.ToIso() * _speed * Time.deltaTime);
        // Move the player based on the input direction and speed.
        // ToIso() converts the input vector to isometric space.
        // Time.deltaTime ensures smooth movement regardless of frame rate.
    }
}

public static class Helpers
{
    // Helper method to convert input vector to isometric space
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, -135, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
    // The ToIso() extension method converts a 3D vector from world space to isometric space.
    // It uses a rotation matrix to transform the vector.
    // In this case, the rotation is -135 degrees around the y-axis to align with an isometric perspective.
}