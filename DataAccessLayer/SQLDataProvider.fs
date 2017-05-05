namespace FSharpWebapp.Providers

open System
open System.Data
open FSharp.Data
open System.Xml.Linq

    type DbSchema =  class end //<"Data Source=.\\SQLExpress;Initial Catalog=MyDatabase;Integrated Security=SSPI;">

    module functions =
        let y = fun (x:float, a:float, b:float) -> (x ** 2.) + (a * x) + b
        let f x = y
        let result = 
            let rec sum list = 
                match list with
                | h::tail -> (sum tail) + h
                | [] -> 0
            [1..10] |> sum

        printfn "%i" result