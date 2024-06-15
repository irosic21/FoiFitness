using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessLogicLayer
{
    public static class DayRepository
    {
        public static List<Day> GetAllByUserId(int userId)
        {
            var daysDAO = new DaysDAO();
            return daysDAO.GetAllByUserId(userId).ToList();
        }

        public static IEnumerable<Day> GetAll()
        {
            var daysDAO = new DaysDAO();
            return daysDAO.GetAll();
        }

        public static List<Day> BulkAddDaysForUser(int userId, List<DateTime> dates)
        {
            List<Day> listOfDays = new List<Day>();
            dates.ForEach(date =>
            {
                listOfDays.Add(new Day
                {
                    date = date.ToString("dd/MM/yyyy"),
                    user_id = userId,
                });
            });

            var daysDAO = new DaysDAO();
            return daysDAO.BulkAddDays(listOfDays);
        }

        public static int NeededCalories(int UserId)
        {
            DateTime now = DateTime.Now;
            var today = now.ToString("dd/MM/yyyy");
            var days = GetAllByUserId(UserId);
            foreach (Day day in days)
            {
                if(day.date.Replace("/", ".") == today)
                {
                    return day.bmr_calories - day.calories;
                }
            }
            return 0;
        }
        public static List<Day> GetAllUserDates()
        {
            var username = UserRepository.GetCurrentUser();
            var daysDAO = new DaysDAO();
            return daysDAO.GetAllUserDates(username).ToList();
        }

        public static List<Day> GetDay(string date)
        {
            var username = UserRepository.GetCurrentUser();
            var daysDAO = new DaysDAO();
            return daysDAO.GetDay(username, date).ToList();
        }

        public static void UpdateCalories(string date, string calories)
        {
            var daysDAO = new DaysDAO();
            var day = GetDay(date);

            day[0].calories += int.Parse(calories);
            daysDAO.Update(day[0]);
        }

        public static void UpdateBMR(string date, double bmr)
        {
            var daysDAO = new DaysDAO();
            var day = GetDay(date);

            day[0].bmr_calories = (int)bmr;
            daysDAO.UpdateBMR(day[0]);
        }

        public static int AddDay(string dateString, int bmr)
        {
            var username = UserRepository.GetCurrentUser();
            var user = UserRepository.GetUser(username);
            var day = new Day
            {
                user_id = user.id,
                date = dateString,
                bmr_calories = bmr
            };

            var dayDAO = new DaysDAO();
            return dayDAO.AddDay(day);

        }
    }
}
