using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public async Task<IActionResult> ShowUserDetails()
        {
            //Fetch API,Axios API,HTTPClient, Jquery ajax
            //HTTP Req/response
            //http verbs: HTTPGET,HTTPPOST,HTTPDELETE,HTTPUPDATE,HTTPPATCH
            using (HttpClient client = new HttpClient())
            {
                //API URL: http://localhost:5000/api/User/SelectUsers //WebApiURL
                //StringContent content = new StringContent(JsonConvert.SerializeObject(bookDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result =await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            //StatusCode : 200,201,404,500
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {          
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Register";
                using (var response = await client.PostAsync(endPoint,content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Registered!";                      
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            //StatusCode : 200,201,404,500
            return View();
        }

        public async Task<IActionResult> EditUser(int userId)
        {
            //Fetch API,Axios API,HTTPClient
            //HTTP Req/response
            //http verbs: HTTPGET,HTTPPOST,HTTPDELETE,HTTPUPDATE,HTTPPATCH
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUserById?userId="+ userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/UpdateUser";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Updated!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            //StatusCode : 200,201,404,500
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int userId)
        {
            //Fetch API,Axios API,HTTPClient
            //HTTP Req/response
            //http verbs: HTTPGET,HTTPPOST,HTTPDELETE,HTTPUPDATE,HTTPPATCH
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUserById?userId=" + userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/DeleteUser?userId="+ userModel.UserId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deleted!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            //StatusCode : 200,201,404,500
            return View();
        }
    }
}
