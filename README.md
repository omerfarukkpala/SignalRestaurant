# Pala Restoran      
### 🚀 Asp.Net Core ile Çok Katmanlı, Real-Time Restoran Yönetim Sistemi Projesi! 🚀       
    
🧩Bu projede, admin ve vitrin panellerini barındıran, SOLID prensiplerine sadık kalarak Clean Code prensiplerinde kodladığımız kapsamlı bir Restoran yönetim sistemi geliştirildi. 💻
    
            
https://github.com/user-attachments/assets/62fde126-543c-46b1-8d70-218fb273539f 
         
          
- 🟢 Projenin Temel Amacı: Restoran rezervasyonları ve online sipariş işlemlerini kapsamlı bir şekilde yönetir. Kullanıcılar, restorana online sipariş verebilir veya rezervasyon oluşturabilirler. Siparişler ve rezervasyonlar admin panelinde SignalR teknolojisi kullanılarak anlık olarak takip edilebilir. Bu sayede admin, siparişleri veya rezervasyonları onaylayabilir, iptal edebilir ve kullanıcılar anlık bildirim alır. Ayrıca, tüm bildirimler ve sipariş durumu değişiklikleri, kullanıcılara e-posta yoluyla iletilir. 

- 🌟 Teknik Detaylar ve Özellikler: Bu projede ASP.NET Core  ve SignalR teknolojilerinin yanı sıra, çeşitli kütüphaneler ve mimari desen kullanarak sistemi geliştirdim. Projeyi daha modüler ve sürdürülebilir bir hale getirmek için N Katmanlı Mimari yapısına yer verdim.

- 📲 Kullanıcı Etkileşimi ve Anlık Bildirimler: Kullanıcılar, admin paneline öneri, talep, ve şikayet gibi konularda mesaj gönderebilir. Bu mesajlar, SignalR teknolojisi sayesinde anlık olarak admin dashboard'unda görüntülenir ve admin kullanıcı, mesajları hızlıca yanıtlayabilir. Böylece kullanıcılar ve restoran yönetimi arasında güçlü bir anlık iletişim sağlanır.

- 🪑 Masa Durumları ve Verimli Yönetim: Restoran içerisindeki masaların dolu veya boş olduğu durumlar sistem üzerinden gerçek zamanlı olarak takip edilebilir. Bu sayede, masaların doluluk durumuna göre hızlı ve verimli bir masa yönetimi sağlanır. Admin panelindeki dashboard, masaların durumunu anlık olarak güncelleyerek yönetimin işini kolaylaştırır.
 
  
 
  
# 🔧  Projede Öne Çıkan Özellikler:

- 🌐 Real-Time Veri Takibi: SignalR ile sayfa yenilemeden, anlık sipariş ve bildirim takibi.
- 💡 N-Tier Architecture & Repository Design Pattern: Düzenli ve sürdürülebilir bir yapı.
- 📧 Rezervasyon Mail Gönderimi: Müşterilere rezervasyon onayları MailKit üzerinden gönderiliyor.
- 📊 Real-Time İstatistikler & Anlık Bildirimler: Admin paneli üzerinden anlık mesajlaşma, bildirim ve sipariş takibi.
- 🍲 Rapid API ile Dünya Mutfağından Tarifler: Kullanıcılar, global yemek tariflerine anlık olarak erişebiliyor.

# 📌 Backend Teknolojileri:
- 🌍 ASP.Net C# & ASP.Net Core API : Performans odaklı, sağlam altyapı.
- 🔗 SignalR : Gerçek zamanlı veri aktarımı.
- 🗃️ MSSQL Veri Tabanları : Hızlı ve güvenilir veri saklama.
- 🔄 Code First Yaklaşımı : Esnek veri tabanı yönetimi.
- 📜 Swagger ile API Dokümantasyonu : API şeffaflığı ve kolay entegrasyon.


# ✨ Frontend Teknolojileri:
- 🖥️ HTML & CSS & JavaScript
- 🎨 Bootstrap :  Responsive arayüz.

# 🗂️ Kullanılan Yapılar ve Desenler:
- 🏛️ MVC (Model-View-Controller) : Katmanlı yapı ile kolay yönetilebilirlik.
- 🧩 Repository & Service Katmanları : Veriyi etkili bir şekilde işleme ve yönetme.
- ⚙️ AutoMapper ile DTO Eşlemeleri : Entity-DTO eşlemeleri ile daha hızlı geliştirme.
- 🔐 Identity ile Güvenlik : Güvenli giriş ve kullanıcı yönetimi.
- 📲 Ajax ile hızlı veri güncellemeleri : Kullanıcı etkileşimleri için hızlı ve verimli güncellemeler.
- 📧 Mail Kit : Otomatik bildirimler.

# 🔑 Projenin İşlevleri:
- 🕹️ Anlık Bildirim ve Sipariş Takibi: Kullanıcılar, oturdukları masaya göre sipariş verebilir, sepet yönetimi yapabilir.
- 📝 Rezervasyon Yönetimi: Müşteriler, rezervasyon yaparak restoran yönetimine kolayca ulaşabilir.Rezervasyonlarını ve masalarını görüntüleyebilir.
- 📊 Gerçek Zamanlı İstatistikler: Admin panelinde istatistikler, masa doluluk durumları anlık olarak güncellenir.Admin panelinde, dolu/boş masa durumu gibi istatistikler anlık olarak güncelleniyor.
- 💬 Anlık Mesajlaşma: Admin ve kullanıcılar arasında canlı mesajlaşma imkanı.Admin ve kullanıcılar arasında hızlı iletişim sağlandı, mesajlar anında iletiliyor.
- 🏆 Bu proje ile SignalR’ın gücünü kullanarak restoran yönetim sistemini modernize ettik ve kullanıcı deneyimini üst seviyeye çıkardık!

# 🛠️ Ekstra Özellikler:

- 📈 Gelişmiş Dashboard ve Görselleştirme: Admin panelinde istatistikler ve önemli bilgiler kullanıcı dostu bir arayüzde sunuluyor.
- 📅 Anlık Rezervasyon Güncellemeleri: Kullanıcı rezervasyonları SignalR ile gerçek zamanlı olarak güncelleniyor.
- 🧮 CRUD İşlemleri: Sistem genelinde CRUD işlemlerinin tamamı kullanıcı dostu arayüzlerle entegre edildi.
- 🍲 Yemek Tarifleri Videoları: Kullanıcılar, sistem üzerinden videolu tariflere ulaşarak daha fazla bilgi edinebilir.
- 🔒 Güçlü Güvenlik: Kullanıcı kimlik doğrulama süreçlerinde Identity kullanılarak güvenlik sağlandı.

 ### Veritabanı 
 ![image](https://github.com/user-attachments/assets/fe6f4569-5697-4e17-bc23-59cff4033d28)

 ### ☞ Anasayfa Default/Index/
 ![screencapture-localhost-7292-Default-Index-2024-11-03-12_19_40](https://github.com/user-attachments/assets/d97599f4-f565-4b6f-b8f0-8c7525cd7fc8)
#### Menu Menu/Index/ 
![screencapture-localhost-7292-Menu-Index-2024-11-03-12_22_39](https://github.com/user-attachments/assets/c7585e51-ae9e-4ee8-9254-f603715b9b41)
### ☞ Ürün Satın Alma
![image](https://github.com/user-attachments/assets/6a874e86-e96c-42d6-bac8-0e895c0b7fef)
#### ☞ Ürün Ekleme 2 ![image](https://github.com/user-attachments/assets/16716336-74bd-4d6c-a3bd-360edc35c350)
### ☞ Lezzetli Tarifler /FoodRapidApi/Index/
 ![image](https://github.com/user-attachments/assets/22c93da0-98dd-4d6a-aa30-3cbc2c35f455)
### Rezervasyon /BookATable/Index/
![screencapture-localhost-7292-BookATable-Index-2024-11-03-12_25_26](https://github.com/user-attachments/assets/9e2079fa-4750-4851-8b58-7e37c7047bb9)

### ☞ SiqnalR Mesajlaşma /Message/Index
![screencapture-localhost-7292-Message-Index-2024-11-03-12_43_54](https://github.com/user-attachments/assets/e45c276d-804c-49b7-8502-d5688546eba1)


### ☞ Basket /Basket/Index/
![screencapture-localhost-7292-Basket-Index-2024-11-03-12_34_07](https://github.com/user-attachments/assets/038acded-d794-4e24-85d6-f7b7008b6e48)

### ☞ Register Register/Index/
![image](https://github.com/user-attachments/assets/07eff0b2-9358-485c-9fe6-782390e63e3e)

### ☞ Login/Index
![image](https://github.com/user-attachments/assets/0af78cdd-6523-42a8-a014-9ec7c14764b0)

### ☞ Dashboard
![image](https://github.com/user-attachments/assets/cc48a1e9-f405-4ef6-8b30-d53c7d0cc533)

### ☞ Anlık İstatistik Sayfası
![image](https://github.com/user-attachments/assets/4c72c36e-6885-44df-941e-e47cca75ab07)
### ☞ Masa Durumları
![screencapture-localhost-7292-TableDetail-TableListByStatus-2024-11-03-12_58_50](https://github.com/user-attachments/assets/88243c33-b3c0-47ba-81f9-6b55f31f62de)
### ☞ Kategoriler 
![screencapture-localhost-7292-Category-Index-2024-11-03-13_00_25](https://github.com/user-attachments/assets/5097a068-f009-4f5f-8776-bb4102ba2e98)

### ☞ Ürünler Product/Index/
![screencapture-localhost-7292-Product-Index-2024-11-03-13_01_56](https://github.com/user-attachments/assets/8ab92d0a-89a3-4cef-8427-3c6248f9bddc)

### ☞ Masalar 
![screencapture-localhost-7292-TableDetail-Index-2024-11-03-13_42_01](https://github.com/user-attachments/assets/485359f1-31b7-448e-9ee4-dee2e456cf3f)

### ☞ İndirimler Discount Discount/Index/
![screencapture-localhost-7292-Discount-Index-2024-11-03-13_43_44](https://github.com/user-attachments/assets/7bdbf209-18a5-42a5-a238-f8e503f2a0d9)

### ☞ İletişim Bilgileri
![image](https://github.com/user-attachments/assets/f1bdef2e-75f5-478c-99e3-1a3756c800e3)

### ☞ Referans Yorumları 
![image](https://github.com/user-attachments/assets/219625f6-5c2b-4bf0-a1ee-95e222a3d000)

### ☞ QR Kodu İşlemleri

###  ☞ Mail İşlemleri Mail/Index
![image](https://github.com/user-attachments/assets/e13093a7-b8ae-460b-a9b1-7a5afe0f8049)
#### ☞ Error Page Error/NotFound404Page/
![screencapture-localhost-7292-Error-NotFound404Page-2024-11-03-12_39_19](https://github.com/user-attachments/assets/a1dea7fb-1a66-4fbc-adfa-1bf04f3f2139)

# ☞ Api
![screencapture-localhost-5002-swagger-index-html-2024-11-03-10_52_46](https://github.com/user-attachments/assets/caf78c5c-6d19-4410-a9ad-57241d46aecd)

 ### ☞ About 
![image](https://github.com/user-attachments/assets/6950e3ea-df44-47c6-9d16-2ff193a311ed)
#### ☞  About Get 
![image](https://github.com/user-attachments/assets/b2e6f644-ff10-442d-ab7b-950f11dd90a8)
#### ☞ About Post 
![image](https://github.com/user-attachments/assets/62af3919-a224-41ea-b777-0780863e8c43)
#### ☞ About Put 
![image](https://github.com/user-attachments/assets/da2fa47f-144e-4101-a5a3-8b1bb4f20326)
#### ☞ About Delete 
![image](https://github.com/user-attachments/assets/907fa61d-602f-4d37-b163-1dc8bdc875bb)
#### ☞ About Id 
![image](https://github.com/user-attachments/assets/0a2eb4e9-8fd6-486f-98e4-120f72538611)

### ☞ Basket
![image](https://github.com/user-attachments/assets/433cb595-ce08-4fe5-af74-a123110a6621)
#### ☞ Basket Get 
![image](https://github.com/user-attachments/assets/d2ed6da0-c27b-457e-9e02-69292e9c7e42)
#### ☞ Basket Post 
![image](https://github.com/user-attachments/assets/0a5e164d-3905-47d0-86a1-0031f5d84b62)
#### Basket Delete
![image](https://github.com/user-attachments/assets/d5f1989f-8e75-488b-bfb2-35710519612b)

### ☞ Booking
![image](https://github.com/user-attachments/assets/f392f097-b98e-4270-944d-ab382b78362e)
#### ☞ Booking Get 
![image](https://github.com/user-attachments/assets/c80097bd-db95-4e91-870d-f5d7f5037faa)
#### ☞ Booking Post
![image](https://github.com/user-attachments/assets/65b77a5f-86a9-450a-97e6-eb1f9ed360f0)
#### ☞ Booking Put
![image](https://github.com/user-attachments/assets/b0a3f39f-2812-4272-86cc-28b8497d14b4)
#### ☞ Booking Delete
![image](https://github.com/user-attachments/assets/13084078-a414-4d41-b4b3-f7c61c50cd57)
#### ☞Booking Id
![image](https://github.com/user-attachments/assets/bcb29839-886c-4b39-97b5-9914d3f9c6db)
#### ☞ /api/Booking/BookingStatusApproved/{id}
![image](https://github.com/user-attachments/assets/219a0415-96f2-4a00-9e56-f53fef377a64)
#### ☞ Booking Cancalled /api/Booking/BookingStatusCancelled/{id}
![image](https://github.com/user-attachments/assets/00a793d6-94eb-4f27-9247-1aadfad6f184)

### ☞ Category
![image](https://github.com/user-attachments/assets/deab483f-1e76-4c1a-898c-8394de90f244)
#### ☞ Category Get  /api/Category
![image](https://github.com/user-attachments/assets/be7d178a-3af6-4a57-aea9-92113cbe6833)
#### ☞ Category Post /api/Category
![image](https://github.com/user-attachments/assets/f97fc5ae-3887-4dd5-b962-cc80fc858656)
#### ☞ Category Delete /api/Category
![image](https://github.com/user-attachments/assets/98645e1e-4c87-44d7-b334-ec69cc8dd6a7)
#### ☞ Category Put  /api/Category
![image](https://github.com/user-attachments/assets/3d88d7f9-a618-44a6-90b7-908d1ff17560)
#### ☞ Category Count  /api/Category/CategoryCount
![image](https://github.com/user-attachments/assets/e4315c40-fee5-487a-857e-ed3f19590e05)
#### ☞ Category Active  Count  /api/Category/ActiveCategoryCount
![image](https://github.com/user-attachments/assets/ef9a6992-c355-4ff6-a8aa-f224c533a239)
#### Category Passive Count  /api/Category/PassiveCategoryCount
![image](https://github.com/user-attachments/assets/06a79cd7-fa86-4212-b02d-5ffe5d4e3de7)
#### ☞ /api/Category/GetCategory
![image](https://github.com/user-attachments/assets/0997963b-6381-4017-902d-60fe9e7cc742)

#### ☞ Contacts
![image](https://github.com/user-attachments/assets/6c78a9aa-8219-4411-b031-d48c85622a9a)
#### ☞ Discount
![image](https://github.com/user-attachments/assets/45af1175-0cec-45bf-8801-06381bbac42a)
#### ☞ MenuTables
![image](https://github.com/user-attachments/assets/36454853-5f59-4242-bd84-8c56fd2410a8)
##### ☞ Messages
![image](https://github.com/user-attachments/assets/104063eb-35b8-4ca8-aeba-0b22e6447b7b)
##### ☞ MoneyCases
![image](https://github.com/user-attachments/assets/f7ebb4c3-e4b6-46ea-b26c-e655d855fcee)
##### ☞ Notification
![image](https://github.com/user-attachments/assets/d4a22ab7-e272-497c-923c-0ccf110a83e3)
##### ☞ Orders
![image](https://github.com/user-attachments/assets/01b6ce46-50c6-4c4f-8918-929b384619aa)

##### ☞ Product
![image](https://github.com/user-attachments/assets/33716146-8ab5-41f2-b179-0db0c9461bfc)

##### ☞ Get Product
![image](https://github.com/user-attachments/assets/322953c9-320a-47bb-ae84-27d671ad5e54)
##### ☞ /api/Product/ProductListWithCategory
![image](https://github.com/user-attachments/assets/c93ab158-ae5f-47a8-a8a4-46f8c13427bb)

##### ☞ Slider
![image](https://github.com/user-attachments/assets/91c22cef-77c3-481a-9185-934e62f941b0)

##### ☞ Social Media 
![image](https://github.com/user-attachments/assets/1ad6ce1b-ea5f-438c-b550-9bef9f3584b9)

##### ☞ Table Details
![image](https://github.com/user-attachments/assets/4972c088-bdba-457d-81a6-9e3ab3075013)

##### ☞ Testimonial
![image](https://github.com/user-attachments/assets/7ebb9154-faf2-46b2-8e67-8cb299bd8e23)





 
 
 
 
 
