namespace FSharpWebapp.Controllers

open System.Collections.Generic
open System.Linq
open Microsoft.AspNetCore.Mvc
open Newtonsoft.Json
open FSharpWebapp.Modules.CollectionFunctions
open FSharpWebapp.Models
open FSharpWebapp.DataAccessLayer


// [<CLIMutable>]
type Option<'TModel> =    
    | Some of 'TModel
    | None

[<Route("[controller]")>]
type ValuesController(context:AppDataContext) =
    inherit Controller()
    let toActionResult r =
        r :> IActionResult

    member private this._context = context

    [<HttpGet>]
    member this.Get() =  
        let members = this._context.Members.ToList() 
        this.Ok members |> toActionResult 

    [<HttpGet("{id}")>]
    member this.Get(id:int) = 
        let queryGet = 
            query { 
                for result in this._context.Members do 
                where (result.Id = id)
                select result
                exactlyOne
            } 

        let result =
            let r = queryGet
            match r.Id = 0 with  
            | true -> None
            | false -> Some r
                
            //this._context.Members.FirstOrDefault(fun x -> x.Id = id)
        
        match result with
            | Some r ->
                this.Json(r) |> toActionResult
            | None  ->
                this.NotFound() |> toActionResult
    
    [<HttpPost>]
    member this.Post([<FromBody()>] value) =
        match this.ModelState.IsValid with
            | true ->
                this._context.Members.Add value |> ignore
                this._context.SaveChanges() |> ignore
                let members = this._context.Members.ToList()
                this.Accepted (members) |> toActionResult
            | false ->
                this.BadRequest (this.ModelState) |> toActionResult
        
    