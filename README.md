# MAUI_MultiToolApp

**MAUI_MultiToolApp**, .NET MAUI platformu kullanılarak geliştirilmiş çok sayfalı bir mobil uygulamadır.  
Uygulama, öğrencilerin çeşitli hesaplamalar ve renk seçimleri yapabilmesini sağlar.

---

## Proje Amacı

Bu proje, .NET MAUI platformunda çok sayfalı mobil uygulamalar geliştirebilmesini, kullanıcı etkileşimlerini yönetebilmesini, veri girişleriyle hesaplamalar yapabilmesini ve arayüz öğelerini etkin biçimde kullanabilmesini amaçlar.

---

## Sayfalar ve Özellikler

### 1. Ana Sayfa
- Geliştiricinin adı ve soyadı (`Label` kontrolü ile)
- Profil resmi (`Image` kontrolü ile)
- Sade, anlaşılır ve kullanıcı dostu arayüz

### 2. Kredi Hesaplama Sayfası
- **Kredi Türü**: `Picker` ile seçim (İhtiyaç, Taşıt, Konut)
- **Kredi Tutarı**: `Entry` ile kullanıcı girişi
- **Faiz Oranı (%)**: `Entry` ile kullanıcı girişi
- **Vade (Ay)**: `Slider` ile seçim, yanında etiketle gösterim
- **Hesapla Butonu**: Kredi hesaplaması yapılır ve sonuç etikette gösterilir

### 3. Vücut Kitle İndeksi (VKİ) Hesaplama
- **Kilo (kg)** ve **Boy (cm)**: `Slider` ile seçilebilir
- VKİ değeri dinamik olarak hesaplanır ve etikette gösterilir
- Formül: `VKİ = Kilo / (Boy(m) * Boy(m))`

### 4. Renk Seçici Sayfası
- **RGB Ayarları**: Slider ile R, G, B değerleri
- **Oluşturulan Renk Kodu**: `#RRGGBB` etiketi
- **Kopyala Butonu**: Renk kodunu panoya kopyalar
- **Rastgele Renk Butonu**: Slider’lara rastgele değerler atar
- Sayfa arka planı seçilen veya oluşturulan renk ile dinamik olarak güncellenir

---

## Kullanılan Teknolojiler

- .NET MAUI (C#)
- XAML ile kullanıcı arayüzü tasarımı
- MVVM tasarım deseni
- Dinamik veri bağlama (Binding)
- Event ve Slider kontrolleri ile etkileşim

---

## Kurulum

1. .NET 7 SDK ve Visual Studio 2022 veya üstü yüklü olmalıdır.
2. GitHub’dan projeyi klonlayın:
```bash
git clone https://github.com/username/MAUI_MultiToolApp.git

Bu proje Ferhat Kocaosmanlı tarafından geliştirilmiştir.
