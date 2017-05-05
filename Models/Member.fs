namespace FSharpWebapp.Models

//module Models = 
type Member () = //{Id:int; Name:string; Address:string;}
    let mutable _id:int = 0
    let mutable _name:string = null
    let mutable _address:string = null

    member this.Id 
        with get() = _id and set value = _id <- value

    member this.Name
        with get() = _name and set value = _name <- value
    
    member this.Address 
        with get() = _address and set value = _address <- value

[<CLIMutable>]
type Person = {Id:int; Name:string; Address:string;}

module tests =
    let p = { Id = 0; Name ="Test"; Address = ""}
    let p1 = { p with Id = 11;Name = "testString";Address ="newAddress"}