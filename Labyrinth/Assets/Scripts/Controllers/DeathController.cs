using System;
using System.Collections.Generic;
using System.Linq;


namespace Labyrinth
{
    public class DeathController
    {

        #region Fields

        private Action _onDeathAction;
        private PlayerModel _playerModel;

        #endregion


        #region ClassLifeCycles

        public DeathController(IEnumerable<InteractiveObject> interactiveObjects, Action onDeathAction, PlayerModel playerModel)
        {
            if (interactiveObjects == null)
                throw new ArgumentNullException(nameof(interactiveObjects));
            if (playerModel == null)
                throw new ArgumentNullException(nameof(playerModel));

            _onDeathAction = onDeathAction;
            _playerModel = playerModel;

            var deathTraps = interactiveObjects.Where(x => x.Type == InteractiveObjectEnum.DeathTrap);
            foreach (var deathTrap in deathTraps)
            {
                deathTrap.OnInteraction += OnDeathInteraction;
            }
        }

        #endregion


        #region Methods

        private void OnDeathInteraction(InteractiveObject interactiveObject)
        {
            if (!_playerModel.IsInvulnerability)
            {
                _onDeathAction?.Invoke();
            }
        }

        #endregion

    }
}
