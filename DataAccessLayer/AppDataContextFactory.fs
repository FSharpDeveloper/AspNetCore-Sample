namespace FSharpWebapp.DataAccessLayer

    open Microsoft.EntityFrameworkCore
    open Microsoft.EntityFrameworkCore.Infrastructure
    open FSharpWebapp.DataAccessLayer

    type AppDataContextFactory() = 
            
        let connectionString:string = "Server=.\\SQLExpress;Database=FSharpAppDataContext;Trusted_Connection=True;MultipleActiveResultSets=true"
        let contextOptions = DbContextOptionsBuilder<AppDataContext>().UseSqlServer(connectionString).Options //:?>  DbContextOptions<AppDataContext>
        interface IDbContextFactory<AppDataContext> with 
            member this.Create (options:DbContextFactoryOptions)  =                 
                new AppDataContext(contextOptions)
