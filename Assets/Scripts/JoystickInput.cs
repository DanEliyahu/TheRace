using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float Horizontal => input.x;

    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;

    private Canvas canvas;

    private Vector2 input = Vector2.zero;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();

        Vector2 center = new Vector2(0.5f, 0.5f);
        background.pivot = center;
        handle.anchorMin = center;
        handle.anchorMax = center;
        handle.pivot = center;
        handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 radius = background.sizeDelta / 2;
        input = (eventData.position - background.anchoredPosition) / (radius * canvas.scaleFactor);
        input.y = 0; // only horizontal move
        HandleInput(input.magnitude, input.normalized);
        handle.anchoredPosition = input * radius;
    }

    private void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > 1)
            input = normalised;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}