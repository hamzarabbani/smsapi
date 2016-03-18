using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using OfflineSMSender.controller.json;
using SMSPIManager.Controller.json;
namespace SMSPIManager.Controller
{
    class Number_Checker
    {
        private string _port = "1688";
       
        public bool check(string mobileIP, string port)
        {
            var client = new RestClient("http://" + mobileIP + ":" + _port + "/");
            var request = new RestRequest(API.ONLINESTATUSAPI, Method.GET);
            try
            {
                var queryResponse = client.Execute<MobileStatusResponse>(request);
                var data = queryResponse.Data;
                return data.isSuccessful;   
            }
            catch(Exception ex)
            {
                return false;
            }
        }



        private String[] validate(String numbers)
        {
            String[] n = numbers.Split(',');
            List<String> l = n.ToList<String>();
            //int i = 0;
            int counter = l.Count;
            for (int i = 0; i < counter; i++ )
            {
                if (l.ElementAt(i).Length != 11 || l.ElementAt(i)[0] != '0' || l.ElementAt(i)[1] != '3')
                {
                    l.RemoveAt(i);
                    counter--;
                }

            }
                return l.ToArray<String>();
        }


        //dividing tasks per mobile.
        public List<List<NumberMessagePackage>> generateList(string numbers, List<String> mobiles)
        {
            
            List<List<NumberMessagePackage>> mainList = new List<List<NumberMessagePackage>>();
            List<NumberMessagePackage> sList = new List<NumberMessagePackage>();
            String[] number = validate(numbers);
            if(number == null)
            {
                return null;
            }
            int totalNumbers = number.Length;
            int totalMobiles = mobiles.Count;
            if (totalMobiles > 0)
            {
                int perMobile = totalNumbers / totalMobiles;
                int lastInsertIndex = 0;
                int a = 0;
                //don't allow perMobile = 1 because adds one more row
                if(perMobile > 0 && perMobile != 1)
                {
                    for (int i = 0; i < totalNumbers; i++)
                    {
                        var temp = new NumberMessagePackage();
                        temp.IP = mobiles.ElementAt(a);
                        temp.Number = number[i];
                        sList.Add(temp);

                        if ((i + 1) % perMobile == 0)
                        {
                            mainList.Add(sList);
                            sList = new List<NumberMessagePackage>();
                            lastInsertIndex = i;
                            a++;
                            if(a > perMobile - 1)
                            {
                                a--;
                            }
                        }

                    }
                }
                else
                {
                    //attaches all messages to single phone.
                    for (int i = 0; i < totalNumbers; i++)
                    {
                        var temp = new NumberMessagePackage();
                        temp.IP = mobiles.ElementAt(0);
                        temp.Number = number[i];
                        sList.Add(temp);
                        lastInsertIndex = i;
                    }
                    mainList.Add(sList);
  
                }

                if(lastInsertIndex < totalNumbers - 1)
                {
                    for(int i = lastInsertIndex + 1; i < totalNumbers; i++)
                    {
                        var temp = new NumberMessagePackage();
                        temp.IP = mobiles.ElementAt(mobiles.Count - 1);
                        temp.Number = number[i];
                        mainList.ElementAt(mainList.Count - 1).Add(temp);
                    }
                }
            }
            else
                return null;



            return mainList;
        } // end of function

        private List<ApiResponse> validateOnline(List<ApiResponse> numbers)
        {
            int counter = numbers.Count;
            for (int i = 0; i < counter; i++)
            {
                if (numbers.ElementAt(i).number.Length != 11 || numbers.ElementAt(i).number[0] != '0' || numbers.ElementAt(i).number[1] != '3')
                {
                    numbers.RemoveAt(i);
                    counter--;
                }

            }
            return numbers;
        }

        public List<List<NumberMessagePackageOnline>> generateListForWebClient(List<ApiResponse> numbers, List<String> mobiles)
        {

            List<List<NumberMessagePackageOnline>> mainList = new List<List<NumberMessagePackageOnline>>();
            List<NumberMessagePackageOnline> sList = new List<NumberMessagePackageOnline>();
            List<ApiResponse> number = validateOnline(numbers);
            if (number == null)
            {
                return null;
            }
            int totalNumbers = number.Count;
            int totalMobiles = mobiles.Count;
            if (totalMobiles > 0)
            {
                int perMobile = totalNumbers / totalMobiles;
                int lastInsertIndex = 0;
                int a = 0;
                //don't allow perMobile = 1 because adds one more row
                if (perMobile > 0 && perMobile != 1)
                {
                    for (int i = 0; i < totalNumbers; i++)
                    {
                        var temp = new NumberMessagePackageOnline();
                        temp.IP = mobiles.ElementAt(a);
                        temp.Number = number.ElementAt(i).number;
                        temp.Message = number.ElementAt(i).message;
                        temp.Id = number.ElementAt(i).id.ToString();
                        sList.Add(temp);

                        if ((i + 1) % perMobile == 0)
                        {
                            mainList.Add(sList);
                            sList = new List<NumberMessagePackageOnline>();
                            lastInsertIndex = i;
                            a++;
                            if (a > perMobile - 1)
                            {
                                a--;
                            }
                        }

                    }
                }
                else
                {
                    //attaches all messages to single phone.
                    for (int i = 0; i < totalNumbers; i++)
                    {
                        var temp = new NumberMessagePackageOnline();
                        temp.IP = mobiles.ElementAt(a);
                        temp.Number = number.ElementAt(i).number;
                        temp.Message = number.ElementAt(i).message;
                        temp.Id = number.ElementAt(i).id.ToString();
                        sList.Add(temp);
                        lastInsertIndex = i;
                    }
                    mainList.Add(sList);

                }

                if (lastInsertIndex < totalNumbers - 1)
                {
                    for (int i = lastInsertIndex + 1; i < totalNumbers; i++)
                    {
                        var temp = new NumberMessagePackageOnline();
                        temp.IP = mobiles.ElementAt(mobiles.Count - 1);
                        temp.Number = number.ElementAt(i).number;
                        temp.Message = number.ElementAt(i).message;
                        temp.Id = number.ElementAt(i).id.ToString();
                        mainList.ElementAt(mainList.Count - 1).Add(temp);
                    }
                }
            }
            else
                return null;



            return mainList;
        } // end of function
    }
}
