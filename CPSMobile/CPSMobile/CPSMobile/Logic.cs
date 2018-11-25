﻿using CPSMobile.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPSMobile
{
    public static class Logic
    {
        private static string userId;
        private static readonly string clientURL = "https://08f4a653.ngrok.io";

        public static string getCurrentUserId()
        {
            return userId;
        }

        public static AppUserResponse SignIn(string email, string password)
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/User/Login?email=" + email + "&password=" + password, Method.POST);
            IRestResponse<AppUserResponse> response = client.Execute<AppUserResponse>(request);

            userId = response.Data.appUser.Id;

            return response.Data;
        }

        public static List<Room> GetUserRooms()
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/Room/GetUserRooms?appUserId=" + userId, Method.GET);
            IRestResponse<List<Room>> response = client.Execute<List<Room>>(request);

            return response.Data;
        }

        public static List<HowOften> GetHowOftens()
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/Coffee/GetHowOftens", Method.GET);
            IRestResponse<List<HowOften>> response = client.Execute<List<HowOften>>(request);

            return response.Data;
        }

        public static List<CoffeeType> GetCoffeeTypes()
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/Coffee/GetCoffeeTypes", Method.GET);
            IRestResponse<List<CoffeeType>> response = client.Execute<List<CoffeeType>>(request);

            return response.Data;
        }

        public static string MakeCupOfCoffee(string coffeeTypeId, string dateTime, int howOftenId)
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/Coffee/MakeCupOfCoffee", Method.POST);
            string appUserId = userId;
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
                new
                {
                    appUserId, 
                    coffeeTypeId, 
                    dateTime, 
                    howOftenId
                });

            IRestResponse<CoffeeDeviceResponse> response = client.Execute<CoffeeDeviceResponse>(request);

            return response.Data.Message;
        }

        public static CoffeeDeviceState GetCoffeeDeviceState()
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/Coffee/GetCoffeeDeviceState?appUserId=" + userId, Method.GET);
            IRestResponse<CoffeeDeviceState> response = client.Execute<CoffeeDeviceState>(request);

            return response.Data;
        }

        public static KeyValuePair<string, object>[] ChangeClimat(string roomId, int temperature, int airHumidity, int howOftenId, string date)
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/Room/ChangeClimat", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
                new
                {
                    roomId, 
                    temperature, 
                    airHumidity,
                    date, 
                    howOftenId
                });

            IRestResponse<object> response = client.Execute<object>(request);

            var data = response.Data as ICollection<KeyValuePair<string, object>>;

            KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[2];
            data.CopyTo(array, 0);

            return array;
        }

        public static KeyValuePair<string, object>[] ChangeIllumination(string roomId, bool isLight, int lightIntensity, int howOftenId, string date)
        {
            var client = new RestClient(clientURL);
            var request = new RestRequest("api/Room/ChangeIllumination", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
                new
                {
                    roomId,
                    isLight,
                    lightIntensity,
                    date,
                    howOftenId
                });

            IRestResponse<object> response = client.Execute<object>(request);

            var data = response.Data as ICollection<KeyValuePair<string, object>>;

            KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[2];
            data.CopyTo(array, 0);

            return array;
        }

        public static void SignOut()
        {
            userId = "";
        }

    }
}
