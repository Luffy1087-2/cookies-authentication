# cookies-authentication

Simple way to have a session using cookies

#### Requirements
- Docker Desktop >= 4.51.0
- .NETCore 0.8.22
- DotEnv.Core >= 3.1.0
- Npgsql.EntityFrameworkCore.PostgreSQL >= 9.0.4

#### Initialize
Create `.env` file like this with the keys you want.

```
DB_USER=root
DB_PASSWORD=root
DB_NAME=cookies-authentication
PGADMIN_USER=root@test.com
PGADMIN_PASSWORD=root
```

Execute the command `docker-compose up -d`

Once the services are started, you need to create the `"users"` table using the pdAdmin tool.

Here's how to do:

- Open the link http://localhost:8080/browser/ ( pgAdmin )
- Connect the server: 
	- Host Name: `postgres`
	- Port: `5432`
	- Db: `cookies-authentication`
	- User name: same as the .env file
	- Password: same as the .env file
- Excecute query for `CREATE TABLE public.users (id bigint, userName text, password text, PRIMARY KEY (id));`
- Execute query for `INSERT INTO public.users (userName, password) VALUES ('test', 'testPw');`

#### Run the application

`dotnet run --launch-profile https`
