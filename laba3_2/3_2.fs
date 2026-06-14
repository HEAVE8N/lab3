open System

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
        inputCount()
    else
        count

/// Функция для ввода списка чисел
let inputNumbers count =
    printfn "Введите эл списка: "
    [ for _ in 1..count -> readInt() ]

/// Функция для ввода искомого числа
let inputRequiredNumber() =
    printf "Какое число необходимо найти: "
    readInt()

/// проверка на наличие необходимого числа
let rec recNum num requiredNumber = 
    if num < 10 then
        if num = requiredNumber then 1 else 0
    else
        if num % 10 = requiredNumber then 1
        else recNum (num/10) requiredNumber

/// Перебор элементов в seq
let findNum numbers requiredNumber = 
    seq {
        for num in numbers do
            yield recNum (abs(num)) requiredNumber
    }

/// Функция для подсчета количества чисел с искомой цифрой
let calculateCount numbers requiredNumber =
    let numbersSeq = numbers |> Seq.ofList
    let listNum = findNum numbersSeq requiredNumber
    Seq.fold (fun acc x -> acc + x) 0 listNum    

[<EntryPoint>]
let main args = 
    let countEl = inputCount()
    let numbers = inputNumbers countEl
    let requiredNumber = inputRequiredNumber()
    let sum = calculateCount numbers requiredNumber
    printfn "Кол-во чисел с %i: %i" requiredNumber sum
    0
