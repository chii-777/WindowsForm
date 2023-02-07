using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm2
{
    internal class GlobalVar
    {
        
        //使用者資訊
        static public int userId;
        static public string userName;
        static public string userPhone;
        static public string userAddress;
        static public string userEmail;
        static public string userBirth;
        static public string userPsw;

        //產品資訊
        static public int productId;
        static public string productName;
        static public int productPrice;
        static public string productDesc;
        static public string productImage;

        //加入購物車
        public static List<ArrayList> orderList = new List<ArrayList>();

        static public int orderID;
        static public int orderPrice;
        static public int orderDiscount;
        static public int orderTotal;

        //管理訂單
        static public int manage_orderID;


    }
}
