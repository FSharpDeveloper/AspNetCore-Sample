namespace FSharpWebapp.Modules
open System.Threading.Tasks

    module CollectionFunctions =
        let addToList (currentList:'a list) (element:'a) = 
            element :: currentList
        let addToListTail (currentList:'a list) (element:'a) =
            let newList = currentList @ [element]
            newList
        
        let applyFuncToListItems funcToApply itemsList =
            for item in itemsList do
                funcToApply item
        
        let product n =
            let initialValue = 1
            let action productSoFar x = productSoFar * x
            [1..n]|> List.fold action initialValue

        let some n = 
            let initialValue = 0
            let action someSoFar x = someSoFar + x
            [1..n]|> List.fold action initialValue
        // type Result<'TResult> =
        //     | Result of 'TResult

        let bind nextFunction optionInput =
            match optionInput with 
            | Some s -> nextFunction s
            | None -> None
        
        // let taskBind nextFunction task =
        //     task.WhenFinished (fun taskResult -> nextFunction taskResult)
        // let rec result = 
        //     [1..10]|> List.map (fun i r -> r (+) i)