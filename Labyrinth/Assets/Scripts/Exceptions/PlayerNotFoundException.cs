using System;


namespace Labyrinth
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException() : base($"На сцене не найден объект со скриптом 'Player'")
        {
        }
    }
}
