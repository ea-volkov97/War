namespace War.Units
{
    /// <summary>
    /// Представляет класс зенитного орудия.
    /// </summary>
    public class AntiAircraftGun : Unit
    {
        /// <summary>
        /// Величина бонуса, который зенитное орудие дает к защите.
        /// </summary>
        private float _antiAircraftDefendBonus;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AntiAircraftGun"/> с указанными параметрами.
        /// </summary>
        /// <param name="owner">Нация, которой принадлежит данный юнит.</param>
        /// <param name="name">Имя юнита.</param>
        /// <param name="attackForce">Сила атаки юнита.</param>
        /// <param name="defendForce">Обороноспособность юнита.</param>
        /// <param name="healSpeed">Скорость восстановления здоровья юнита.</param>
        /// <param name="antiAircraftDefendBonus">Бонус зенитных орудий к защите юнитов в отряде.</param>
        /// <param name="description">Текстовое описание юнита.</param>
        public AntiAircraftGun(
            Nation owner,
            string name = "Зенитное оборудование",
            int attackForce = 25,
            int defendForce = 50,
            int healSpeed = 8,
            float antiAircraftDefendBonus = 0.6f,
            string description = "Отличная защита от авианалетов противника."
            ) : base(owner, name, attackForce, defendForce, healSpeed, description)
        {
            _antiAircraftDefendBonus = antiAircraftDefendBonus;
            Type = UnitType.LandForce;
        }

        public override void Attack(Unit enemyUnit)
        {
            if (enemyUnit.Type == UnitType.AirForce)
                base.Attack(enemyUnit);
        }

        public override void Influence()
        {
            if (_squad != null)
                for (int i = 0; i < _squad.UnitsCount; i++)
                    _squad.GetUnitByIndex(i).TakeInfluence(defendForceBonus: _antiAircraftDefendBonus);
        }
    }
}
