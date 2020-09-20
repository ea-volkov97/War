namespace War
{
    /// <summary>
    /// Представляет собой игровую нацию, которая выступает в роли владельца юнитов.
    /// </summary>
    public class Nation
    {
        /// <summary>
        /// Возвращает название нации.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Возвращает притяжательное прилагательное, образованное от названия нации. Используется в именах юнитов.
        /// </summary>
        public string WhoseUnitsText { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Nation"/> c указанным именем и притяжательным прилагательным.
        /// </summary>
        /// <param name="name">Название нации.</param>
        /// <param name="whoseUnitsText">Притяжательное прилагательное, образованное от названия нации.</param>
        public Nation(string name = "Unknown nation", string whoseUnitsText = "Unknown nation's")
        {
            Name = name;
            WhoseUnitsText = whoseUnitsText;
        }
    }
}
