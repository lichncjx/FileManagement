using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DHJ.FileManagement.MultiTenancy.HostDashboard.Dto;

namespace DHJ.FileManagement.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}