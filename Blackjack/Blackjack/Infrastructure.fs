module Infrastructure

open FSharp.Reflection

let GetAllUnionCases<'T> () =
    FSharpType.GetUnionCases(typeof<'T>)
    |> Array.map (fun case -> FSharpValue.MakeUnion(case, [||]) :?> 'T)
    |> Array.toList

type MaybeBuilder() =
    member this.Bind(input, func) =
        match input with
        | None -> None
        | Some x -> func x

    member this.Return x =
        Some x

let maybe = new MaybeBuilder()