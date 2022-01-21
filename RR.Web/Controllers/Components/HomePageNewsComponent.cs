﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RR.Core;
using RR.Dto;
using RR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RR.Web.Controllers
{
     [ViewComponent(Name = "HomePageNewsComponent")]
     public class HomePageNewsComponent : ViewComponent
     {
          #region Constructor

          public static AppSettings _appSettings;
          private readonly INewsService _newsservice;

          public HomePageNewsComponent(INewsService newsservice,
               IOptions<AppSettings> appSettings)
          {
               _newsservice = newsservice;
               _appSettings = appSettings.Value;
          }

          #endregion

          /// <summary>
          /// This Method is used for getting all 
          /// relevent news on home page
          /// </summary>
          /// <returns>List of all news on home page</returns>
          public async Task<IViewComponentResult> InvokeAsync()
          {
               var newsResult = await _newsservice.GetHomePageNews();
               IEnumerable<NewsDto> news = newsResult.Item1;
               IEnumerable<NewsDto> popularNews = newsResult.Item2;
               IEnumerable<NewsDto> topNews = newsResult.Item3.OrderByDescending(x => x.NewsDate);
               ViewBag.NewsPicPath = _appSettings.MainSiteURL + "shared/" + _appSettings.NewsSharedPath;// _appSettings.AdminSiteURL + "assets/NewsImage/";
               return View(new Tuple<IEnumerable<NewsDto>, IEnumerable<NewsDto>, IEnumerable<NewsDto>>(news, popularNews, topNews));
          }
     }
}
