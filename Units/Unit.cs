using System;

namespace War.Units
{
    /// <summary>
    /// Представляет абстрактное описание боевого юнита.
    /// </summary>
    public abstract class Unit : IViewable
    {
        /// <summary>
        /// Возвращает или задает имя юнита.
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// Возвращает или задает количество очков здоровья юнита.
        /// </summary>
        public int Health { get; private set; }
        /// <summary>
        /// Возвращает или задает нацию, которая является владельцем юнита.
        /// </summary>
        public Nation Owner { get; private set; }
        /// <summary>
        /// Возвращает или задает текстовое описание юнита.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Возвращает true, если очки здоровья ниже или равно нулю.
        /// </summary>
        public bool IsDead => Health <= 0;
        /// <summary>
        /// Возвращает род войск юнита.
        /// </summary>
        public UnitType Type { get; protected set; }

        /// <summary>
        /// Возвращает ссылку на отряд, в котором состоит юнит.
        /// </summary>
        protected Squad _squad = null;

        /// <summary>
        /// Сила атаки юнита.
        /// </summary>
        private int _attackForce;
        /// <summary>
        /// Обороноспсобность юнита.
        /// </summary>
        private int _defendForce;
        /// <summary>
        /// Скорость восстановления здоровья юнита.
        /// </summary>
        private int _healSpeed;

        /// <summary>
        /// Коэффициент, определяющий бонус к силе атаке юнита.
        /// </summary>
        private float _attackForceBonus = 0f;
        /// <summary>
        /// Коэффициент, определяющий бонус к обороноспособность юнита.
        /// </summary>
        private float _defendForceBonus = 0f;
        /// <summary>
        /// Коэффициент, определяющий бонус к скорости восстановления здоровья юнита.
        /// </summary>
        private float _healBonus = 0f;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Unit"/> с указанными параметрами.
        /// </summary>
        /// <param name="owner">Нация, которой принадлежит данный юнит.</param>
        /// <param name="name">Имя юнита.</param>
        /// <param name="attackForce">Сила атаки юнита.</param>
        /// <param name="defendForce">Обороноспособность юнита.</param>
        /// <param name="healSpeed">Скорость восстановления здоровья юнита.</param>
        /// <param name="description">Текстовое описание юнита.</param>
        public Unit(Nation owner, string name = "", int attackForce = 0, int defendForce = 0, int healSpeed = 0, string description = "")
        {
            Owner = owner;
            Name = name == "" ? "Unknown Unit" : name;

            _attackForce = attackForce < 0 ? 0 : attackForce;
            _defendForce = defendForce < 0 ? 0 : defendForce;
            _healSpeed = healSpeed < 0 ? 0 : healSpeed;

            Description = description;
        }

        /// <summary>
        /// Добавляет юнит в указанный отряд, если это возможно и возвращает true. В противном  случае - возвращает false.
        /// </summary>
        /// <param name="squad">Отряд, к которому должен присоединиться юнит.</param>
        /// <returns>Результат действия.</returns>
        public bool TryToJoinToSquad(Squad squad)
        {
            if (squad.Owner == Owner)
            {
                _squad = squad;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Совершает атаку по указаннной цели.
        /// <param name="enemyUnit">Цель.</param>
        /// </summary>
        public virtual void Attack(Unit enemyUnit)
        {
            int damage = Convert.ToInt32(_attackForce * (1 + _attackForceBonus));
            enemyUnit.TakeDamage(damage);
        }

        /// <summary>
        /// Совершает атаку по указанной группе целей.
        /// </summary>
        /// <param name="enemyUnits">Группа целей.</param>
        public virtual void Attack(Unit[] enemyUnits)
        {
            int damage = Convert.ToInt32(_attackForce * (1 + _attackForceBonus));
            foreach (Unit enemyUnit in enemyUnits)
                enemyUnit.TakeDamage(damage);
        }

        /// <summary>
        /// Принимает указанное число единиц урона.
        /// </summary>
        /// <param name="damage">Величина урона, которая будет нанесена юниту.</param>
        public virtual void TakeDamage(int damage)
        {
            Health -= Convert.ToInt32(damage * (1 - _defendForce * (1 + _defendForceBonus)));
        }

        /// <summary>
        /// Восстанавливает здоровье юнита.
        /// </summary>
        public virtual void Heal()
        {
            Health += Convert.ToInt32(_healSpeed * (1 + _healBonus));
        }

        /// <summary>
        /// Задает величину бонусов к характеристикам юнита.
        /// </summary>
        /// <param name="attackForceBonus">Величина бонуса к атаке.</param>
        /// <param name="defendForceBonus">Величина бонуса к обороноспособности.</param>
        /// <param name="healBonus">Величина бонуса к скорости восстановления здоровья.</param>
        public virtual void TakeInfluence(float attackForceBonus = 0, float defendForceBonus = 0, float healBonus = 0)
        {
            _attackForceBonus += attackForceBonus;
            _defendForceBonus += defendForceBonus;
            _healBonus += healBonus;
        }

        /// <summary>
        /// Оказывает воздействие на других юнитов отряда, в котором состоит данный юнит.
        /// </summary>
        public abstract void Influence();

        public void Show()
        {
            Console.WriteLine($"{Owner.WhoseUnitsText} {Name}");
        }

        /// <summary>
        /// Задает константы, которые определяют род войск юнита.
        /// </summary>
        public enum UnitType
        {
            LandForce,
            AirForce
        }
    }
}
