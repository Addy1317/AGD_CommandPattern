using Command.Commands;
using Command.Input;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class HealAction : IAction
    {
        private UnitController actorUnit;
        private UnitController targetUnit;
        private bool isSuccessful;
        public TargetType TargetType => TargetType.Friendly;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;
            this.isSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.Heal, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            if (isSuccessful)
                targetUnit.RestoreHealth(actorUnit.CurrentPower);
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}