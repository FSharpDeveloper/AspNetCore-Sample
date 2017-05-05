namespace FSharpWebapp

open System
open System.Threading.Tasks
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Builder
open Microsoft.EntityFrameworkCore
open FSharpWebapp.DataAccessLayer

[<AutoOpen>]
module Async =
  let inline StartAsPlainTask (work: Async<unit>)  = work |> Async.StartAsTask :> Task
  type IApplicationBuilder with
    member this.Run(handler: HttpContext -> Async<unit>) = 
      this.Run(RequestDelegate(handler >>  StartAsPlainTask))

type Startup (env:IHostingEnvironment) = 
  let builder = ConfigurationBuilder()
                  .SetBasePath(env.ContentRootPath)
                  .AddJsonFile("appSettings.json", true, true)
                  .AddJsonFile((sprintf "appSettings.%s.json" env.EnvironmentName), true)
                  .AddEnvironmentVariables() 

  let mutable configuration = builder.Build()
  let connectionString = configuration.GetConnectionString("DefaultConnection").ToString()   
  let contextOptions = DbContextOptionsBuilder<AppDataContext>().UseSqlServer(connectionString).Options //:?>  DbContextOptions<AppDataContext>
  member this.Configuration 
    with get () = configuration
    and set (value) = configuration <- value


  member this.ConfigureServices (services: IServiceCollection) = 
    // services
    //   //.AddSingleton<DbContextOptions<AppDataContext>>(contextOptions)
    //   .Add(new AppDataContext(contextOptions)) |> ignore
    services.AddDbContext<AppDataContext>(fun options -> options.UseSqlServer(connectionString) |> ignore) |> ignore
    services.AddMvc() |> ignore    

  member this.Configure (app:IApplicationBuilder, env:IHostingEnvironment, loggerFactory:ILoggerFactory) =
    loggerFactory.AddConsole() |> ignore

    if env.IsDevelopment() then 
      app.UseDeveloperExceptionPage() |> ignore
    
    // let myHandler (context:HttpContext) = async {
    //   do! context.Response.WriteAsync("") |> Async.AwaitTask
    // }
    app.Map(PathString "/api/v1", fun api -> api.UseMvc() |> ignore) |> ignore
    app.Map(PathString "/api/v2", fun root -> root.UseMvcWithDefaultRoute() |> ignore) |> ignore
    //app.Run myHandler
    app.UseMvcWithDefaultRoute() |> ignore
    // AppDataContext.InitializeDatabase




