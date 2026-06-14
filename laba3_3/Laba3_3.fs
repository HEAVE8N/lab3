open System
open System.IO

/// Функция нахождения минимального файла
let rec lenFileDirect (files: string seq) len = 
    if Seq.length files = 1 then
        let first = Seq.head files
        if first.Length < len then 
            first.Length 
        else 
            len
    else
        let first = Seq.head files
        let rest = Seq.tail files
        if first.Length < len then
            lenFileDirect rest first.Length
        else
            lenFileDirect rest len

/// Проверка наличия директории и получения имен  файлов
let rec getValidDirectory() =
    printf "Введите путь к директории: "
    let path = Console.ReadLine()
    
    if Directory.Exists(path) then
        path
    else
        printfn "Ошибка: Директория '%s' не существует!" path
        printfn "Попробуйте снова."
        getValidDirectory()

[<EntryPoint>]
let main argv =
    let directory = getValidDirectory()
    // Получаем файлы как последовательность
    let files = Directory.GetFiles(directory) |> Seq.ofArray
    // Преобразуем в имена файлов
    let fileNames = files |> Seq.map Path.GetFileName
    if not (Seq.isEmpty fileNames) then
        // Находим максимальную длину
        let minLen = lenFileDirect fileNames Int32.MaxValue
        printfn "\nМинимальная длина имени файла: %d" minLen
    else
        printfn "В директории нет файлов"
    0