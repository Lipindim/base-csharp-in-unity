using System;
using System.Collections.Generic;


namespace Labyrinth
{
    public class DeathController
    {
        public DeathController(IEnumerable<InteractiveObject> interactiveObjects, Action onDeathAction, PlayerModel playerModel)
        {
            foreach (var interactiveObject in interactiveObjects)
            {
                if (interactiveObject is DeathTrap deathTrap)
                {
                    interactiveObject.OnInteraction += x =>
                    {
                        if (!playerModel.IsInvulnerability)
                        {
                            onDeathAction?.Invoke();
                        }
                    };
                }
            }
        }
    }
}
