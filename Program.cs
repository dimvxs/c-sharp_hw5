// See https://aka.ms/new-console-template for more information


// Задание 5
// Пользователь с клавиатуры вводит в строку арифметическое выражение. 
// Приложение должно посчитать его результат. Необходимо поддерживать только две операции: + и –.


// Console.WriteLine("enter a number: ");
// string num1 = Console.ReadLine();

// Console.WriteLine("enter a number: ");
// string num2 = Console.ReadLine();

// Console.WriteLine("enter an operation: ");
// string op = Console.ReadLine();


// int number1 = int.Parse(num1);
// int number2 = int.Parse(num2);
// int result = 0;
// switch (op){

//     case "+" :
// result = number1 + number2;
// Console.Write(number1 + " + " + number2 + " = " + result + "\n");
//     break;

//     case "-" :
//     result = number1 - number2;
//     Console.Write(number1 + " - " + number2 + " = " + result + "\n");
//     break;

// }






// Задание 6
// Пользователь с клавиатуры вводит некоторый текст. 
// Приложение должно изменять регистр первой буквы каждого предложения на букву в верхнем регистре.
// Например, если пользователь ввёл: «today is a good day for walking. i will try to walk near the sea».
// Результат работы приложения: «Today is a good day for walking. I will try to walk near the sea».

// using System.Text;

// Console.WriteLine("enter a sentence: ");
// StringBuilder sentence = new StringBuilder();

// sentence.Append(Console.ReadLine());
// sentence[0] = char.ToUpper(sentence[0]);

// int j = 0;
//  for(int i = 1; i < sentence.Length; i++){
//     j = i + 1;
//     if(sentence[i] == '.' || sentence[i] == '?' || sentence[i] == '!'){
//         sentence[j] = char.ToUpper(sentence[j]);

//     }
//  }
//  Console.WriteLine(sentence.ToString());





//Задание 7
// Создайте приложение, проверяющее текст на недопустимые слова. Если недопустимое слово найдено, оно должно быть заменено на набор символов *. По итогам работы приложения необходимо показать статистику действий.
// Например, если и у нас есть такой текст:
// To be, or not to be, that is the question, Whether 'tis nobler in the mind to suffer
// The slings and arrows of outrageous fortune,
// Or to take arms against a sea of troubles,
// And by opposing end them? To die: to sleep;
// No more; and by a sleep to say we end
// The heart-ache and the thousand natural shocks That flesh is heir to, 'tis a consummation Devoutly to be wish'd. To die, to sleep
// Недопустимое слово: die.
// Результат работы:
// To be, or not to be, that is the question, Whether 'tis nobler in the mind to suffer The slings and arrows of outrageous fortune,
// Or to take arms against a sea of troubles,
// And by opposing end them? To ***: to sleep;
// No more; and by a sleep to say we end
// The heart-ache and the thousand natural shocks That flesh is heir to, 'tis a consummation Devoutly to be wish'd. To ***, to sleep.
// Статистика: 2 замены слова die.


// using System.Text;

// StringBuilder text = new StringBuilder();

// text.Append("To be, or not to be, that is the question, " +
//                     "Whether 'tis nobler in the mind to suffer " +
//                     "The slings and arrows of outrageous fortune, " +
//                     "Or to take arms against a sea of troubles, " +
//                     "And by opposing end them? To die: to sleep; " +
//                     "No more; and by a sleep to say we end " +
//                     "The heart-ache and the thousand natural shocks " +
//                     "That flesh is heir to, 'tis a consummation " +
//                     "Devoutly to be wish'd. To die, to sleep");

// string sentences = text.ToString();

// string[] words = sentences.Split(new char[] { ' ', ',', '.', '!', '?' });

// int advirsory = 0;

// for(int i = 0; i < words.Length; i++){
// if(words[i] == "die" || words[i] == "Die"){
//     advirsory++;
//     words[i] = "***";
// }
// }

// foreach(string word in words){
//     Console.Write(word + " ");
// }


// Console.Write("\n prohibiteds: " + advirsory + "\n");



// Задание 3
// Пользователь вводит строку с клавиатуры. Необходимо зашифровать данную строку используя шифр Цезаря. Из Википедии:
// Подробнее тут: https://en.wikipedia.org/wiki/Caesar_ cipher.
// Шифр Цезаря — это вид шифра подстановки, в котором каждый символ в открытом тексте заменяется символом, находящимся
// на некотором постоянном числе позиций левее или правее него в алфавите. Например, в шифре со сдвигом вправо на 3,
// A была бы заменена на D, B станет E, и так далее.
// Кроме механизма шифровки, реализуйте механизм расшифрования.

Console.WriteLine("enter some text: ");
string text = Console.ReadLine();

string dictionary = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
string dictionaryUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

int shift = 3;


string encryptedText = Encrypt(text, dictionary, dictionaryUpper, shift);
        Console.WriteLine("Encrypted text: " + encryptedText);


        string decryptedText = Decrypt(encryptedText, dictionary, dictionaryUpper, shift);
        Console.WriteLine("Decrypted text: " + decryptedText);

  static string Encrypt(string input, string dictionary, string dictionaryUpper, int shift)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (char.IsLower(currentChar))
            {
                int index = dictionary.IndexOf(currentChar);
                if (index != -1)
                {
                    int newIndex = (index + shift) % dictionary.Length;
                    result[i] = dictionary[newIndex];
                }
                else
                {
                    result[i] = currentChar; // Если не в словаре, оставляем символ без изменений
                }
            }
            else if (char.IsUpper(currentChar))
            {
                int index = dictionaryUpper.IndexOf(currentChar);
                if (index != -1)
                {
                    int newIndex = (index + shift) % dictionaryUpper.Length;
                    result[i] = dictionaryUpper[newIndex];
                }
                else
                {
                    result[i] = currentChar; // Если не в словаре, оставляем символ без изменений
                }
            }
            else
            {
                result[i] = currentChar; // Если не буква, оставляем символ без изменений
            }
        }

        return new string(result);
    }




      static string Decrypt(string input, string dictionary, string dictionaryUpper, int shift)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (char.IsLower(currentChar))
            {
                int index = dictionary.IndexOf(currentChar);
                if (index != -1)
                {
                    int newIndex = (index - shift + dictionary.Length) % dictionary.Length; // +dictionary.Length для обработки отрицательных индексов
                    result[i] = dictionary[newIndex];
                }
                else
                {
                    result[i] = currentChar; // Если не в словаре, оставляем символ без изменений
                }
            }
            else if (char.IsUpper(currentChar))
            {
                int index = dictionaryUpper.IndexOf(currentChar);
                if (index != -1)
                {
                    int newIndex = (index - shift + dictionaryUpper.Length) % dictionaryUpper.Length; // +dictionaryUpper.Length для обработки отрицательных индексов
                    result[i] = dictionaryUpper[newIndex];
                }
                else
                {
                    result[i] = currentChar; // Если не в словаре, оставляем символ без изменений
                }
            }
            else
            {
                result[i] = currentChar; // Если не буква, оставляем символ без изменений
            }
        }

        return new string(result);
    }

