using UnityEngine;
using UnityEngine.UI;


public class RadarObject : MonoBehaviour
{
    public bool IsActive
    {
        get
        {
            return _isActive;
        }
    }
    public Image Ico
    {
        get
        {
            return _ico;
        }
    }

    public GameObject Owner
    {
        get
        {
            return gameObject;
        }
    }

    [SerializeField] private Image _ico;

    private bool _isActive = true;

    private void OnDestroy()
    {
        _isActive = false;
    }

}
