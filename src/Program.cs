using System;
using System.Collections.Generic;
using System.Globalization;

namespace PasswordManager
{
    public class Program
    {
        static void Main()
        {
            Dictionary<int, AccountStorage> Accounts
            = new Dictionary<int, AccountStorage>();
            CultureInfo culture = new CultureInfo(CultureInfo.CurrentCulture.Name);

            string userInput;
            while( true )
            {
                // 모든 WriteLine의 Value값은 경고 제거를 위해 Xml로 이전할 것.
                Console.WriteLine("1. 계정 저장 2. 계정 불러오기");
                userInput = Console.ReadLine();
                switch( userInput )
                {
                    case "1":
                    {
                        Console.Clear();
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
                        if( Accounts.Count == 0 )
                        {
                            Console.Clear();
                            Console.WriteLine("등록된 계정이 없습니다.");
                            Console.Read();
                            break;
                        }

                        int nowPage = 0;
                        //등록된 계정은 한 페이지당 5개씩 출력
                        int downCount = Accounts.Count % 5;
                        //5개 이상의 계정 존재할 경우 화살표 키로 페이지 이동
                        int pageCount = Accounts.Count / 5;
                        do
                        {
                            try
                            {
                                for( int i = 0 + nowPage; i < 5 + nowPage; i++ )
                                {
                                    Console.WriteLine($"{Accounts[i].Info}: {Accounts[i].ID}/{Accounts[i].Passwd}");
                                }
                            }
                            catch( KeyNotFoundException )
                            {
                                for( int i = 0; i < 5 - downCount; i++ )
                                {
                                    Console.WriteLine();
                                }
                            }
                            Console.WriteLine($"{nowPage + 1} / {pageCount + 1} 페이지, 0: 메뉴로 돌아가기");

                            userInput = Console.ReadLine();
                            int tmp = nowPage;
                            try
                            {
                                nowPage = int.Parse(userInput, culture.NumberFormat);
                            }
                            catch( FormatException )
                            {
                                Console.WriteLine("잘못된 페이지입니다.");
                                nowPage = tmp;
                                Console.Read();
                            }

                        } while( !Equals(userInput, "0") );
                        break;
                    }
                }
                Console.Clear();
            }
        }
    }
}