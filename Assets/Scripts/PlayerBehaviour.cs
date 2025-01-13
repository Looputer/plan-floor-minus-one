using UnityEngine;
using System.Collections.Generic;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 75.0f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;
    public LayerMask groundLayer;
    private CapsuleCollider _col;
    public List<GameObject> bulletPrefab;
    public float bulletSpeed = 100f;
    public int bulletLevel = 0;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hInput = Input.GetAxis("Horizontal") * rotationSpeed;
    }
    private void SetBulletLevel(int level)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletLevel = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletLevel = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bulletLevel = 2;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab[bulletLevel], transform.position + new Vector3(1, 0, 0), transform.rotation) as GameObject;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = transform.forward * bulletSpeed;
        }
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(angleRot * _rb.rotation);
    }
    private bool IsGrounded()
    {
        Vector3 capsuleButtom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleButtom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }
}
