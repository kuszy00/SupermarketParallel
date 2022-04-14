# Supermarket
Jest to mój pierwszy projekt w C# wykonany na drugim roku studiów w ramach przedmiotu Programowanie współbieżne.

This is my first C# project made in the second year of studies as part of the Concurrent Programming subject.
### Podstawowe wymagania projektu:
* Warunkiem koniecznym zaliczenia jest poprawna identyfikacja zasobów dzielonych i synchronizacja dostępu do sekcji krytycznej z wykorzystaniem określonego w zadaniu mechanizmu synchronizacji. Program musi spełniać własność bezpieczeństwa i własność żywotności.
* Rozwiązanie powinno się cechować prostotą, ale jednocześnie elastycznością i skalowalnością. 
* Liczba procesów sekwencyjnych musi być dobrana „z wyczuciem”, tak,aby zachować czytelność interfejsu, a równocześnie umożliwić wizualizację rozwiązania postawionego   problemu z uwzględnieniem ograniczonej w końcu zdolności percepcji osoby oceniającej.
* Kod źródłowy programu powinien być tak skonstruowany, aby istniał prosty sposób modyfikacji liczby procesów sekwencyjnych (za wyjątkiem zadań o ściśle określonej liczbie procesów).
* Ekran jest zasobem dzielonym!!!

## Problem do rozwiązania: **Symulacja obsługi kas w supermarkecie**.
### Założenia:
* M – liczba kas;
* N – maksymalna liczba klientów w sklepie;
* Osobne kolejki do każdej kasy;
* Przerwy kasjerów oraz ich zmiana po upływie określonego czasu (kasa jest w tym czasie zamknięta);
* Dokończenie obsługi wszystkich klientów z kolejki przed zamknięciem kasy.
