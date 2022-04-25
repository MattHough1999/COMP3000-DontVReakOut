using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent Pressed, Released;
    [SerializeField] private float Threshold = 0.1f;
    [SerializeField] private float DeadZone = 0.025f;

    private bool IsPressed;
    private Vector3 StartPosition;
    private ConfigurableJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPressed && getValue() + Threshold >= 1)
        {
            OnPressed();
        }
        if (IsPressed && getValue() - Threshold <= 0)
        {
            OnReleased();
        }

    }

    private float getValue() 
    {
        var value = Vector3.Distance(StartPosition, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(value) < DeadZone) value = 0;
        return Mathf.Clamp(value, -1, 1);
    }

    private void OnPressed() 
    {
        IsPressed = true;
        Pressed.Invoke();
        Debug.Log("Pressed");
    }
    private void OnReleased() 
    {
        IsPressed = false;
        Released.Invoke();
        Debug.Log("Released");
    }

}
