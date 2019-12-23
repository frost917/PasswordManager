using System;
using System.Collections.Generic;
namespace PasswordManager
{
    public class Program
    {
        static void Main()
        {
            Dictionary<int, AccountStorage> Accounts 
            = new Dictionary<int, AccountStorage>();

            string userInput;
            do
            {
                Console.WriteLine("1. 계정 저장 2. 계정 불러오기 Esc: 종료");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                    {
                        string id, passwd, info;
                        Console.WriteLine("계정의 용도를 입력해주세요.");
                        info = Console.ReadLine();
                        Console.WriteLine("ID를 입력해주세요");
                        id = Console.ReadLine();
                        Console.WriteLine("비밀번호를 입력해주세요.");
                        passwd = Console.ReadLine();

                        Accounts.Add(Accounts.Count, new AccountStorage(info, id, passwd));
                        break;
                    }
                    case "2":
                    {
                        if(Accounts.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("등록된 계정이 없습니다.");
                                break;
                            }

                        //등록된 계정은 한 페이지당 5개씩 출력
                        int downCount = Accounts.Count % 5;
                        //5개 이상의 계정 존재할 경우 화살표 키로 페이지 이동
                        int pageCount = Accounts.Count / 5;

                       // 1p당 5계정씩, 5개 이상이면 다음 페이지로 넘기고 이하면 남은 공간은 띄어쓰기로
                        int nowPage = 0;
                        do
                        {
                        if(downCount == 0)
                        {
                          for(int i = 0 + nowPage; i < 5 + nowPage; i++)
                          {
                            Console.WriteLine($"{Accounts[i].Info}: {Accounts[i].ID}/{Accounts[i].Passwd}");
                          }
                        }
                        else
                        {
                            for(int i = 0 + nowPage; i< downCount + nowPage; i++)
                            {
                               Console.WriteLine($"{Accounts[i].Info}: {Accounts[i].ID}/{Accounts[i].Passwd}");
                            }
                            for(int i = 0; i< 5 - downCount; i++)
                            {
                                Console.WriteLine();
                            }
                        }

                        nowPage = int.Parse(Console.ReadLine());
                        }while(userInput == "0");
                        break;
                    }
                }
                Console.Clear();
            }while(ConsoleKeyInfo.Equals(userInput, ConsoleKey.Escape));
        }
    }
}