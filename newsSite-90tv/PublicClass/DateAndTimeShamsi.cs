using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.PublicClass
{
    public class DateAndTimeShamsi
    {

        public static string DateShamsi()
        {
            var currentDate = DateTime.Now;
            PersianCalendar pcCalender = new PersianCalendar();

            int year = pcCalender.GetYear(currentDate);
            int month = pcCalender.GetMonth(currentDate);
            int day = pcCalender.GetDayOfMonth(currentDate);

           

            string shamsiDate = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(day + "/" + month + "/" + year));
            return shamsiDate;
        }

        public static string MyTime()
        {
            var currentDate = DateTime.Now;
            PersianCalendar pcCalender = new PersianCalendar();
            int year = pcCalender.GetYear(currentDate);
            int month = pcCalender.GetMonth(currentDate);
            int day = pcCalender.GetDayOfMonth(currentDate);

            string NowTime = string.Format("{0:hh:mm}", Convert.ToDateTime(pcCalender.GetHour(currentDate) + ":" + pcCalender.GetMinute(currentDate)));
            return NowTime;
        }

        public static string MyTime(DateTime date)
        {
            var currentDate = date;
            PersianCalendar pcCalender = new PersianCalendar();
            int year = pcCalender.GetYear(currentDate);
            int month = pcCalender.GetMonth(currentDate);
            int day = pcCalender.GetDayOfMonth(currentDate);

            string NowTime = string.Format("{0:hh:mm}", Convert.ToDateTime(pcCalender.GetHour(currentDate) + ":" + pcCalender.GetMinute(currentDate)));
            return NowTime;
        }


        public static string DateTimeShamsi()
        {
            var currentDate = DateTime.Now;
            PersianCalendar pcCalender = new PersianCalendar();
            int year = pcCalender.GetYear(currentDate);
            int month = pcCalender.GetMonth(currentDate);
            int day = pcCalender.GetDayOfMonth(currentDate);

            int hour = pcCalender.GetHour(currentDate);
            int min = pcCalender.GetMinute(currentDate);

            // string shamsiDate = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(day + "/" + month + "/" + year));
            // return string.Format(@"{0}/{1}/{2} - {3}:{3} ",year , month , day , hour , min);

            return string.Format(@"{0}/{1}/{2}", year, month, day);
        }


        public static string DateTimeShamsiPayaFormat()
        {
            var currentDate = DateTime.Now;
            PersianCalendar pcCalender = new PersianCalendar();
            int year = pcCalender.GetYear(currentDate);
            int month = pcCalender.GetMonth(currentDate);
            int day = pcCalender.GetDayOfMonth(currentDate);

            int hour = pcCalender.GetHour(currentDate);
            int min = pcCalender.GetMinute(currentDate);

            // string shamsiDate = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(day + "/" + month + "/" + year));
            // return string.Format(@"{0}/{1}/{2} - {3}:{3} ",year , month , day , hour , min);

            return string.Format(@"{0}-{1}-{2}", year, month, day);
        }


    }
}
