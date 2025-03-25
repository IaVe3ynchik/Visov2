using System;
using System.IO;

class Task1{
    public delegate bool NameNotNull(string name);
    public static event Action<string, uint> OnUserCreated;

    public static void Main(){
        Task1.OnUserCreated += Task1.HandlerOnUserCreated;
        char symb = 'n';
        char userSymb = 'n';
        while(symb == 'n'){
            try{
                Console.Write("Введите ваше имя: ");
                string name = Console.ReadLine();

                Console.Write("Введите ваш возраст: ");
                uint age = uint.Parse(Console.ReadLine());

                NameNotNull notNullName = Task1.NotNullName;

                if(!notNullName(name)){
                    Console.WriteLine("Вы ввели пустое имя пользователя.");
                }

                else{
                    if(age < 18){
                        Console.WriteLine("Вы несовершеннолетний(-яя)");
                    }
                    else{
                        Task1.OnUserCreated?.Invoke(name, age);
                    }
                }
                do{
                    Console.Write("Желаете завершить программу?: (y/n) ");
                    userSymb = char.Parse(Console.ReadLine().Trim());
                } while(userSymb != 'y' && userSymb != 'n');
                symb = userSymb;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        
    }

    static bool NotNullName(string name){
        return !string.IsNullOrEmpty(name);
    }

    static void HandlerOnUserCreated(string name, uint age){
        File.AppendAllText("users.txt", $"Имя: {name}, возраст: {age}" + Environment.NewLine);
        Console.WriteLine("Пользователь зарегистрирован.");
    }
}