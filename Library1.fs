namespace FSharpConsoleMenu

module Menu=
    let header f =
            [for i  in 1..80 -> "*"] |> String.concat "" |> printfn "%s"
            printfn "%38s %s" " " "Menu"
            [for i  in 1..80-> "*" ] |> String.concat "" |> printfn "%s"    
            f()
            printfn ""
            printfn "Select one of the options above (q to quit or h for help):"

    let detailedHeader lst =
        fun()->
            header (fun()->  lst |> Seq.iter(fun(_,d,o,_)-> printfn "%s %s" o d))

    let basicHeader lst=
        fun()->
            header (fun()-> lst |> Seq.map(fun (t,_,o,_) -> o + " - " + t)  |> String.concat " | "  |>    printfn "%s")

    let  enterMenuLoop lst =
        let execTable = lst |> Seq.map(fun (_,_,k,f)-> (k,f)) |> Map.ofSeq
        let bh = basicHeader lst
        let dh = detailedHeader lst
        let rec loop(headerType) =
            System.Console.Clear()
            headerType()
            let userInput = System.Console.ReadLine()
            match userInput with
                | "q" ->
                    printfn "Quiting..."
                    System.Threading.Thread.Sleep(1000)
                | "h" ->
                    loop(dh)
                | _ ->
                    if execTable.ContainsKey userInput then 
                        printfn "Executing option %s" userInput
                        System.Threading.Thread.Sleep(1000)
                        execTable.[userInput]()
                    loop(bh)
        loop(bh)