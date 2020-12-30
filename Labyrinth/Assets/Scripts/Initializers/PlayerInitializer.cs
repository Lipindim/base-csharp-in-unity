using UnityEngine;


namespace Labyrinth
{
    public class PlayerInitializer
    {
        public static GameObject Initialize(PlayerData playerData)
        {
            var player = Object.Instantiate(playerData.Prefab, playerData.StartPosition, Quaternion.identity);
            return player;
        }
    }
}
