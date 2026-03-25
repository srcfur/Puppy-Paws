using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryItemBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovered = false;
    bool isDragging = false;
    private Vector2 originalGrabPosition = Vector2.zero;
    public int stackIndex = -1;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHovered)
        {
            originalGrabPosition = Mouse.current.position.value;
        }
        if (Input.GetMouseButton(0))
        {
            if ((Mouse.current.position.value - originalGrabPosition).magnitude > 15)
            {
                isDragging = true;
                InventoryScreen.instance.DragObjectCallback(gameObject, stackIndex);
            }
            if (isDragging)
            {
                GetComponent<RectTransform>().localPosition = Mouse.current.position.value;
            }
        }
        else
        {
            isDragging = false;
            ReturnItem();
        }
        
    }
    void ReturnItem()
    {
        GetComponent<RectTransform>().localPosition = originalGrabPosition;
    }
}


