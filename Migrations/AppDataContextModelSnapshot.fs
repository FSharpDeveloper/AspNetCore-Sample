namespace FSharpWebapp.Migrations

open System
open System.Collections.Generic
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Infrastructure
open Microsoft.EntityFrameworkCore.Metadata
open Microsoft.EntityFrameworkCore.Migrations
open Microsoft.EntityFrameworkCore.Migrations.Operations
open Microsoft.EntityFrameworkCore.Migrations.Operations.Builders
open FSharpWebapp.DataAccessLayer

    [<DbContext(typeof<AppDataContext>)>]
    type AppDataContextModelSnapshot() = 
        inherit ModelSnapshot()

        override this.BuildModel(builder:ModelBuilder) =
            builder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn) |> ignore
            
            

            builder.Entity("FSharpWebapp.Models.Member", 
                fun b -> 
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd() |> ignore
                    b.Property<string>("Name") |> ignore
                    b.Property<string>("Address") |> ignore
                    b.HasKey("Id") |> ignore
                    b.ToTable("Members") |> ignore
            ) |> ignore

            builder.Entity("FSharpWebapp.Models.Person", 
                fun b -> 
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd() |> ignore
                    b.Property<string>("Name") |> ignore
                    b.Property<string>("Address") |> ignore
                    b.HasKey("Id") |> ignore
                    b.ToTable("Persons") |> ignore
                )|> ignore            