using UnityEngine;

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
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
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
