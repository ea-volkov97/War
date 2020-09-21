namespace War.Units
{
    /// <summary>
    /// Представляет юнит-бомбардировщик.
    /// </summary>
    public class Bomber : Unit
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Bomber"/> с указанными параметрами.
        /// </summary>
        /// <param name="owner">Нация, которой принадлежит данный юнит.</param>
        /// <param name="name">Имя юнита.</param>
        /// <param name="attackForce">Сила атаки юнита.</param>
        /// <param name="defendForce">Обороноспособность юнита.</param>
        /// <param name="healSpeed">Скорость восстановления здоровья юнита.</param>
        /// <param name="description">Текстовое описание юнита.</param>
        public Bomber(
            Nation owner,
            string name = "Бомбардировщик",
            int attackForce = 50,
            int defendForce = 10,
            int healSpeed = 5,
            string description = "Мощный юнит для атаки по сухопотным целям, однако очень уязвимы для зенитных орудий."
            ) : base(owner, name, attackForce, defendForce, healSpeed, description)
        {
            Type = UnitType.AirForce;
        }

        public override void Attack(Unit enemyUnit)
        {
            if (enemyUnit.Type == UnitType.LandForce)
                base.Attack(enemyUnit);
        }

        public override void Influence()
        {
            // Бомбардировщики не оказывают влияния на другие юниты.
        }
    }
}
