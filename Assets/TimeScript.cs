using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public GameObject textGameObject;
    public bool isVisible = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SetVisibility(isVisible);
    }

    public void SetVisibility(bool visible)
    {
        if (textGameObject != null)
        {
            textGameObject.SetActive(visible);
        }
        isVisible = visible;
    }
}
