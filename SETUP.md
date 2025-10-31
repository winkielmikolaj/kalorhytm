# Kalorhytm - Setup Instructions

## Konfiguracja projektu

### 1. Klonowanie repozytorium
```bash
git clone <repository-url>
cd Kalorhytm
```

### 2. Konfiguracja API Spoonacular
1. Skopiuj plik `appsettings.example.json` do `appsettings.json`
2. Zastąp `SPOONACULAR_API_KEY` swoim kluczem API z [Spoonacular](https://spoonacular.com/food-api)

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
- **Kalorhytm.Infrastructure** - Konfiguracja bazy danych i klienta Spoonacular API
- **Kalorhytm.Logic** - Logika biznesowa
- **Kalorhytm.WebApp** - Aplikacja Blazor Server

## Baza danych

Aplikacja używa bazy danych w pamięci (In-Memory Database) dla celów deweloperskich. Dane są zachowywane między restartami aplikacji.

## API Spoonacular

Aplikacja integruje się z Spoonacular API do wyszukiwania produktów spożywczych i przepisów. Jeśli klucz API nie jest skonfigurowany, aplikacja używa danych demo. 