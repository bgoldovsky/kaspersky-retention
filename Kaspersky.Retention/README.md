# Kaspersky.Services.Retention

Тестовое задание Kaspersky (11.08.2019).

Микросервис применяющий заданные политики к хранилищу резервных копий.

## Политики хранения

Резервные копии создаются по расписанию дважды в сутки.
(По умолчанию в 8:00 и 20:00)

Для контроля состояния резервных копий они разделены по поколениям.

| Поколение | Период хранения (дни, включительно) | Максимальное количество копий |
|  :---:    | :---:                               |  :----:   |     
| 0         | 0-3                                 | 4         | 
| 1         | 4-7                                 | 4         |
| 2         | 8-14                                | 4         | 
| 3         | \>14                                | 1         | 

## Технологический стек

* C# 7.3
* .NET Core 2.2

## Слои сервиса

0. **Client.** Фейковый клиент микросервиса Kaspersky.Backup.
0. **Host.** Хост микросервиса, точка входа, подключение зависимостей.
0. **Services** Job выполняющий резервное копирование и hosted service для проверки соответствия резервных копий текущим политикам.
0. **Models.** Модели используемые несколькими слоями микросервиса, в т.ч. DTO для конфигурации и примитивы.

## Примитивы

#### BackupGeneration

Поколение резервной копии зависит от даты ее создани и определяет время ее жизни.

- [ ] Zero = 0
- [ ] First = 1
- [ ] Second = 2
- [ ] Third = 3

## Конфигурация

Конфигурация создания резервных копий. Содержит строку в формате cron, конфигурирующую Hangfire scheduler.
По умолчанию создание резервных копий происходит дважды в день, в 8:00 и 20:00.

    "RetentionBackupJob" : {
        "Cron": "0 8,20 * * *"
    }