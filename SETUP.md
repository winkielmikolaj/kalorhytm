# Kalorhytm - Setup Instructions

## Konfiguracja projektu

### 1. Klonowanie repozytorium
```bash
git clone <repository-url>
cd Kalorhytm
```

### 2. Konfiguracja API USDA
1. Skopiuj plik `appsettings.example.json` do `appsettings.json`
2. Zastąp `YOUR_USDA_API_KEY_HERE` swoim kluczem API z [USDA Food Data Central](https://fdc.nal.usda.gov/api-key-signup.html)

### 3. Uruchomienie aplikacji
```bash
dotnet restore
dotnet build
dotnet run --project Kalorhytm.WebApp
```

Aplikacja będzie dostępna pod adresem: http://localhost:5150

## Struktura projektu

- **Kalorhytm.Contracts** - Modele danych
- **Kalorhytm.Domain** - Encje domenowe
- **Kalorhytm.Infrastructure** - Konfiguracja bazy danych i klienta USDA API
- **Kalorhytm.Logic** - Logika biznesowa
- **Kalorhytm.WebApp** - Aplikacja Blazor Server

## Baza danych

Aplikacja używa bazy danych w pamięci (In-Memory Database) dla celów deweloperskich. Dane są zachowywane między restartami aplikacji.

## API USDA

Aplikacja integruje się z USDA Food Data Central API do wyszukiwania produktów spożywczych. Jeśli klucz API nie jest skonfigurowany, aplikacja używa danych demo. 