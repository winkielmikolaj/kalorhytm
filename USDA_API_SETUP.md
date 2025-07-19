# USDA FoodData Central API Setup

## Jak uzyskać klucz API

1. Przejdź na stronę [USDA FoodData Central](https://fdc.nal.usda.gov/api-guide/)
2. Kliknij "Get an API Key" w prawym górnym rogu
3. Wypełnij formularz z danymi:
   - **Email**: Twój email
   - **Organization**: Nazwa organizacji (możesz wpisać "Personal")
   - **Intended Use**: Opisz jak będziesz używać API (np. "Personal calorie tracking app")
4. Kliknij "Submit"
5. Sprawdź email - otrzymasz klucz API

## Konfiguracja w aplikacji

1. Otwórz plik `Kalorhytm.WebApp/appsettings.json`
2. W sekcji `USDA` dodaj swój klucz API:

```json
{
  "USDA": {
    "ApiKey": "twój-klucz-api-tutaj"
  }
}
```

## Bez klucza API

Jeśli nie masz klucza API, aplikacja będzie używać demo danych. To oznacza, że:
- Wyszukiwanie będzie działać tylko z ograniczoną listą produktów
- Dane będą statyczne (nie z USDA bazy danych)
- Nie będziesz mieć dostępu do tysięcy produktów z USDA

## Funkcje USDA API

Po skonfigurowaniu klucza API będziesz mieć dostęp do:
- **Tysięcy produktów** z oficjalnej bazy danych USA
- **Dokładnych danych o wartościach odżywczych** (kalorie, białko, węglowodany, tłuszcze, błonnik, cukier, sód)
- **Wyszukiwania w czasie rzeczywistym** z USDA serwerów
- **Aktualnych danych** (baza jest regularnie aktualizowana)

## Przykłady wyszukiwania

Po skonfigurowaniu API możesz wyszukiwać:
- "apple" - jabłka
- "chicken breast" - pierś z kurczaka
- "rice" - ryż
- "milk" - mleko
- "bread" - chleb
- "salmon" - łosoś
- "avocado" - awokado
- "egg" - jajka
- "broccoli" - brokuły
- "banana" - banany

## Uwagi

- API ma limit 3600 zapytań dziennie (wystarczy dla osobistego użytku)
- Dane są w języku angielskim
- Wszystkie wartości są na 100g produktu
- API jest darmowe dla osobistego użytku 