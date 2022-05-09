# Musihqa

Streaming music service on .Net Core.

Now you can test CRUD operations with information about tracks and albums.

[Ru-version of this Readme.](READMERU.md)

## Getting Started

### Run application in Docker

 [Install](https://docs.docker.com/desktop/) and configure docker in your environment. After that, from the **/src/** directory run the command:

~~~bash
docker-compose up -d
~~~

and get started with the `Musihqa`.

*Note that starting the Elasticsearch container may take time.*

To access Swagger UI use below URL:

~~~
localhost:8090/swagger/index.html
~~~

---

*Use your docker IP instead `localhost` if it's different.* 

To stop and remove containers, from the **/src/** directory run the commands:

~~~
docker-compose down
~~~

### Run application locally

Let's run all necessary things for application in docker with command:

~~~
docker-compose up -d management-db kibana
~~~

In Volkin.Musihqa.Management.WebHost/appsettings.json change IPs in ElasticSearch and ConnectionStrings to your docker IP.

Open solution file `Volkin.Musihqa` with Visual Studio/Rider/etc, run project `Volkin.Musihqa.Management.WebHost` and have fun!

## View logs with Kibana

After successfully launching Kibana in Docker from a docker-compose file, you can open it by following the link:

~~~
localhost:5601
~~~

*Use your docker IP instead `localhost` if it's different.*

Kibana may take time to open, just wait and reload page.

Let's create an [index-pattern](https://www.elastic.co/guide/en/kibana/7.17/index-patterns.html#index-patterns) to access the Elasticsearch data.

1. Go to `localhost:5601/app/management/kibana/indexPatterns` or open the sidebar on the left, scroll down and then click to **Stack Management > Index Patterns**. A page should open that says *"You have data in Elasticsearch. Now, create an index pattern."* If you don't see this, try to restart docker-compose.
2. Click **Create index pattern**.
3. Paste in the field `Name` `volkin-musihqa-management-webhost*` too see all logs that index matches this mask. In the `Timestamp field` select `@timestamp`. 
4. Click **Create index pattern** again.

Now you can open `localhost:5601/app/discover` or open the sidebar on the left and then click to [**Discover**](https://www.elastic.co/guide/en/kibana/current/discover.html).

