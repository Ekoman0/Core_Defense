using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    public static bool move = true;
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 3;
    public GameObject player;
    private float rotation;
    public float rotationspeed;

    public static class MouseOverUILayerObject
    {
        public static bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.layer == 5) //5 = UI layer
                {
                    return true;
                }
            }

            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    




        if (move && !MouseOverUILayerObject.IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;



                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Camera.main.transform.position += direction;



            }
            zoom(Input.GetAxis("Mouse ScrollWheel"));

            //lastY = gameObject.transform.position.y;
        }

    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }


}