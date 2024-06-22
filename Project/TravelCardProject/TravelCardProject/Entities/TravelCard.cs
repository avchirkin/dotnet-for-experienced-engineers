namespace TravelCardProject.Entities
{
    public record TravelCard
    {
        public Guid Id { get; init; }
        // Номер ЭПБ - как будто, у всех таких карт есть свой номер
        public string Number { get; init; }
        // Дата Активации ЭПБ
        public DateTime ActivationDate { get; set; }
        // Дата окончания действия ЭПБ
        public DateTime? ExpirationDate { get; set; }
        // Статус
        public TravelCardStatus Status { get; set; }
        // Дата истечения повышенного коэффициента стоимости
        public DateTime? HighCoefficientExpiration { get; set; }
        // Применяется ли коэффициент
        public bool HighCoefficientActive { get; set; }
        // Время, до которого действует приостановка тарифа
        public DateTime? PauseExpiration {  get; set; }
        // Находится ли тариф на паузе
        public bool IsPaused { get; set; }
        // Дата последней смены тарифа
        public DateTime? TariffUpdateDate { get; set; }

        // Связи со счетом, тарифом и пассажиром
        public Guid AccountId { get; init; }
        public Guid TariffId { get; set; }
        public Guid PassengerId { get; set; }

        public Account Account { get; init; } = default!;
        public Tariff Tariff { get; init; } = default!;
        public Passenger Passenger { get; init; } = default!;
        public IEnumerable<Trip> Trips { get; init; } = default!;
    }
}
