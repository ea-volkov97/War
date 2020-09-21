namespace War
{
    /// <summary>
    /// Предоставляет инструменты для моделирования боя юнитов.
    /// </summary>
    public class Battle
    {
        /// <summary>
        /// Возвращает или задает отряд атакущей стороны.
        /// </summary>
        private Squad _attackingSide;
        /// <summary>
        /// Возвращает или задает отряд обороняющейся стороны.
        /// </summary>
        private Squad _defendingSide;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Battle"/> с указанными параметрами.
        /// </summary>
        /// <param name="attackingSide">Отряд атакующей стороны.</param>
        /// <param name="defendingSide">Отряд обороняющейся стороны.</param>
        public Battle(Squad attackingSide, Squad defendingSide)
        {
            _attackingSide = attackingSide;
            _defendingSide = defendingSide;
        }

        /// <summary>
        /// Симулирует сражение между атакующей и обороняющейся стороной и возвращает результат.
        /// </summary>
        /// <returns>Результат сражения.</returns>
        public BattleResult Simulate()
        {
            while (!_attackingSide.isDefeated && !_defendingSide.isDefeated)
            {
                if (!_attackingSide.isDefeated)
                {
                    _attackingSide.PrepareToAttack();
                    _attackingSide.Attack(_defendingSide);
                }
                else if (!_defendingSide.isDefeated) {
                    _defendingSide.PrepareToAttack();
                    _defendingSide.Attack(_attackingSide);
                }
            }

            if (_attackingSide.isDefeated && _defendingSide.isDefeated)
                return BattleResult.Draw;
            else if (_attackingSide.isDefeated)
                return BattleResult.DefendingSideWon;
            else
                return BattleResult.AttackingSideWon;
        }

        /// <summary>
        /// Задает константы, которые определяют результат сражения.
        /// </summary>
        public enum BattleResult
        {
            AttackingSideWon,
            DefendingSideWon,
            Draw
        }
    }
}
