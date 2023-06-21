HelpTrader Service

Установка проекта в контейнере Docker

Откройте PowerShell
Перейдите в корневую папку проекта, где лежит файл docker-compose.yml

Выполнить команду

docker-compose up -d

В Docker Desktop должен появиться новый контейнер с названием HelpTrader, он будет включать в себя все необходимые сервисы для работы, например: Redis и тд.

В классе HelpTrader.Startup в метод ConfigureServices впишите ваш токен Тинькофф для песочницы

1) Запустите HelpTrader.Migrations
2) Запустите HelpTrader
3) Выберете из базы данных любой figi и передайте в параметр запроса в сваггере 