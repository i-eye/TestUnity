using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gamerinput : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    [SerializeField]
    float rotateSpeed;


    Vector2 velocity = Vector2.zero;
    Vector2 rotate = Vector2.zero;

    Vector2 m_Rotation;

    Rigidbody rb;
    public void OnMove(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        rb.AddForce(new Vector3(0, 100, 0));
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        rotate = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Look(rotate);
        transform.position += new Vector3(velocity.x, 0, velocity.y) * Time.deltaTime * speed;
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        transform.localEulerAngles = m_Rotation;
    }
}
