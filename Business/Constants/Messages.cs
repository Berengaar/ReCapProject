using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    static public class Messages
    {
        #region CRUD
        internal static string Meintanance = " Sistem bakımda";
        internal static string Listed = " Listelendi";
        internal static string Added = " Sisteme Eklendi";
        internal static string Deleted = " Sistemden silindi";
        internal static string Updated = " Güncellendi";
        #endregion


        #region Errors
        internal static string ErrorPassword = "Parola 5 karakterden az olamaz";
        internal static string ErrorPrice = "Araba fiyatı 0'dan büyük olmalıdır";
        internal static string ErrorRental = "Araba teslim edilmedi,kiranalamaz";
        #endregion

        #region Entities
        internal static string Car = "Araba";
        internal static string CarImage = "Araba Resmi";
        internal static string User = "Kullanıcı";
        internal static string Customer = "Müşteri";
        internal static string Color = "Renk";
        internal static string Model = "Model";
        internal static string Rental = "Kiralama";
        internal static string Brand = "Model";
        #endregion


        
    }
}
