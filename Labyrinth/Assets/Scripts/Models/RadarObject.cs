using UnityEngine;
using UnityEngine.UI;


public class RadarObject : MonoBehaviour
{

    #region Fields

    [SerializeField] private Image _ico;

    private bool _isActive = true;

    #endregion


    #region Properties

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

    #endregion


    #region UnityMethods

    private void OnDestroy()
    {
        _isActive = false;
    }

    #endregion

}
