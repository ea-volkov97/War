namespace War.Units
{
    /// <summary>
    /// Представляет описание юнита-генерала.
    /// </summary>
    public class General : Unit
    {
        /// <summary>
        /// Величина бонуса, которую генера дает к атаке.
        /// </summary>
        private float _generalAttackBonus;
        /// <summary>
        /// Величина бонуса, которую генерал дает к защите.
        /// </summary>
        private float _generalDefendBonus;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="General"/> с указанными параметрами.
        /// </summary>
        /// <param name="owner">Нация, которой принадлежит данный юнит.</param>
        /// <param name="name">Имя юнита.</param>
        /// <param name="attackForce">Сила атаки юнита.</param>
        /// <param name="defendForce">Обороноспособность юнита.</param>
        /// <param name="healSpeed">Скорость восстановления здоровья юнита.</param>
        /// <param name="generalAttackBonus">Бонус генерала к атаке юнитов в отряде.</param>
        /// <param name="generalDefendBonus">Бонус генерала к защите юнитов в отряде.</param>
        /// <param name="description">Текстовое описание юнита.</param>
        public General(
            Nation owner,
            string name = "Генерал",
            int attackForce = 5,
            int defendForce = 5,
            int healSpeed = 15,
            float generalAttackBonus = 0.15f,
            float generalDefendBonus = 0.20f,
            string description = "Сам по себе очень уязвим, однако сильно поднимает боевой дух отряда."
            ) : base(owner, name, attackForce, defendForce, healSpeed, description)
        {
            _generalAttackBonus = generalAttackBonus;
            _generalDefendBonus = generalDefendBonus;

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
                    _squad.GetUnitByIndex(i).TakeInfluence(_generalAttackBonus, _generalDefendBonus);
        }
    }
}
