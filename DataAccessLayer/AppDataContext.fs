namespace FSharpWebapp.DataAccessLayer
    open System
    open Microsoft.EntityFrameworkCore
    open FSharpWebapp.Models

    // module contsAndFuncs =
    //     let connectionString = "Server=.\\SQLExpress;Database=AppDataContext;Trusted_Connection=True;MultipleActiveResultSets=true"

    type AppDataContext(options:DbContextOptions<AppDataContext>) = //as this = //  (options: DbContextOptions<AppDataContext>) as this =
        class
            inherit DbContext (options)
            let connectionString:string = "Server=.\\SQLExpress;Database=FSharpAppDataContext;Trusted_Connection=True;MultipleActiveResultSets=true"

            interface IDisposable with member this.Dispose() = this.Dispose()   
            // new () =  
            //     let op = new DbContextOptions<AppDataContext>(fun o -> o.UseSqlServer("Server=.\\SQLExpress;Database=AppDataContext;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //     AppDataContext(op)

            [<DefaultValue>]    
            val mutable members:DbSet<Member>
            member this.Members 
                with get () = this.members
                and set value = this.members <- value
            
            [<DefaultValue>]
            val mutable persons:DbSet<Person>
            member this.Persons 
                with get () = this.persons
                and set value = this.persons <- value
        
            override this.OnConfiguring(optionsBuilder:DbContextOptionsBuilder) =
                optionsBuilder.UseSqlServer connectionString 
                |> ignore
                // this.Database.CreateExecutionStrategy() |> ignore
                // this.Database.EnsureCreated() |> ignore
                base.OnConfiguring optionsBuilder
            
            // static member InitializeDatabase() = 
            //     use context = new AppDataContext()
            //         context.Database.EnsureCreated()
        end
