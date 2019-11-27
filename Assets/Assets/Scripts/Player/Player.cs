using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _jumpForce = 5.0f;
    private bool _resetJump;
    private float _playerSpeed = 2.3f;
    private PlayerAnimation _anim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
    private bool _grounded = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Q) && IsGrounded() == true) {
            _anim.Attack();
        }
    }

    void Movement() {
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        
        Flip(move);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true) {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _anim.Jump(true);
        }

        _rigidbody.velocity = new Vector2(move * _playerSpeed, _rigidbody.velocity.y);

        _anim.Move(move);
    }

    bool IsGrounded() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        
        if (hitInfo.collider != null) {
            if(_resetJump == false){
                _anim.Jump(false);
                return true;
            }
        }

        return false;
    }

    void Flip(float move) {
        if ( move < 0) {
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;

        } else if ( move > 0 ){
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    }

    IEnumerator ResetJumpRoutine() {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
