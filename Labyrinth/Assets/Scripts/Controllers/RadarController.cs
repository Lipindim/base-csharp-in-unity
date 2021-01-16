using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public class RadarController : IUpdatable
    {

        #region Fields

        private RadarSettings _radarSettings;
        private List<RadarModel> _radarObjects = new List<RadarModel>();
        private GameObject _minimap;
        private GameObject _player;

        private float _realSqrRadius;

        #endregion


        #region ClassLifeCycles

        public RadarController(RadarSettings radarSettings, RadarObject[] radarObjects, GameObject minimap, GameObject player)
        {
            _radarSettings = radarSettings;
            _minimap = minimap;
            _player = player;
            float realRadius = _radarSettings.Radius * _radarSettings.Scale;
            _realSqrRadius = realRadius * realRadius;

            foreach (var item in radarObjects)
            {
                var ico = GameObject.Instantiate(item.Ico);
                _radarObjects.Add(new RadarModel()
                {
                    Owner = item.Owner,
                    Ico = ico,
                    Object = item,
                    Transform = ico.GetComponent<RectTransform>()
                });
            }
        }

        #endregion


        #region IUpdateble

        public void Update(float deltaTime)
        {
            foreach (RadarModel radarModel in _radarObjects)
            {
                if (!radarModel.Object.IsActive)
                {
                    radarModel.Ico.transform.parent = null;
                    continue;
                }

                Vector3 vectorToPlayer = radarModel.Owner.transform.position - _player.transform.position;
                if (vectorToPlayer.sqrMagnitude < _realSqrRadius)
                {
                    radarModel.Transform.parent = _minimap.transform;
                    Vector2 radarModelPositoin = new Vector2(vectorToPlayer.x / _radarSettings.Scale, vectorToPlayer.z / _radarSettings.Scale);
                    radarModel.Transform.anchoredPosition = radarModelPositoin;
                }
                else
                {
                    radarModel.Ico.transform.parent = null;
                }
            }
        }

        #endregion

    }
}
