using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DoubleClickListener : MonoBehaviour, IPointerClickHandler
{

    [Tooltip("Max duration between 2 clicks in seconds")]
    [Range(0.01f, 0.5f)] public float DoubleClickDuration = 0.4f;
    public UnityEvent OnDoubleClick;

    private byte _clicks = 0;
    private float _elapsedTime = 0f;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (_clicks == 1)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > DoubleClickDuration)
            {
                _clicks = 0;
                _elapsedTime = 0f;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clicks++;

        if (_clicks == 1)
            _elapsedTime = 0f;
        else if (_clicks > 1)
        {
            if (_elapsedTime <= DoubleClickDuration)
            {
                _clicks = 0;
                _elapsedTime = 0f;
                if (_button.interactable)
                    OnDoubleClick?.Invoke();
            }
        }
    }

}