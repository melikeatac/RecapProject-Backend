using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        /*ona verdiğimiz passwordun hashini oluşturur.Aynı zamanda saltını da oluşturacak yapı.*/
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; /*burada salt olara hmac algoritmasının key değerini kullanıyoruz.Her kullanıcı
                                          için başka bir key oluşturur. Güvenlidir.*/
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));/*buradaki password-->Hashlenmesi için verilen
                                                                                   aşağıdaki password ikinci girişte hashler eşit mi
                diye bakacağımız password*/
            }
        }

        //password hashi doğrulamak için kullanılacak metod. 
        //Buradaki password sonradan girilen password.Onu da tekrar hashleyip ilkiyle aynı mı diye bakacağız..
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)/*Burada out olmamalı çünkü bu değerleri biz vereceğiz*/
        {
            /*Örneğin kullanıcı password olarak 123456 gönderdi sen bu passwordu yine aynı algoritmayı kullanarak hashleseydin 
            karşına passwordHash dizindeki gibi bir şey çıkar mıydı çıkmaz mıydı? Veritabanındaki hash ile kullancının gönderdiği
            hashi karşılaştırıyoruz. Eğer hash değerleri birbiryle eşse o zaman true değilse false*/
            /*yukarıdaki string password kullanıcın girdiği parola*/
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;

        }

    }
}