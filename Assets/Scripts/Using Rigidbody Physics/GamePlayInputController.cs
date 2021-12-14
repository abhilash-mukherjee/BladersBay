using UnityEngine;
using JMRSDK.InputModule;

public class GamePlayInputController : InputController,IFn1Handler, ISwipeHandler
{

    [SerializeField]
    LayerMask stadiumLayer;
    [SerializeField]
    private float maxDistanceOfRay = 100f;
    [SerializeField]
    private float minimumDistanceBetweenHitPointAndBeyBladeToAllowMovement = 0.05f;
    [SerializeField]
    private GameEvent LeftSwipeEvent, RightSwipeEvent, UpSwipeEvent, DownSwipeEvent;
    private bool m_isMoving = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        m_moveDirection = Vector3.zero;
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }
    void Update()
    {
        m_moveDirection = GiveMovementDirection();
    }

    public override Vector3 GiveMovementDirection()
    {
        Vector3 _moveDir;
        if (!m_isMoving)
        {
            _moveDir = Vector3.zero;
            return _moveDir;
        }
        Ray pointerRay = JMRPointerManager.Instance.GetCurrentRay();
        if (Physics.Raycast(pointerRay, out RaycastHit hit, maxDistanceOfRay, stadiumLayer))
        {
            m_stadiumHitPoint = hit.point;
            var _tempMoveDirection = hit.point - transform.position;
            if(_tempMoveDirection.magnitude < minimumDistanceBetweenHitPointAndBeyBladeToAllowMovement)
            {
                _moveDir = Vector3.zero;
                return _moveDir;
            }
            _moveDir = new Vector3(_tempMoveDirection.x, 0, _tempMoveDirection.z);
            _moveDir.Normalize();
        }
        else
        {
            m_stadiumHitPoint = Vector3.positiveInfinity;
            _moveDir = Vector3.zero;
        }
        return _moveDir;
    }

    public void OnFn1Action()
    {
        StopStartMovementAlternatively();
    }
    public void OnSwipeLeft(SwipeEventData eventData, float value)
    {
        LeftSwipeEvent.Raise();
    }

    public void OnSwipeRight(SwipeEventData eventData, float value)
    {
        RightSwipeEvent.Raise();
    }
    public void OnSwipeUp(SwipeEventData eventData, float value)
    {
        UpSwipeEvent.Raise();
    }

    public void OnSwipeDown(SwipeEventData eventData, float value)
    {
        DownSwipeEvent.Raise();
    }

    public void OnSwipeStarted(SwipeEventData eventData)
    {
    }

    public void OnSwipeUpdated(SwipeEventData eventData, Vector2 swipeData)
    {
    }

    public void OnSwipeCompleted(SwipeEventData eventData)
    {
    }

    public void OnSwipeCanceled(SwipeEventData eventData)
    {
    }
    public override void StopStartMovementAlternatively()
    {
        Debug.Log("Fn1 pressed");
        if (m_isMoving)
            m_isMoving = false;
        else
            m_isMoving = true;
    }
    public override void GoToBalanceMode()
    {
        Debug.Log("Balance Mode");
        SendSwipeEventMessegeToParentClass(InputGestures.SwipeMode.UP_SWIPE, gameObject);
    }
    public override void GoToAttackMode()
    {
        Debug.Log("Attack Mode");
        SendSwipeEventMessegeToParentClass(InputGestures.SwipeMode.RIGHT_SWIPE, gameObject);
    }
    public override void GoToDefenceMode()
    {
        Debug.Log("Defence Mode");
        SendSwipeEventMessegeToParentClass(InputGestures.SwipeMode.LEFT_SWIPE, gameObject);
    }
}

[System.Serializable]
public class InputGestures
{
    public enum SwipeMode
    {
        LEFT_SWIPE, RIGHT_SWIPE, UP_SWIPE, DOWN_SWIPE
    }
}
