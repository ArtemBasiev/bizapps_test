using System;


namespace bizapps_test.WEB
{
    public static class CommentDateGenerator
    {
        public static string GetDateString(DateTime inputDate)
        {
            string dateString="";
            TimeSpan deferenceDate = DateTime.Now - inputDate;
            if ((deferenceDate.TotalMinutes <= 1)&&(deferenceDate.TotalSeconds > 0))
            {
                dateString = "Now";
            }
            else
            {
                if ((deferenceDate.TotalMinutes > 1) && (deferenceDate.TotalMinutes < 60))
                {
                    dateString = Math.Round(deferenceDate.TotalMinutes, 0, MidpointRounding.ToEven)+" minutes ago";
                }
                else
                {
                    if ((deferenceDate.TotalHours >= 1) && (deferenceDate.TotalHours < 24))
                    {
                        dateString = Math.Round(deferenceDate.TotalHours, 0, MidpointRounding.ToEven) + " hours ago";
                    }
                    else
                    {
                        if ((deferenceDate.TotalDays >= 1) && (deferenceDate.TotalDays < 31))
                        {
                            dateString = Math.Round(deferenceDate.TotalDays, 0, MidpointRounding.ToEven) + " days ago";
                        }
                        else
                        {
                            if ((deferenceDate.TotalDays >= 31) && (deferenceDate.TotalDays < 364))
                            {
                                dateString = Math.Round(deferenceDate.TotalDays/30, 0, MidpointRounding.ToEven)+ " months ago";
                            }
                            else
                            {
                                if (deferenceDate.TotalDays > 364)
                                {
                                    dateString = Math.Round(deferenceDate.TotalDays / 364, 0, MidpointRounding.ToEven) + " years ago";
                                }
                            }
                        }
                    }
                }
            }

            return dateString;
        }
    }
}