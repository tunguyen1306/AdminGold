using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] t = { 1, 3, 5, 7, 6, 8, 9 };

            //int temp = 0;
            //for (int i = 0; i < t.Length - 1; i++)
            //{
            //    for (int j = i + 1; j <= t.Length - 1; j++)
            //    {
            //        if (t[i] > t[j])
            //        {
            //            temp = t[i];
            //            t[i] = t[j];
            //            t[j] = temp;

            //        }
            //    }

            //}
           // buble();
            pub();

        }
        void buble()
        {
            var curent = 0;
            int[] n = { 1, 3, 5, 7, 6, 8, 9 };
            for (int i = 0; i < n.Length; i++)
            {
                 curent = n[i];
                int k;
                for ( k = i-1;k>0 && n[k]>curent ; k--)
                {
                    n[k + 1] = n[k];
                }
                n[k + 1] += curent;
            }
            Label1.Text = curent.ToString();
        }
       void pub()
        {
            int[] t = {11,5,4,2,7,9,8,1};
            int temp=0;
            for (int i = 0; i < t.Length-1; i++)
            {
                for (int j = i+1; j <= t.Length-1; j++)
                {
                    if (t[i] > t[j])
                    {
                        temp = t[i];
                        t[i] = t[j];
                        t[j] = temp;
                       

                    }
                }
                Label1.Text += temp.ToString();
            }
           


        }
    }
}