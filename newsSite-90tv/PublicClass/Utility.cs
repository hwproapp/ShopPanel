using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace newsSite90tv.PublicClass
{
    //enums

    #region enum


    public enum categoryType
    {
        product , service , shop
    }

    public enum productstate
    {

        indeximagefail,
        gallaryimagefail,
        contextfail

    }

    public enum shopstate
    {
        contextfail,
        indeximagefails,

    }


    public enum ProductStatus
    {
        suspend = 0, valid = 1, invalid = 2
    }

    public enum Sex
    {
        male = 0, fmale = 1
    }


    public enum Status 
    {
        suspend,
        valid ,
        invalid 
    }
    
    public enum errorReportState
    {
        read, unread
    }



    public enum jobrequestType
    {
        sell, buy
    }

    public enum jobTag
    {
        defualt, immediate, complete
    }


    // contact us status
    public enum contactstate 
    {
        unread = 0,
        read = 1
    }

    #endregion

    //extension

    #region extension
    public static class Utility
    {
        public static int ToInt(this object val)
        {
            return Convert.ToInt32(val);
        }
        public static byte ToByte(this object val)
        {
            return Convert.ToByte(val);
        }

        public static long ToLong(this object val)
        {
            return Convert.ToInt64(val);
        }


        public static DateTime shamsitoMiladi(this string str)
        {
            var dates = str.Split('/');

            int year = ConvertfaToEndigit.toEnNumber(dates[0]).ToInt();
            int month = ConvertfaToEndigit.toEnNumber(dates[1]).ToInt();
            int day = ConvertfaToEndigit.toEnNumber(dates[2]).ToInt();

            PersianCalendar pcCalender = new PersianCalendar();
            return pcCalender.ToDateTime(year, month, day, 0, 0, 0, 0);

        }

   

        public static string Payadateformat()
        {
            PersianCalendar pc = new PersianCalendar();

            DateTime dt = DateTime.Now;

            int year = pc.GetYear(dt);
            int month = pc.GetMonth(dt);
            int day = pc.GetDayOfMonth(dt);

            int hour = pc.GetHour(dt);
            int min = pc.GetMinute(dt);
            int sec = pc.GetSecond(dt);

           
            return string.Format("{0}-{1}-{2}T{3}:{4}:{5}", year, month, day,hour , min , sec);
        }


        public static string checkStatus(this byte status)
        {
            string res = "";
            switch (status)
            {

                case 0:
                    res = "معلق";
                    break;
                case 1:
                    res = "تایید شده";
                    break;
                case 2:
                    res = "تایید نشده";
                    break;
                default:
                    break;
            }

            return res;
        }


        public static string checkbuyStatus(this byte status)
        {
            string res = "";
            switch (status)
            {

                case 0:
                    res = "معلق";
                    break;
                case 1:
                    res = "درحال خرید";
                    break;
                case 2:
                    res = "موفق";
                    break;

                case 3:
                    res = "نا موفق";
                    break;
                default:
                    break;
            }

            return res;
        }


        public static string checksellStatus(this byte status)
        {
            string res = "";
            switch (status)
            {

                case 0:
                    res = "معلق";
                    break;
                case 1:
                    res = "درحال فروش";
                    break;
                case 2:
                    res = "موفق";
                    break;

                case 3:
                    res = "نا موفق";
                    break;
                default:
                    break;
            }

            return res;
        }



        public static string checkGnder(this Sex sex)
        {
            if (sex == Sex.male)
            {
                return "آقا";
            }
            return "خانم";
        }


        public static string checkType(this byte category)
        {
            switch (category)
            {   
                case (byte)categoryType.product:
                    return "محصول";
                case (byte) categoryType.service:
                    return "کار و اشتغال";
                case (byte) categoryType.shop:
                    return "فروشگاه";
                default:
                    return "ندارد";
                   
            }
        }

        public static string GenerateToken()
        {
            return Guid.NewGuid().ToString().Replace("-" , "");
        }

        public static string GenerateImageName()
        {
          
            var guid = Guid.NewGuid().ToString();

            guid.Replace("-", "");
            guid.Replace(".", "");


            return guid;

        }


        public static string Generatecode()
        {
            string code = "";
            Random r = new Random(DateTime.Now.Second);
            for (int i = 0; i <= 10; i++)
            {
                code += r.Next(0, 10).ToString();
            }
            return code;
        }





        public static string GenerateRefId()
        {
            return Guid.NewGuid().ToString().Replace("-" , " ").Substring(0,10);
        }


        public static string GenerateMobileCode()
        {
            string code = "";
            Random r = new Random(DateTime.Now.Second);
            for (int i = 0; i < 6; i++)
            {
                code += r.Next(0, 10).ToString();
            }

            r = null;
            return code;
        }


        public static T ParseJson<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }


        public static string GetErrors(this ModelStateDictionary modelState)
        {
            return string.Join("<br />", (from item in modelState
                                          where item.Value.Errors.Any()
                                          select item.Value.Errors[0].ErrorMessage).ToList());
        }


        public static string GetErrorsApp(this ModelStateDictionary modelState)
        {
            return string.Join("/n", (from item in modelState
                                          where item.Value.Errors.Any()
                                          select item.Value.Errors[0].ErrorMessage).ToList());
        }
        public static string ToLowerFirst(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static DateTime ToPersianDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dt);
            int month = pc.GetMonth(dt);
            int day = pc.GetDayOfMonth(dt);
            int hour = pc.GetHour(dt);
            int min = pc.GetMinute(dt);

            return new DateTime(year, month, day, hour, min, 0);
        }

        public static string ToPersianDateString(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dt);
            int month = pc.GetMonth(dt);
            int day = pc.GetDayOfMonth(dt);
            int hour = pc.GetHour(dt);
            int min = pc.GetMinute(dt);
            int sec = pc.GetSecond(dt);
       
            return String.Format("{0:yyyy/M/d HH:mm:ss}", new DateTime(year, month, day, hour, min, sec));
        }

        public static DateTime ToMiladiDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0);
        }

        public static string getrealpricetoman(this object price , byte offprice)
        {
            var newprice_one =  (Convert.ToInt64(price) * offprice) / 100;

            var fresh_price = Convert.ToInt64(price) - newprice_one;

            return (fresh_price/10).ToPrice();
        }

        public static long getrealprice(this long price , byte offprice)
        {
            var newprice_one =  (price * offprice) / 100;

            var fresh_price = price - newprice_one;

            return fresh_price;
        }


        public static long getpricewithwage(this long productprice, int wage)
        {
            var newprice = (productprice * wage) / 100;

            var newprice_ = productprice - newprice;

            return newprice_;
        }


        public static long  RialToToman(this long price)
        {
            return price / 10;
        }

        public static int RialToToman(this int price)
        {
            return price / 10;
        }


        public static string ToPrice(this object dec)
        {
            string Src = dec.ToString();
            Src = Src.Replace(".0000", "");
            if (!Src.Contains("."))
            {
                Src = Src + ".00";
            }
            string[] price = Src.Split('.');
            if (price[1].Length >= 2)
            {
                price[1] = price[1].Substring(0, 2);
                price[1] = price[1].Replace("00", "");
            }

            string Temp = null;
            int i = 0;
            if ((price[0].Length % 3) >= 1)
            {
                Temp = price[0].Substring(0, (price[0].Length % 3));
                for (i = 0; i <= (price[0].Length / 3) - 1; i++)
                {
                    Temp += "," + price[0].Substring((price[0].Length % 3) + (i * 3), 3);
                }
            }
            else
            {
                for (i = 0; i <= (price[0].Length / 3) - 1; i++)
                {
                    Temp += price[0].Substring((price[0].Length % 3) + (i * 3), 3) + ",";
                }
                Temp = Temp.Substring(0, Temp.Length - 1);
                // Temp = price(0)
                //If price(1).Length > 0 Then
                //    Return price(0) + "." + price(1)
                //End If
            }
            if (price[1].Length > 0)
            {
                return Temp + "." + price[1];
            }
            else
            {
                return Temp;
            }
        }
        public static string Encrypt(this string str)
        {
            byte[] encData_byte = new byte[str.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encData_byte);
        }

        public static string Decrypt(this string str)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(str);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            return new string(decoded_char);
        }

        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static string UrlDecode(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string getposttime(DateTime dateMiladi)
        {
            string time = "";

            try
            {
                TimeSpan x = DateTime.Now - dateMiladi;

                
                
                var day = x.Days;

                time = day.ToString();

                if (day > 0)
                {

                    var count = day;


                    if (day >= 7 && day < 30)
                    {
                        count = day / 7;
                       
                        time = timeformat(getfarsiletter(count), "هفته پیش");

                    }
                    else if (day >= 30 && day < 365)
                    {
                        count = day / 30;
                        time = timeformat(getfarsiletter(count), "ماه پیش");

                    }
                    else if (day >= 365)
                    {
                        count = day / 365;
                        time = timeformat(getfarsiletter(count), "روز پیش");


                    }else
                    {
                        time = timeformat(getfarsiletter(count), "روز پیش");
                    }

                }
                else if (x.Hours > 0)
                {
                 

                    time = timeformat(getfarsiletter(x.Hours), "ساعت پیش");

                }
                else
                {
                    time = "دقایقی پیش";
                }


                   
            }
            catch (Exception)
            {

                time = "یک روز پیش";
            }

            return time;
        }

        internal static string getjobtag(byte tag)
        {
            switch (tag)
            {
                case (byte)jobTag.complete:
                    return "برجسته";
                case (byte)jobTag.defualt:
                    return "عادی";
                case (byte)jobTag.immediate:
                    return "فوری";
                default:
                    return "";
            }
        }


        public static string getfarsiletter(int number)
        {
            string[] faarr = { "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه", "ده" };

            if (number > 0 && number <= 10)
            {
                return faarr[number - 1];
            }
            else
            {
                return number.ToString();
            }
        }


        public  static string timeformat(string time , string type)
        {
            return    string.Format("{0} {1}", time , type);
        }


        public static bool validphone(string value)
        {
            return Regex.IsMatch(value, @"^09[0|1|2|3][0-9]{8}$");
        }


        public static string bannertime(DateTime createtime)
        {
            var compare  =  DateTime.Now - createtime;
            var time = "";

            if (compare.Days == 0)
            {
                // hour , min , sec
                if (compare.Hours == 0)
                {
                    // min , sec

                    if (compare.Minutes ==0)
                    {
                        //  sec
                        time = "چند ثانیه پیش";
                    }
                    else
                    {
                        switch (compare.Minutes)
                        {
                            case 15:
                                time = "یک ربع پیش";
                                break;
                            case 30:
                                time = "نیم ساعت پیش";
                                break;
                            default:
                                time = "دقایقی  پیش";
                                break;
                        }
                    }
                }
                else
                {
                    time = "ساعاتی پیش";
                }
            }
            else
            {
                int myday = compare.Days;
               
                if (myday ==1)
                {
                    time = "دیروز";
                }
                else if (myday ==2)
                {
                    time = "پریروز";
                }
                else if (myday >=7 && myday < 14)
                {
                    time = "یک هفته پیش";
                }
                else if (myday >= 14 && myday < 21)
                {
                    time = "دو هفته پیش";
                }
                else if (myday >= 21 && myday < 30)
                {
                    time = "سه هفته پیش";
                }
                else if (myday  >= 30)
                {
                    time = "یکماه پیش";
                }
                else
                {
                    time = "مدتی پیش";

                  
                }
                
            }
             


            return time;
        }

        
    }


    #endregion





}
