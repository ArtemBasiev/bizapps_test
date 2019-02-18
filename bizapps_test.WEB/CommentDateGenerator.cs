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
                    dateString = string.Format("{0:0}", deferenceDate.TotalMinutes)+" meanutes ago";
                }
                else
                {
                    if ((deferenceDate.TotalHours >= 1) && (deferenceDate.TotalHours < 24))
                    {
                        dateString = string.Format("{0:0}", deferenceDate.TotalHours) + " hours ago";
                    }
                    else
                    {
                        if ((deferenceDate.TotalDays >= 1) && (deferenceDate.TotalDays < 31))
                        {
                            dateString = string.Format("{0:0}", deferenceDate.TotalDays) + " days ago";
                        }
                        else
                        {
                            if ((deferenceDate.TotalDays >= 31) && (deferenceDate.TotalDays < 365))
                            {
                                dateString = string.Format("{0:0}", deferenceDate.TotalDays/30) + " months ago";
                            }
                            else
                            {
                                if (deferenceDate.TotalDays > 365)
                                {
                                    dateString = string.Format("{0:0}", deferenceDate.TotalDays / 365) + " years ago";
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