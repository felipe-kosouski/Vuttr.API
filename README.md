## Vuttr - Very Useful Tools to Remember

This project is based on the challenge proposed by the [Bossabox](https://bossabox.com/) company.
The goal was to write an API that can serve as a repository to manage registered tools,
whit their names, links, descriptions, and tags.

There was no limitation on technology stack that was needed, it could be any language,
any database, any framework, libraries, and tools.

Since I'm currently working with c# and .net core, I choose this stack to build the API.

#### List of technologies and services
* C#
* .Net Core 3.1
* PostgreSQL
* Rider (IDE)
* Docker, and docker-compose
* Swagger
* Git/Github, Github Actions
* Heroku
* Insomnia

## Functionality
The app exposes a REST API to manage **Tools**.
A tool have the following structure

```cs
public class Tool
    {
        public Tool()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
        
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "{0} is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the {0} field is {1} characters")]
        public string Title { get; set; }
        
        public string Link { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
```
To create a new Tool, we need to send a json request to `/api/tools`

Example:

```json
{
	"title": "new tool",
	"link": "https://github.com/typicode/hotel",
	"description": "Local app manager. Start apps within your browser, developer tool with local .localhost domain and https out of the box.",
	"tags": [
		"tag 1",
		"tag 2"
	]
}
```

If successful, the API will return 201 and the response will give use the newly created tool with the random generated Id.

```json
{
  "id": "64969794-97b0-4c8b-973e-10579a8d7121",
  "title": "new tool",
  "link": "https://github.com/typicode/hotel",
  "description": "Local app manager. Start apps within your browser, developer tool with local .localhost domain and https out of the box.",
  "tags": [
    "tag 1",
    "tag 2"
  ]
}
```

To list all the tools, we can send a GET request to `api/tools`, and it will return the status code 200 with the list of tools.

Note that this endpoint `api/tools`, also support filtering and pagination.
If we send `api/tools?tag=html`, it will return all the tools that contains "html" on the tags list.

Also, the same endpoint supports pagination, sending the GET request like `api/tools?pageNumber=2&pageSize=2`, would return us the second page of a list with 2 tools per page.

The api supports following list of actions

* GET
* POST
* PUT
* DELETE

After running the api, you can, in your browser, go to localhost:3000/swagger, to see the full list of supported methods.

## Running the API
1. Clone this repository
2. Change envs on docker-compose
3. docker-compose up -d
4. The api will be available on localhost:3000/api/tools

If you want to run without docker, make sure to have a running instance of PostgreSQL, and then, from inside the folder that contains the solution file (.sln), you can run: 
1. dotnet restore
2. dotnet build
3. dotnet test
4. dotnet run
5. The api will listen on localhost:3000/api/tools

Note that to run without docker, you also need to have .net core sdk 3.1 installed.

## Authentication
The authentication was built with Identity, and it's using JWT.

To register, you need to send a request to `/api/auth/register` with the json
```json
{
  "firstname": "name",
  "lastname": "lastname",
  "username": "yourusername",
  "password": "yourpassword",
  "email": "your@email.com"
}
```

After registering, you can login using the `/api/auth/login` endpoint, sending your username and password, if the result is 200, check the Authorization header, you'll be granted with a Bearer jwt token that
you can use to login and send requests to other endpoints.

I will be adding new features to Authentication/Authorization, first one will be user areas, and then external login providers.
  
## Deploy
The api is deployed on [Heroku](https://app-vuttr-api.herokuapp.com/api/tools), but if you try to access it, you'll receive a 401, meaning that you're not authorized to get this resource (yet)...

I'm using Github Actions to automate the deploy process, feel free to take a look in the [Actions Section](https://github.com/felipe-kosouski/Vuttr.API/actions).

---
Finally, feel free to take a look at all the code, any improvement, suggestion, pull request will be welcome.


 


