open System.Net

let extractStatusCode (inputResponse : HttpWebResponse) =
    inputResponse
    |> fun x -> x.StatusCode
    |> fun x -> Some(int x)

let getStatusCode (url : string) =
    try extractStatusCode(WebRequest.Create(url).GetResponse() :?> HttpWebResponse)
    with
    | :? System.Net.WebException as exc -> extractStatusCode(exc.Response :?> HttpWebResponse)
    | _                                 -> None

[<EntryPoint>]
let main _ =
    let url = "https://buythisspace.com.au"
    printfn "Testing 200 Response Code from URL: %s" url
    let respCode = getStatusCode url
    match respCode with
    | None      -> "Test Failed: Error encountered when getting response code."
    | Some(x)   -> if x <> 200 then "Test Failed: Incorrect status code " + x.ToString() + " encountered"
                   else "Test Passed: Status Code 200 encountered"
    |> fun x -> printfn "%s" x
    0
