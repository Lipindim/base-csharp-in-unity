using UnityEngine;


[CreateAssetMenu(fileName = "MinimapSettings", menuName = "Data/MinimapSettings")]
public class MiniMapSettings : ScriptableObject
{
    public GameObject Minimap;
    public Vector3 Position;
}
