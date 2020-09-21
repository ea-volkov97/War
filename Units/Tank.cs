namespace War.Units
{
    /// <summary>
    /// Представляет класс юнита-танка.
    /// </summary>
    public class Tank : Unit
    {
        /// <summary>
        /// Величина бонуса, которую танк дает к силе атаки отряда.
        /// </summary>
        private float _tankAttackBonus;
        /// <summary>
        /// Величина бонуса, которую танк дает к защите отряда.
        /// </summary>
        private float _tankDefendBonus;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tank"/> с указанными параметрами.
        /// </summary>
        /// <param name="owner">Нация, которой принадлежит данный юнит.</param>
        /// <param name="name">Имя юнита.</param>
        /// <param name="attackForce">Сила атаки юнита.</param>
        /// <param name="defendForce">Обороноспособность юнита.</param>
        /// <param name="healSpeed">Скорость восстановления здоровья юнита.</param>
        /// <param name="tankAttackBonus">Бонус танка к атаке юнитов в отряде.</param>
        /// <param name="tankDefendBonus">Бонус танка к защите юнитов в отряде.</param>
        /// <param name="description">Текстовое описание юнита.</param>
        public Tank(
            Nation owner,
            string name = "Танг",
            int attackForce = 65,
            int defendForce = 50,
            int healSpeed = 10,
            float tankAttackBonus = 0.2f,
            float tankDefendBonus = 0.4f,
            string description = "Танки хорошо подходят, как для атаки, так и для обороны."
            ) : base(owner, name, attackForce, defendForce, healSpeed, description)
        {
            _tankAttackBonus = tankAttackBonus;
            _tankDefendBonus = tankDefendBonus;

            Type = UnitType.LandForce;
        }

        public override void Attack(Unit enemyUnit)
        {
            if (enemyUnit.Type == UnitType.LandForce)
                base.Attack(enemyUnit);
        }

        public override void Influence()
        {
            if (_squad != null)
                for (int i = 0; i < _squad.UnitsCount; i++)
                    _squad.GetUnitByIndex(i).TakeInfluence(_tankAttackBonus, _tankDefendBonus);
        }
    }
}
