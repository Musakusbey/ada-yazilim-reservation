# 🚂 Ada Yazılım Reservation API

Bu proje, **Ada Yazılım** iş başvurusu kapsamında geliştirilmiştir.  
Amaç, bir tren rezervasyon sistemi için HTTP tabanlı bir API geliştirmek ve belirli kurallar çerçevesinde rezervasyonların yapılıp yapılamayacağını hesaplamaktır.

API, kullanıcıdan aldığı tren ve vagon bilgilerine göre, yolcu yerleşimlerini kontrol eder ve uygun yerleşim planını JSON formatında geri döner.

---

## 📖 Proje Amacı

Trenlerde yapılan **online rezervasyonlarda** bazı kurallar vardır:

1. Her vagonun kendine ait kapasitesi vardır.
2. Rezervasyon yapılırken, bir vagonun doluluk oranı **%70’i geçemez**.
   - Örn: Vagon kapasitesi 100 ise, maksimum 70 koltuk rezerve edilebilir.
3. Bir rezervasyon talebi **birden fazla kişi için** olabilir.
4. Kullanıcı, yolcuların **tek vagonda mı yoksa farklı vagonlara dağılabileceğini** seçebilir.
5. Eğer rezervasyon mümkünse, API hangi vagona kaç kişinin yerleştirileceğini JSON formatında döner.

---

## 🛠 Kullanılan Teknolojiler

- **C# 12**
- **.NET 8 Web API (Minimal API)**
- **Swagger (OpenAPI)** → Test arayüzü için
- **Git & GitHub** → Versiyon kontrolü

---

## 🚀 Kurulum ve Çalıştırma

### 1. Projeyi Kopyala

```bash
git clone https://github.com/Musakusbey/ada-yazilim-reservation.git
cd ada-yazilim-reservation/AdaYazilimProject

```
