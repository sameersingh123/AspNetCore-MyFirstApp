using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async(HttpContext context) =>
{
    //if (1 == 1)                                                      //if condition is true then status code will be 200
    //{
    //    context.Response.StatusCode = 200;
    //}
    //else
    //{
    //    context.Response.StatusCode = 500;
    //}
    //await context.Response.WriteAsync("Hello World");                //this will be printed on the browser screen



    //context.Response.Headers["Mykey"] = "My value";                    //this 'MyKey' will be added to the response header of the browser
    //context.Response.Headers["Context-Type"] = "text/html";            //this will make the response to be displayed in the browser screen to be in html format
    //await context.Response.WriteAsync("<h1>Hello<h1>");                //this will be printed on the browser screen
    //await context.Response.WriteAsync("<h2> World<h2>");



    //string path = context.Request.Path;                                  //this will set the path of the request in the path variable
    //string method = context.Request.Method;                              //this will set the method of the request in the method variable
    //context.Response.Headers["Context-Type"] = "text/html";              //this will make the response to be in html format
    //await context.Response.WriteAsync($"<p>{path}</p>");                 //this will print the path of the request on the browser screen
    //await context.Response.WriteAsync($"<p>{method}</p>");





                                             //Use of Query String in asp.net core

    //context.Response.Headers["Context-type"] = "text/html";               //this will make the response to be in html format
    //if (context.Request.Method == "GET")                                  
    //{
    //    if (context.Request.Query.ContainsKey("id"))                     //if the query contains the key 'id' then the value of the key will be printed on the browser screen
    //    {
    //        string id = context.Request.Query["id"];                    //this will set the value of the key 'id' in the id variable
    //        await context.Response.WriteAsync($"<p>{id}<p>");           //this will print the value of the key 'id' on the browser screen
    //    }
    //}



    //context.Response.Headers["Context-Type"] = "text/html";                        //this will make the response to be in html format
    //if (context.Request.Headers.ContainsKey("AuthorizationKey"))                  //if the request header contains the authorization key (in the postman) then the value of the key will be printed on the postman
    //{
    //    string authorizationKey = context.Request.Headers["AuthorizationKey"];   //this will set the value of the key
    //    await context.Response.WriteAsync($"<p>{authorizationKey}</p>");        //this will print the value of the key on the postman
    //}



                                   //Reading the request body in asp.net core programitically

    StreamReader reader = new StreamReader(context.Request.Body);    //here body of the request is of type stream so we are reading the body of the request using StreamReader just like we read the file
    string body = await reader.ReadToEndAsync();                     //In order to load the request body in the body variable we are using the ReadToEndAsync() method

                                     //Passing query string data to the request body
    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);    //Converting the query string data into the dictionary format using the ParseQuery() method

    if (queryDict.ContainsKey("Name"))
    {
        string name = queryDict["Name"];
        await context.Response.WriteAsync(name);
    }



});

app.Run();
