using Mics;
using UnityEngine;

public class Player : View
{
    private CharacterController _characterController;
    private float _runSpeed = 10;
    private Vector2 touchPos;
    private float maxSqrDistance = 225;
    private int nowRoadIndex;
    private int targetRoadIndex;
    private float baseXPos = 1.5f;
    private float horizontalSpeed = 10f;
    private float y_velocity;
    private inputDirState inputGesture;
    private bool isTouch;

    [SerializeField] private float recordSpeed = 10f;

    public delegate void ActionAnim(inputDirState inputDirState);

    public ActionAnim actionAnim;

    public event ActionAnim Order
    {
        add { actionAnim += value; }
        remove { }
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        if (y_velocity < -0.5)
        {
            if (_characterController.isGrounded)
            {
                _runSpeed = recordSpeed;
            }
        }
        else
        {
            y_velocity -= 20f * Time.deltaTime;
        }

        _characterController.Move((Vector3.forward * _runSpeed + Vector3.up * y_velocity) * Time.deltaTime);

        PlayerMove();
        inputGesture = inputDirState.Idle;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPos = Input.mousePosition;
            isTouch = true;
        }
        else if (Input.GetMouseButton(0) && isTouch)
        {
            Vector2 finPos = Input.mousePosition;
            Vector2 dir = finPos - touchPos;
            if (dir.sqrMagnitude > maxSqrDistance)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                {
                    if (dir.x > 0)
                    {
                        inputGesture = inputDirState.Right;
                    }
                    else if (dir.x < 0)
                    {
                        inputGesture = inputDirState.Left;
                    }
                }
                else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
                {
                    if (dir.y > 0)
                    {
                        inputGesture = inputDirState.Up;
                    }
                    else if (dir.y < 0)
                    {
                        inputGesture = inputDirState.Down;
                    }
                }

                isTouch = false;
                actionAnim?.Invoke(inputGesture);
            }
        }
    }

    public override string Name => Consts.V_Player;

    public override void HandleEvent(object data = null)
    {
        throw new System.NotImplementedException();
    }

    private void PlayerMove()
    {
        switch (inputGesture)
        {
            case inputDirState.Idle:
                break;

            case inputDirState.Right:
                if (targetRoadIndex < 1)
                {
                    targetRoadIndex++;
                }

                break;
            case inputDirState.Left:
                if (targetRoadIndex > -1)
                {
                    targetRoadIndex--;
                }

                break;

            case inputDirState.Up:
                if (_characterController.isGrounded)
                {
                    y_velocity = 6f;
                    recordSpeed = _runSpeed;
                    _runSpeed /= 1.5f;
                }

                break;
            default:
                break;
        }

        if (nowRoadIndex != targetRoadIndex)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(pos.x, baseXPos * targetRoadIndex, Time.deltaTime * horizontalSpeed);
            transform.position = pos;

            if (Mathf.Abs(transform.position.x - baseXPos * targetRoadIndex) <= 0.1f)
            {
                pos.x = baseXPos * targetRoadIndex;
                transform.position = pos;
                nowRoadIndex = targetRoadIndex;
            }
        }
    }
}