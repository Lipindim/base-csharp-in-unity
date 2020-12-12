using UnityEngine;


namespace Labyrinth
{
    public class KeyboardController : IUpdate
    {
        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}
