﻿using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface ITariffService
    {
        Task<TariffInfoDto> CreateTariff(NewTariffDto tariffCreationInfo);

        Task<TariffInfoDto?> GetTariffInfo(Guid id);
    }
}
