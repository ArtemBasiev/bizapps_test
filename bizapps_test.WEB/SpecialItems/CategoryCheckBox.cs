using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace bizapps_test.WEB.SpecialItems
{
    public class CategoryCheckBox: CheckBox
    {
       public int CategoryId { get; set; }



        public CategoryCheckBox(string categoryName, int categoryId, bool isChecked)
        {
            this.Text = categoryName;
            this.CategoryId = categoryId;
            this.Checked = isChecked;
        }

        public CategoryCheckBox(string categoryName, int categoryId)
        {
            this.Text = categoryName;
            this.CategoryId = categoryId;
        }


        public CategoryCheckBox()
        {

        }


    }
}