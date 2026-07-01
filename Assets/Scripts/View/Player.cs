using System;
using System.Collections;
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

    private int _coin;
    private int _multiplyAdd = 1;
    private float multiplyTime = 2f;
    private float attractCoinTime = 2.5f;

    [SerializeField] private float recordSpeed = 10f;

    private GameModel gm;

    public delegate void ActionAnim(inputDirState inputDirState);

    public ActionAnim actionAnim;

    private IEnumerator multiplyCor;
    private IEnumerator megnetCor;

    private bool isMegnetEf;

    public bool IsMegnetEf
    {
        set
        {
            if (value == isMegnetEf) return;
            isMegnetEf = value;
            gm.IsMegnet = value;
        }
    }

    public override string Name => Consts.V_Player;

    public int Coin
    {
        get => _coin;
        set
        {
            if (value - _coin != 0)
            {
                _coin = value;
            }
        }
    }

    public event ActionAnim Order
    {
        add { actionAnim += value; }
        remove { }
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Start()
    {
        gm = Mvc.GetModel<GameModel>();
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

    public override void HandleEvent(object data = null)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Consts.ItemBeforeTrigger))
        {
            other.transform.parent.SendMessage("OnEngine");
        }
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

    private void PickCoin()
    {
        Coin += _multiplyAdd;
    }

    private void OnMultiplyCoin()
    {
        _multiplyAdd = 2;
        if (multiplyCor != null)
        {
            StopCoroutine(multiplyCor);
        }

        multiplyCor = MultiplyCoinCor();
        StartCoroutine(multiplyCor);
    }

    IEnumerator MultiplyCoinCor()
    {
        yield return new WaitForSeconds(multiplyTime);
        _multiplyAdd = 1;
    }

    private void OnMagnet()
    {
        if (megnetCor != null)
        {
            StopCoroutine(megnetCor);
        }

        megnetCor = MegnetCoroutine();
        StartCoroutine(megnetCor);
    }

    IEnumerator MegnetCoroutine()
    {
        IsMegnetEf = true;
        yield return new WaitForSeconds(attractCoinTime);
        IsMegnetEf = false;
    }
}