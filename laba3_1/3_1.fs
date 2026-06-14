open System

/// Нахождение минимальных цифр
let rec minNum num min =
    if num < 10 then
        if num < min then num else min
    else
        if num % 10 < min then
            minNum (num / 10) (num % 10)
        else
            minNum (num / 10) min

let findMinNum numbers =
    numbers |> Seq.map (fun x -> minNum x 10)

/// Функция для безопасного ввода целого числа
let rec readInt() =
    match Int32.TryParse(Console.ReadLine()) with
    | true, value -> value
    | false, _ -> 
        printfn "Ошибка! Введите целое число."
        readInt()

/// Функция для ввода количества элементов
let rec inputCount() =
    printf "Введите кол-во эл списка: "
    let count = readInt()
    if count <= 0 then
        printfn "Количество элементов должно быть положительным!"
        inputCount()  // Рекурсивный запрос при ошибке
    else
        count

/// Функция для ввода списка чисел
let inputNumbers count =
    printfn "Введите эл списка: "
    [ for _ in 1 .. count -> readInt() ]

/// Функция для вычисления и вывода результатов
let processNumbers numbers =
    let numbersSeq = numbers |> Seq.ofList
    let minDigits = findMinNum numbersSeq
    printfn "Исходные числа: %A" numbers
    printfn "Минимальные цифры: %A" (minDigits |> Seq.toList)

[<EntryPoint>]
let main argv =
    let countEl = inputCount()
    let numbersList = inputNumbers countEl
    processNumbers numbersList
    0
