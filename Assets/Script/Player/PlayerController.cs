using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : NewMonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private SO_PLAYER sO_PLAYER;
    [SerializeField] private Vector3 _moveVector;
    protected Vector3 moveDirection;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
        this.LoadAnimator();
    }
    protected override void Awake()
    {
        base.Awake();
        this.LoadFixedJoystick();
    }
    private void Update()
    {
        this.Move();
    }
    private void LoadRigibody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    private void LoadFixedJoystick()
    {
        if(this._joystick != null) return;
        this._joystick = FindAnyObjectByType<FloatingJoystick>();
    }
    private void LoadAnimator()
    {
        if(this._animator != null) return;
        this._animator = gameObject.GetComponent<Animator>();
    }

    private void Move()
    {
        if(this._joystick != null)
        {
            _moveVector = Vector3.zero;
            _moveVector.x = _joystick.Horizontal * sO_PLAYER._moveSpeed * Time.deltaTime;
            _moveVector.z = _joystick.Vertical * sO_PLAYER._moveSpeed * Time.deltaTime;
            float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude) * 5;
            moveDirection = new Vector3(_moveVector.x, 0,  _moveVector.z);
            if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, sO_PLAYER._rotationSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(direction);
                _animator.SetFloat("Movement Multiplier", inputMagnitude * 8, 3f, Time.deltaTime);
            }
            else if(moveDirection == Vector3.zero)
            {
                _animator.SetFloat("Movement Multiplier", 0, 0.1f, Time.deltaTime);
            }
            
             _rigidbody.MovePosition(_rigidbody.position + _moveVector);
        }
        
    }

}