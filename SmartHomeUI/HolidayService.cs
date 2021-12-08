using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartHomeUI
{
    public class HolidayService
    {
        private IHttpClientFactory httpClientFactory;
        private HashSet<DateTime> holidays = new();

        public HolidayService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task LoadAsync(int year)
        {
            //https://github.com/NateScarlet/holiday-cn
            var httpClient = httpClientFactory.CreateClient();
            string url = $"https://natescarlet.coding.net/p/github/d/holiday-cn/git/raw/master/{year}.json";
            string json = await httpClient.GetStringAsync(url);
            var jsonDoc = JsonSerializer.Deserialize<JsonDocument>(json);
            var holidayItems = jsonDoc.RootElement.GetProperty("days").Deserialize<HolidayItem[]>();
            foreach (var item in holidayItems)
            {
                holidays.Add(item.Date);
            }
        }

        /// <summary>
        /// 今天是否是休息日
        /// </summary>
        /// <returns></returns>
        public bool IsTodayOffDay()
        {
            var todayDate = DateTime.Today;
            if (holidays.Contains(todayDate))//在节假日安排中，就是放假
            {
                return true;
            }
            else//否则，如果是周末就是放假
            {
                var dow = todayDate.DayOfWeek;
                return dow == DayOfWeek.Sunday || dow == DayOfWeek.Saturday;
            }
        }

        public class HolidayItem
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public bool IsOffDay { get; set; }
        }
    }
}
