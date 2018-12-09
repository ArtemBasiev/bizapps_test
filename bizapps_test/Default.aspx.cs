using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Drawing;

namespace bizapps_test
{
    public partial class Default : System.Web.UI.Page
    {

        public FbConnection fb;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //////////////////////////////////Выполняем подключение к базе данных
            try
            {
                string path = Server.MapPath(@"DataBase\BIZ_TEST.FDB");

                FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder();

                fb_con.Charset = "UTF8";
                fb_con.UserID = "SYSDBA";
                fb_con.Password = "masterkey";
                fb_con.Database = path;
                fb_con.ServerType = 0;
                fb = new FbConnection(fb_con.ToString());
                fb.Open();

                ////////////////////////////////Заполняем список категорий
                FbCommand sqlforkat = new FbCommand("select KAT from SEL_KATEGORY", fb);
                FbDataReader readerkat = sqlforkat.ExecuteReader();
                DataTable dt_kat = new DataTable();
                dt_kat.Load(readerkat);

                KategoryList.Items.Clear();

                 for (int i=0; i<dt_kat.Rows.Count; i++)
                  {
                      
                KategoryList.Items.Add(dt_kat.Rows[i][0].ToString());
                 }
                

            }
            catch
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = "Проблемы с подключением к БД";
            }
        }

        protected void cr_kat_Click(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////Выполняем проверку создаваемой категории
                FbCommand sqlforname = new FbCommand("select * from CREATE_KATEGORY('" + Text1.Text.ToUpper()+ "')", fb);
                FbDataReader readername = sqlforname.ExecuteReader();
                DataTable dt_name = new DataTable();
                dt_name.Load(readername);

                if (dt_name.Rows[0][1].ToString() == "1")
                {
                    LabelMes.ForeColor = Color.Green;
                }
                else
                {
                    LabelMes.ForeColor = Color.Red;
                }
                LabelMes.Text = dt_name.Rows[0][0].ToString();
            }
            catch
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = "Проблемы с подключением к БД";
            }
            Text1.Text = "";
        }
    }
}