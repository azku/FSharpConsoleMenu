# F# Console Menu

A very simple function that wraps your console application with a 1 level menu.

It only has 1 function with 1 parameter. The parameter is a list of 4 element tuple.
1. The first element in the tuple,  it's a string the title of the menu item.
1. The second element in the tuple, it's a string the description of the menu item.
1. The third element in the tuple, it's a string which the input  will activate the menu item.
1. The fourth element in the tuple, it's a function that will get executed when the input indicated on the third it's received.

```fsharp
FSharpConsoleMenu.Menu.enterMenuLoop [("Item 1", "Description of the first item", "1", fun()->  printfn "1");
				      ("Item 2", "Description of the second item", "2", fun()-> printfn "2");
				      ("Item 3", "Description of the third item", "3", fun()-> printfn "3")]
```