using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Message
    {
        public static string CanNotBeAddedCar = "Araba eklenemedi";
        public static string AddedCar = "Araba başarıyla eklendi";
        public static string DeletedCar = "Araba başarıyla silindi";
        public static string UpdatedCar = "Araba başarıyla güncellendi";

        public static string CanNotBeAddedBrand = "Marka eklenemedi";
        public static string AddedBrand = "Marka başarıyla eklendi";
        public static string DeletedBrand = "Marka başarıyla silindi";
        public static string UpdatedBrand = "Marka başarıyla güncellendi";

        public static string CanNotBeAddedColor = "Renk eklenemedi";
        public static string AddedColor = "Renk başarıyla eklendi";
        public static string DeletedColor = "Renk başarıyla silindi";
        public static string UpdatedColor = "Renk başarıyla güncellendi";

        public static string CanNotBeAddedUser = "Kullanıcı eklenemedi";
        public static string AddedUser = "Kullanıcı başarıyla eklendi";
        public static string DeletedUser = "Kullanıcı başarıyla silindi";
        public static string UpdatedUser = "Kullanıcı başarıyla güncellendi";

        public static string CanNotBeAddedCustomer = "Müşteri eklenemedi";
        public static string AddedCustomer = "Müşteri başarıyla eklendi";
        public static string DeletedCustomer = "Müşteri başarıyla silindi";
        public static string UpdatedCustomer = "Müşteri başarıyla güncellendi";

        public static string ListedCar = "Arabalar Listesi başarıyla oluşturuldu";
        public static string CanNotListedCar = "Arabalar Listesi  oluşturulamadı";
        public static string DetailsCar = "Detaylı arabalar listesi başarıyla oluşturuldu";

        public static string ListedCustomer = "Müşteriler Listesi başarıyla oluşturuldu";
        public static string CanNotListedCustomer = "Müşteriler Listesi  oluşturulamadı";
        public static string DetailsCustomer = "Detaylı müşteriler listesi başarıyla oluşturuldu";

        public static string ListedColor = "Renkler Listesi başarıyla oluşturuldu";
        public static string CanNotListedColor = "Renkler Listesi  oluşturulamadı";
        public static string DetailsColor = "Detaylı renkler listesi başarıyla oluşturuldu";

        public static string CanNotListedBrand = "Markalar Listesi  oluşturulamadı";
        public static string ListedBrand = "Markalar Listesi başarıyla oluşturuldu";
        public static string DetailsBrand = "Detaylı markalar listesi başarıyla oluşturuldu";

        public static string ListedUser = "Kullanıcı Listesi başarıyla oluşturuldu";
        public static string CanNotListedUser = "Kullanıcı Listesi  oluşturulamadı";
        public static string DetailsUser = "Detaylı Kullanıcı listesi başarıyla oluşturuldu";

        public static string CanNotBeAddedRental = "Kiralama işlemi eklenemedi";
        public static string AddedRental = "Kiralama işlemi başarıyla eklendi";
        public static string DeletedRental = "Kiralama işlemi başarıyla silindi";
        public static string UpdatedRental = "Kiralama işlemi başarıyla güncellendi";
        public static string CanNotListedRental = "Kiralama Listesi  oluşturulamadı";
        public static string ListedRental = "Kiralama Listesi başarıyla oluşturuldu";
        public static string CarImageLimitedExceeded = "Resim ekleme sınırı aşıldı.";

        public static string CarImageListed = "Araba Resimleri listelendi ";
        public static string CarImageAdded = "Car image added.";
        public static string CarImageDeleted = "Car image deleted.";
        public static string CarImageUpdated = "Car image updated.";
        public static string CarImageNotFound = "Car image not found";
        public static string CarImageNumberError = "Resim sayısı hatası";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists= "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";

        public static string AuthorizationDenied="Yetkiniz yok.";

        public static string ProductUpdated="Ürün başarıyla güncellendi";
    }
}
