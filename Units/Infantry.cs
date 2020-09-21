namespace War.Units
{
    /// <summary>
    /// Представляет описание юнита-пехоты.
    /// </summary>
    public class Infantry : Unit
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Infantry"/> с указанными параметрами.
        /// </summary>
        /// <param name="owner">Нация, которой принадлежит данный юнит.</param>
        /// <param name="name">Имя юнита.</param>
        /// <param name="attackForce">Сила атаки юнита.</param>
        /// <param name="defendForce">Обороноспособность юнита.</param>
        /// <param name="healSpeed">Скорость восстановления здоровья юнита.</param>
        /// <param name="description">Текстовое описание юнита.</param>
        public Infantry(
            Nation owner,
            string name = "Пехотинцы",
            int attackForce = 10,
            int defendForce = 20,
            int healSpeed = 25,
            string description = "Пушечное мясо. Очень уязвимы при атаке, но хорошо обороняются и быстро восстанавливаются."
            ) : base(owner, name, attackForce, defendForce, healSpeed, description)
        {
            Type = UnitType.LandForce;
        }

        public override void Attack(Unit enemyUnit)
        {
            if (enemyUnit.Type == UnitType.LandForce)
                base.Attack(enemyUnit);
        }

        public override void Influence()
        {
            // Пехота не  оказывает никакого влияния на другие юниты.
        }
    }
}
