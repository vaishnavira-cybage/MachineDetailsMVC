﻿using MachineDetailsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress =
            new Uri("http://172.17.0.4:80/");
    }

    public async Task<IActionResult> Index()
    {

        string response = await _httpClient.GetStringAsync("details");
        if (response != null)
        {
            var machineDetails = JsonConvert.DeserializeObject<dynamic>(response); ;

            ViewBag.MachineName = machineDetails.machineName;
            ViewBag.MachineIP = machineDetails.machineIP;
            ViewBag.MachineOS = machineDetails.machineOS;
            ViewBag.Timestamp = machineDetails.timestamp;
        }

        return View();
    } 
}
