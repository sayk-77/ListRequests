# ListRequests

## Что в репозитории:
- 2 дампа бд (без 3нф, с 3нф)
- блок-схемы алгоритмов
- 2 диаграммы бд
- unit тесты

## Что использовалось
- c#
- win-form
- postgresql
- MSTests

## Функциональность:
*Пользователь*
- вход
- создание заявок
- редактированое существующих
- удаление заявок

*Админ*
- вход
- добавление, редактирование, удаление заявок
- назначение мастеров на заказы
- фильтрация заявок
- поиск заявок

*Мастер*
- вход
- фильтрация заявок
- поиск заявок
- просмотр, создание, редактирование, удаление комментария к заявке
- просмотр, создание, редактирование, удаление замененных деталей к заявке
- запуск заявки в работу "В процессе ремонта"
- завершение работы над заявкой "Готова к выдаче", возможность указать замененные детали сразу при завершении
