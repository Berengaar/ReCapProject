using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        internal static string ErrorLimitExceeded = "Limit aşıldı";
        internal static string ErrorUserNotFound = "Kullanıcı bulunamadı";
        internal static string ErrorUserAlreadyExist = "Kullanıcı zaten mevcut";
        #endregion

        #region Successful
        internal static string SuccessfulLogin = "Giriş başarılı";
        internal static string SuccessfulRegister = "Kayıt başarılı";
        internal static string SuccessfulCreatedToken = "Token oluşturma başarılı";
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

        #region Validation 
        internal static string NotEmpty = "Boş olamaz";
        internal static string MinimumLength = "Karakter sayısı yetersiz";
        internal static string EmailCheck = "Email Kontrol edildi";
        internal static string AuthorizationDenied = "hata";
        internal static string RentDateNull;
        internal static string ReturnDate;
        internal static string ModelNameLength;
        public static string CarNotFound = "Car not found";
        internal static object ValidImageFileTypes;

        #endregion



    }
}
