# Принципи програмування, використані у проєкті

## 1. Модульність (Modularity)

У проєкті реалізовано поділ на окремі модулі. Консольний застосунок відповідає за взаємодію з користувачем, а бібліотека класів містить логіку роботи з даними.

SimpleClassConsole – містить меню, введення та виведення даних:
[SimpleClassConsole](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/tree/main/SimpleClassConsole)

SimpleClassLibrary – містить класи Entrant та ZNO:
[SimpleClassLibrary](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/tree/main/SimpleClassLibrary)

Такий поділ дозволяє відокремити інтерфейс користувача від бізнес-логіки.

---

## 2. Абстракція (Abstraction)

[Клас Entrant](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/blob/main/SimpleClassLibrary/Entrant.cs) приховує внутрішню логіку обчислень. 

Наприклад, обчислення конкурсного балу виконується всередині методу:
[Метод GetCompMark](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/blob/main/SimpleClassLibrary/Entrant.cs#L55-L63)

Користувач класу просто викликає метод і не знає, як саме відбувається обчислення.

Також визначення найкращого предмета реалізовано окремим методом:

[Метод GetBestSubject](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/blob/main/SimpleClassLibrary/Entrant.cs#L65-L80)

Це спрощує використання класу та приховує складність реалізації.

---

## 3. Інкапсуляція (Encapsulation)

Доступ до даних об'єкта здійснюється через спеціальні методи доступу, наприклад:

[Метод GetName](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/blob/main/SimpleClassLibrary/Entrant.cs#L30-L33)

[Метод GetAvgPoints](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/blob/main/SimpleClassLibrary/Entrant.cs#L45-L48)

Замість прямого використання змінних ззовні застосовуються методи, що дозволяє контролювати доступ до даних.

---

## 4. Принцип єдиної відповідальності (Single Responsibility Principle)

Клас ZNO відповідає лише за зберігання інформації про один предмет та його бали.

[Клас ZNO](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/blob/main/SimpleClassLibrary/ZNO.cs)

Він не містить логіки, яка не пов’язана з предметом ЗНО. Це спрощує підтримку та розширення коду.

---

## 5. Принцип DRY (Don't Repeat Yourself)

У класі Program реалізовано метод для виведення повідомлень з кольором:

[Метод ShowMessage](https://github.com/AnnaKlymchuk6/oop-lab5-refactoring/blob/main/SimpleClassConsole/Program.cs#L321-L326)

Замість повторення однакового коду для встановлення кольору та виведення тексту використовується один універсальний метод. Це зменшує дублювання коду та покращує читабельність.