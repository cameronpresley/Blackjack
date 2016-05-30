module Infrastructure

open FSharp.Reflection

let GetAllUnionCases<'T> () =
    FSharpType.GetUnionCases(typeof<'T>)
    |> Array.map (fun case -> FSharpValue.MakeUnion(case, [||]) :?> 'T)
    |> Array.toList

type MaybeBuilder() =
    member this.Bind(m, f) =
        match m with
        | None -> None
        | Some x -> f x

    member this.Return x =
        Some x

let maybe = new MaybeBuilder()