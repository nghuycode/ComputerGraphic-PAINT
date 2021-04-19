using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public enum TouchState 
    {
        Drag, Drop, Start
    }

    [SerializeField]
    private TouchState _state = TouchState.Drop;
    [SerializeField]
    private Vector3 startTouchPos, currentTouchPos;
    private float diffX, diffY;
    private float startFrame;
    public GameObject GetHoveredObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

        if (hit.collider == null) return null;
        return hit.collider.gameObject;
    }
    public GameObject GetHoldObject()
    {
        if (!Input.GetMouseButtonDown(0)) return null;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

        if (hit.collider == null || Input.GetMouseButtonUp(0)) return null;
        return hit.collider.gameObject;
    }
    public GameObject GetClickedObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

        if (hit.collider == null) return null;
        if (Input.GetMouseButtonUp(0))
            return hit.collider.gameObject;
        else return null;
    }

    public bool DropObject()
    {
        return (Input.GetMouseButtonUp(0));
    }
    private void MouseCheck()
    {
        if (Input.GetMouseButtonDown(0) && _state == TouchState.Drop)
        {
            startTouchPos = Input.mousePosition;
            _state = TouchState.Start;
        }

        if (_state == TouchState.Start)
        {
            if (Input.mousePosition != startTouchPos)
            {
                _state = TouchState.Drag;
                Drag();
            }
        }
        if (_state == TouchState.Drag)
            Drag();
        if (Input.GetMouseButtonUp(0))
        {
            _state = TouchState.Drop;
        }
    }

    #region Move Command Definition
    void Drag()
    {
        float disX = Mathf.Abs(Input.mousePosition.x - startTouchPos.x);
        float disY = Mathf.Abs(Input.mousePosition.y - startTouchPos.y);
        currentTouchPos = Input.mousePosition;

        Debug.Log("Start Position:" + startTouchPos);
        Debug.Log("Current Position:" + Input.mousePosition);
        //Send notification to the listener
    }
    #endregion
    private void Update()
    {
        MouseCheck();
    }
}
