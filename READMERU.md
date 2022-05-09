# Musihqa

Стриминговый сервис на .Net Core.

Сейчас можно попробовать CRUD-операции с информацией о треках и альбомах.

## Getting Started

### Запускаем в Docker

 [Установите](https://docs.docker.com/desktop/) и сконфигурируйте Docker в вашем окружении. После этого из каталога **/src/** выполните команду:

~~~bash
docker-compose up -d
~~~

и вы готовы использовать `Musihqa`.

*Обратите внимание, что запуск контейнера Elasticsearch может занять некоторое время.*

Для доступа к Swagger UI используйте URL:

~~~
localhost:8090/swagger/index.html
~~~

---

*Используйте свой IP-адрес докера вместо `localhost`, если он отличается.*

Чтобы остановить и удалить контейнеры, из каталога **/src/** выполните команды:

~~~
docker-compose down
~~~

### Запускаем приложение локально

Запустим все необходимое для приложения в докере командой:

~~~
docker-compose up -d management-db kibana
~~~

В Volkin.Musihqa.Management.WebHost/appsettings.json измените IP-адреса в ElasticSearch и ConnectionStrings на IP-адрес вашего докера.

Откройте файл решения Volkin.Musihqa с помощью Visual Studio/Rider/etc, запустите проект Volkin.Musihqa.Management.WebHost и развлекайтесь!

## Смотрим логи в Kibana

После успешного запуска Kibana в Docker из docker-compose файла, вы можете открыть его, перейдя по ссылке:

~~~
localhost:5601
~~~

*Используйте свой IP-адрес докера вместо `localhost`, если он отличается.*

Для открытия Kibana может потребоваться время, просто подождите и перезагрузите страницу.

Давайте создадим [index-pattern](https://www.elastic.co/guide/en/kibana/7.17/index-patterns.html#index-patterns) для доступа к данным Elasticsearch.

1. Откройте ссылку `localhost:5601/app/management/kibana/indexPatterns` или откройте боковую панель слева, прокрутите вниз и нажмите **Stack Management > Index Patterns**. Должна открыться страница с надписью *"You have data in Elasticsearch. Now, create an index pattern."* Если вы этого не видите, попробуйте перезапустить docker-compose.
2. Нажмите **Create index pattern**.
3. Вставьте в поле `Name` `volkin-musihqa-management-webhost*` чтобы увидеть все логи, соответствующие данной маске. В поле `Timestamp field` выберите `@timestamp`. 
4. Нажмите **Create index pattern** еще раз.

Теперь можете открыть `localhost:5601/app/discover` или откройте боковую панель слева и нажмите [**Discover**](https://www.elastic.co/guide/en/kibana/current/discover.html).

