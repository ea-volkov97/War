using System;
using System.Collections.Generic;
using War.Units;

namespace War
{
    /// <summary>
    /// Представляет описание отряда, состоящего из юнитов.
    /// </summary>
    public class Squad : IViewable
    {
        /// <summary>
        /// Возвращает или задает нацию, которой принадлежит данный отряд.
        /// </summary>
        public Nation Owner { get; private set; }
        /// <summary>
        /// Возвращает или задает юниты, которые входят в отряд.
        /// </summary>
        private List<Unit> _units;
        /// <summary>
        /// Возвращает количество юнитов в отряде.
        /// </summary>
        public int UnitsCount => _units == null ? 0 : _units.Count;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Squad"/>, принадлежащий указанной нации, из набора юнитов.
        /// Если нация, которой принадлежит отряд, и нация, которой принадлежит юнит различны, то он не будет добавлен в отряд.
        /// </summary>
        /// <param name="nation"></param>
        /// <param name="units">Список юнитов, из которых должен быть образован отряд.</param>
        public Squad(Nation nation, List<Unit> units = null)
        {
            Owner = nation;

            if (units != null)
                foreach (Unit unit in units)
                    TryAddUnit(unit);
        }

        /// <summary>
        /// Возвращает True, если все юниты в отряде погибли. False - если есть хотя бы один выживший юнит.
        /// </summary>
        public bool isDefeated
        {
            get
            {
                foreach (Unit unit in _units)
                    if (!unit.IsDead)
                        return false;

                return true;
            }
        }

        /// <summary>
        /// Производит расчет характеристик входящих в отряд юнитов с учетом бонусов перед атакой.
        /// </summary>
        public void PrepareToAttack()
        {
            foreach (Unit unit in _units)
                unit.Influence();
        }

        /// <summary>
        /// Атакует указанный отряд.
        /// </summary>
        /// <param name="enemySquad"></param>
        public void Attack(Squad enemySquad)
        {
            foreach (Unit unit in _units)
                for (int i = 0; i < enemySquad.UnitsCount; i++)
                    unit.Attack(enemySquad.GetUnitByIndex(i));
        }

        /// <summary>
        /// Возвращает юнит отряда по индексу.
        /// </summary>
        /// <param name="index">Индекс юнита.</param>
        /// <returns>Юнит отряда.</returns>
        public Unit GetUnitByIndex(int index)
        {
            if (index < 0 || index >= UnitsCount)
                return _units[index];
            else
                return null;
        }

        /// <summary>
        /// Присоединяет юнит к отряду, если нации, которым они принадлежат совпадают и возвращает true.
        /// В противном случае возвращает false.
        /// </summary>
        /// <param name="unit">Присоединяемый юнит.</param>
        /// <returns>True, если юнит был присоединен. False, если - нет.</returns>
        public bool TryAddUnit(Unit unit)
        {
            if (unit.TryToJoinToSquad(this))
            {
                _units.Add(unit);
                return true;
            }
            else
                return false;
        }

        public void Show()
        {
            Console.WriteLine($"{Owner.WhoseUnitsText} отряд");
        }
    }
}
