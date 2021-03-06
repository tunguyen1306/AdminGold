﻿using AdminGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminGold.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            //menu.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });
            //menu.Add(new Navbar { Id = 2, nameOption = "Charts", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 3, nameOption = "Flot Charts", controller = "Home", action = "FlotCharts", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 4, nameOption = "Morris.js Charts", controller = "Home", action = "MorrisCharts", status = true, isParent = false, parentId = 2 });
            //menu.Add(new Navbar { Id = 5, nameOption = "Tables", controller = "Home", action = "Tables", imageClass = "fa fa-table fa-fw", status = true, isParent = false, parentId = 0 });
            //menu.Add(new Navbar { Id = 6, nameOption = "Forms", controller = "Home", action = "Forms", imageClass = "fa fa-edit fa-fw", status = true, isParent = false, parentId = 0 });
            //menu.Add(new Navbar { Id = 7, nameOption = "UI Elements", imageClass = "fa fa-wrench fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 8, nameOption = "Panels and Wells", controller = "Home", action = "Panels", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 9, nameOption = "Buttons", controller = "Home", action = "Buttons", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 10, nameOption = "Notifications", controller = "Home", action = "Notifications", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 11, nameOption = "Typography", controller = "Home", action = "Typography", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 12, nameOption = "Icons", controller = "Home", action = "Icons", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 13, nameOption = "Grid", controller = "Home", action = "Grid", status = true, isParent = false, parentId = 7 });
            //menu.Add(new Navbar { Id = 14, nameOption = "Multi-Level Dropdown", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 15, nameOption = "Second Level Item", status = true, isParent = false, parentId = 14 });
            //menu.Add(new Navbar { Id = 16, nameOption = "Sample Pages", imageClass = "fa fa-files-o fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 17, nameOption = "Blank Page", controller = "Home", action = "Blank", status = true, isParent = false, parentId = 16 });
            ////menu.Add(new Navbar { Id = 18, nameOption = "Login Page", controller = "Home", action = "Login", status = true, isParent = false, parentId = 16 });
            //menu.Add(new Navbar { Id = 1, nameOption = "Trafashion",  imageClass = "fa fa-dashboard fa-fw", status = true, isParent = true, parentId = 0 });
            //menu.Add(new Navbar { Id = 3, nameOption = "Danh sách sản phẩm Trafashion", controller = "Products", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 1 });
            //menu.Add(new Navbar { Id = 5, nameOption = "Quản lý Blog Trafashion", controller = "tbl_blog_tra", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 1 });
           
            menu.Add(new Navbar { Id = 2, nameOption = "Vạn Gia", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 4, nameOption = "Danh sách dự án Vạn Gia", controller = "VanGia", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 6, nameOption = "Quản lý Blog Vạn Gia", controller = "tbl_blog_tra", action = "IndexVG", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 7, nameOption = "Tính xây dựng", controller = "MathVG", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 8, nameOption = "Quản lý Slider", controller = "AdminSlider", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 2 });



            menu.Add(new Navbar { Id = 9, nameOption = "Bàu trắng", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 10, nameOption = "Danh sách sản phẩm", controller = "Travel", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 9 });
            menu.Add(new Navbar { Id = 11, nameOption = "Danh sách blog", controller = "Travel", action = "IndexBlog", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 9 });
            menu.Add(new Navbar { Id = 13, nameOption = "Danh sách slider", controller = "Travel", action = "IndexSlider", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 9 });

            menu.Add(new Navbar { Id = 14, nameOption = "Đồ gỗ Nguyễn Diệp", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 15, nameOption = "Danh sách sản phẩm", controller = "WebDoGo", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId =14 });
            menu.Add(new Navbar { Id = 16, nameOption = "Danh sách blog", controller = "WebDoGo", action = "IndexBlog", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 14 });
            menu.Add(new Navbar { Id = 17, nameOption = "Danh sách slider", controller = "WebDoGo", action = "IndexSlider", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 14 });
            menu.Add(new Navbar { Id = 18, nameOption = "Danh sách danh mục", controller = "WebDoGo", action = "IndexCategory", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 14 });


            menu.Add(new Navbar { Id = 19, nameOption = "Coin", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 20, nameOption = "Category News", controller = "WebCoin", action = "IndexProduct", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 19 });
            menu.Add(new Navbar { Id = 21, nameOption = "Category List", controller = "WebCoin", action = "IndexCategory", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 19 });
          


            return menu.ToList();
        }
    }
}