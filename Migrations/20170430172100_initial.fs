namespace FSharpForPracticalDeveloper.Migrations

open System
open System.Collections.Generic
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Infrastructure
open Microsoft.EntityFrameworkCore.Migrations
open Microsoft.EntityFrameworkCore.Migrations.Operations
open Microsoft.EntityFrameworkCore.Migrations.Operations.Builders
open Microsoft.EntityFrameworkCore.Metadata
open FSharpWebapp.DataAccessLayer
    type colType = {Id:OperationBuilder<AddColumnOperation>; Address:OperationBuilder<AddColumnOperation>; Name:OperationBuilder<AddColumnOperation>}
    //type func<> = Action<CreateTableBuilder<colType>>

    [<DbContext(typeof<AppDataContext>)>]
    [<Migration("20170430172100_initial")>]
    
    type Initial() = 
        inherit Migration() 
        //with member x.Up(builder:MigrationBuilder) = base.Up(builder)

        override this.Up(builder:MigrationBuilder) =
            
            builder.CreateTable(
                name = "Members",
                columns =                
                    (fun t ->
                        {Id = t.Column<int>(nullable= false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                        Address = t.Column<string>(nullable= true);  
                        Name = t.Column<string>(nullable= true)}),

                constraints = 
                    (fun table ->
                        table.PrimaryKey("PK_Members", fun x -> (x.Id) :> obj) |> ignore) 
            ) |> ignore
        
            builder.CreateTable(
                name = "Persons",
                columns =                
                    (fun t ->
                        {Id = t.Column<int>(nullable= false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                        Address = t.Column<string>(nullable= true);  
                        Name = t.Column<string>(nullable= true)}),

                constraints = 
                    (fun table ->
                        table.PrimaryKey("PK_Persons", fun x -> (x.Id) :> obj) |> ignore) 
            ) |> ignore       

        override this.Down(builder:MigrationBuilder) =
            builder.DropTable(name = "Members") |> ignore

        override this.BuildTargetModel(builder:ModelBuilder) = 
            
            builder
                .HasAnnotation("ProductVersion", "1.1.1") 
                .HasAnnotation("SqlServer:ValueGenerationStartegy", SqlServerValueGenerationStrategy.IdentityColumn) |> ignore
            
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
                ) |> ignore