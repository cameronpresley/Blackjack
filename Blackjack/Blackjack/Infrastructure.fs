module Infrastructure
open FSharp.Reflection

let GetDiscriminatedUnionEnums<'a> () =
    FSharpType.GetUnionCases(typeof<'a>)
    |> Array.map (fun case -> FSharpValue.MakeUnion(case, [||]) :?> 'a)
    |> Array.toList

type MaybeBuilder() =
    member this.Bind(x, f) = 
        match x with
        | Some x -> f x
        | None -> None

    member this.Return(x) = Some x


