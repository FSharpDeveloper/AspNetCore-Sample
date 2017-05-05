namespace FSharpWebapp


    module Program =
        open System
        open System.IO
        open Microsoft.AspNetCore.Builder
        open Microsoft.AspNetCore.Hosting
        open Microsoft.Extensions.Configuration

        let returnNewFun fun1 fun2 =
            fun () -> fun1 >> fun2

        [<EntryPoint>]
        let main argv =
            let config = 
                ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build()
                            //.AddCommandLine(argv)
            let host =
                WebHostBuilder()
                    .UseConfiguration(config)
                    .UseKestrel()
                    .UseUrls("http://localhost:5000")
                    .UseStartup<Startup>()
                    .Build()
            
            host.Run()
            //printfn "Hello World from F#!"
            0 // return an integer exit code
