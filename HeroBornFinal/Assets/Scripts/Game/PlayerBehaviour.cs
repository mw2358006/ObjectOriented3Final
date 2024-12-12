using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    public GameObject Bullet;
    public float bulletSpeed = 100f;
    private bool _isShooting;

    public float distanceGround = 0.1f;
    public LayerMask groundLayer;
    private CapsuleCollider _col;

    public float rotateSpeed = 75f;

    // X축(좌우 회전), Z축(전진 후진) 속도 분리
    public float moveSpeedX = 30f;
    public float moveSpeedZ = 10f;

    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;

    public float jumpVelocity = 5f;
    private bool _isJumping;

    private GameBehaviour _gameManager;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }
    void Update()
    {
        // 점프 키 변경
        _isJumping |= Input.GetKeyDown(KeyCode.Space);

        // Bullet 발사 키 변경
        _isShooting |= Input.GetMouseButtonDown(0);

        _vInput = Input.GetAxisRaw("Vertical") * moveSpeedZ;

        // 좌우 회전 속도 개선
        _hInput = Input.GetAxisRaw("Horizontal") * moveSpeedX;

        // this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        // this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (IsGround() && _isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        _isJumping = false;

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
        _isShooting = false;

        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    private bool IsGround()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }

        // 아이템 용도 변경
        if (collision.gameObject.name == "Hp1")
        {
            _gameManager.HP += 1;
        }

        if (collision.gameObject.name == "Hp2")
        {
            _gameManager.HP += 2;
        }

        // 데드존 추가, 경기장 이탈시 리스폰
        if (collision.gameObject.name == "DeadZone")
        {
            _gameManager.HP -= 1;
            this.gameObject.transform.position = new Vector3(0, 5, 0);
        }
    }
}
